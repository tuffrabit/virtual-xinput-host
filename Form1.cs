using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpDX.DirectInput;
using Nefarius.ViGEm.Client;
using Nefarius.ViGEm.Client.Targets;
using Nefarius.ViGEm.Client.Targets.Xbox360;
using System.Threading;
using System.Collections.Generic;

namespace TuFFrabitX360
{
    public partial class Form1 : Form
    {
        protected Task task;
        protected CancellationTokenSource tokenSource;
        protected ViGEmClient testClient;
        protected Xbox360Controller testController;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Enabled == true)
            {
                textBox1.Clear();
                txtX.Clear();
                txtY.Clear();
                txtRawX.Clear();
                txtRawY.Clear();

                DirectInput directInput = new DirectInput();
                Guid joystickGuid = Guid.Empty;

                foreach (var device in directInput.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AttachedOnly))
                {
                    if (device.InstanceName == "TuFFrabit Joystick" || device.InstanceName == "TuFFrabit Tartarus" || device.InstanceName == "TuFFrabit Gamepad")
                    {
                        joystickGuid = device.InstanceGuid;
                        break;
                    }
                }

                if (joystickGuid == Guid.Empty)
                {
                    logStatus("Couldn't find TuFFrabit Joystick.");
                }
                else
                {
                    Joystick joystick = new Joystick(directInput, joystickGuid);
                    Keyboard keyboard = new Keyboard(directInput);

                    joystick.Properties.BufferSize = 128;
                    keyboard.Properties.BufferSize = 128;

                    joystick.Acquire();
                    keyboard.Acquire();
                    logStatus("TuFFrabit Joystick found!");

                    this.tokenSource = new CancellationTokenSource();
                    CancellationToken cancellationToken = this.tokenSource.Token;

                    var message = new Progress<string>(taskMessage => {
                        logStatus(taskMessage);
                    });

                    var updateX = new Progress<string>(xValue => {
                        if (checkBox2.Checked)
                        {
                            txtX.Text = xValue;
                        }
                    });

                    var updateRawX = new Progress<string>(xValue => {
                        if (checkBox2.Checked)
                        {
                            txtRawX.Text = xValue;
                        }
                    });

                    var updateY = new Progress<string>(yValue => {
                        if (checkBox2.Checked)
                        {
                            txtY.Text = yValue;
                        }
                    });

                    var updateRawY = new Progress<string>(yValue => {
                        if (checkBox2.Checked)
                        {
                            txtRawY.Text = yValue;
                        }
                    });

                    this.task = Task.Factory.StartNew(() => DoProcessing(message, updateX, updateRawX, updateY, updateRawY, joystick, keyboard, cancellationToken));

                    if (!this.task.IsCanceled && !this.task.IsCompleted)
                    {
                        button1.Enabled = false;
                        button2.Enabled = true;
                        btnGo.Enabled = false;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button1.Enabled == false && !this.task.IsCanceled && !this.task.IsCompleted)
            {
                this.tokenSource.Cancel();

                try
                {
                    this.task.Wait();
                }
                catch (AggregateException ex)
                {
                    logStatus("Worker Error.");
                }
                finally
                {
                    this.tokenSource.Dispose();

                    button1.Enabled = true;
                    button2.Enabled = false;
                    btnGo.Enabled = true;
                }
            }
        }

        public void DoProcessing(IProgress<string> message, IProgress<string> xUpdate, IProgress<string> rawXUpdate, IProgress<string> yUpdate, IProgress<string> rawYUpdate, Joystick joystick, Keyboard keyboard, CancellationToken cancellationToken)
        {
            ViGEmClient client = new ViGEmClient();
            Xbox360Controller controller = new Xbox360Controller(client);
            ControllerBindingsStorage bindingStorage = new ControllerBindingsStorage();
            Dictionary<int, int> bindings = bindingStorage.load();
            Xbox360Axes? analogStickAxisX = null;
            Xbox360Axes? analogStickAxisY = null;
            Xbox360Axes? digitalStickAxisX = null;
            Xbox360Axes? digitalStickAxisY = null;
            Xbox360Buttons? joystickButton0 = null;
            bool leftTriggerLastPressed = false;
            bool leftTriggerPressed = false;
            bool rightTriggerLastPressed = false;
            bool rightTriggerPressed = false;
            bool digitalStickUpLastPressed = false;
            bool digitalStickUpPressed = false;
            bool digitalStickDownLastPressed = false;
            bool digitalStickDownPressed = false;
            bool digitalStickLeftLastPressed = false;
            bool digitalStickLeftPressed = false;
            bool digitalStickRightLastPressed = false;
            bool digitalStickRightPressed = false;

            foreach (KeyValuePair<int, int> binding in bindings)
            {
                if (binding.Key == (int)Xbox360StorageButtons.AnalogStick)
                {
                    AnalogStickBinding analogStickBinding = (AnalogStickBinding)Enum.Parse(typeof(AnalogStickBinding), binding.Value.ToString());

                    switch (analogStickBinding)
                    {
                        case AnalogStickBinding.LeftStick:
                            analogStickAxisX = Xbox360Axes.LeftThumbX;
                            analogStickAxisY = Xbox360Axes.LeftThumbY;
                            digitalStickAxisX = Xbox360Axes.RightThumbX;
                            digitalStickAxisY = Xbox360Axes.RightThumbY;

                            break;
                        case AnalogStickBinding.RightStick:
                            analogStickAxisX = Xbox360Axes.RightThumbX;
                            analogStickAxisY = Xbox360Axes.RightThumbY;
                            digitalStickAxisX = Xbox360Axes.LeftThumbX;
                            digitalStickAxisY = Xbox360Axes.LeftThumbY;

                            break;
                    }
                }

                if (binding.Value == (int)Key.JoystickButton)
                {
                    joystickButton0 = (Xbox360Buttons)Enum.Parse(typeof(Xbox360Buttons), binding.Key.ToString());
                }
            }

            controller.Connect();
            message.Report("Virtual Xbox 360 controller created!");

            Xbox360Report report = new Xbox360Report();

            while (true)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    controller.Disconnect();
                    return;
                }

                joystick.Poll();

                JoystickUpdate[] updates = joystick.GetBufferedData();

                foreach (JoystickUpdate update in updates)
                {
                    int value = (update.Value - 32767);

                    if (update.Offset == JoystickOffset.X || update.Offset == JoystickOffset.Y || update.Offset == JoystickOffset.Buttons0)
                    {
                        if (analogStickAxisX != null && analogStickAxisX.HasValue && analogStickAxisY != null && analogStickAxisY.HasValue)
                        {
                            if (update.Offset == JoystickOffset.X)
                            {
                                short x = getConstrainedValue(value);

                                report.SetAxis(analogStickAxisX.Value, x);
                                xUpdate.Report(x.ToString());
                                rawXUpdate.Report((update.Value - 32767).ToString());
                            }

                            if (update.Offset == JoystickOffset.Y)
                            {
                                short y = getConstrainedValue(value * -1);

                                report.SetAxis(analogStickAxisY.Value, y);
                                yUpdate.Report(y.ToString());
                                rawYUpdate.Report(((update.Value - 32767) * -1).ToString());
                            }
                        }

                        if (update.Offset == JoystickOffset.Buttons0 && joystickButton0 != null && joystickButton0.HasValue)
                        {
                            bool buttonValue = update.Value > 0 ? true : false;

                            report.SetButtonState(joystickButton0.Value, buttonValue);
                        }
                    }
                    
                    message.Report(update.Offset.ToString() + ": " + value.ToString());
                }

                keyboard.Poll();

                KeyboardUpdate[] keyboardUpdates = keyboard.GetBufferedData();

                foreach (KeyboardUpdate keyboardUpdate in keyboardUpdates)
                {
                    foreach (KeyValuePair<int, int> binding in bindings)
                    {
                        if ((int)keyboardUpdate.Key == binding.Value)
                        {
                            Xbox360Buttons? button = null;

                            switch (binding.Key)
                            {
                                case (int)Xbox360StorageButtons.Guide:
                                    button = Xbox360Buttons.Guide;
                                    break;
                                case (int)Xbox360StorageButtons.Start:
                                    button = Xbox360Buttons.Start;
                                    break;
                                case (int)Xbox360StorageButtons.Back:
                                    button = Xbox360Buttons.Back;
                                    break;
                                case (int)Xbox360StorageButtons.LeftShoulder:
                                    button = Xbox360Buttons.LeftShoulder;
                                    break;
                                case (int)Xbox360StorageButtons.RightShoulder:
                                    button = Xbox360Buttons.RightShoulder;
                                    break;
                                case (int)Xbox360StorageButtons.LeftTrigger:
                                    leftTriggerPressed = keyboardUpdate.Value == 128 ? true : false;
                                    break;
                                case (int)Xbox360StorageButtons.RightTrigger:
                                    rightTriggerPressed = keyboardUpdate.Value == 128 ? true : false;
                                    break;
                                case (int)Xbox360StorageButtons.A:
                                    button = Xbox360Buttons.A;
                                    break;
                                case (int)Xbox360StorageButtons.B:
                                    button = Xbox360Buttons.B;
                                    break;
                                case (int)Xbox360StorageButtons.X:
                                    button = Xbox360Buttons.X;
                                    break;
                                case (int)Xbox360StorageButtons.Y:
                                    button = Xbox360Buttons.Y;
                                    break;
                                case (int)Xbox360StorageButtons.Up:
                                    button = Xbox360Buttons.Up;
                                    break;
                                case (int)Xbox360StorageButtons.Down:
                                    button = Xbox360Buttons.Down;
                                    break;
                                case (int)Xbox360StorageButtons.Left:
                                    button = Xbox360Buttons.Left;
                                    break;
                                case (int)Xbox360StorageButtons.Right:
                                    button = Xbox360Buttons.Right;
                                    break;
                                case (int)Xbox360StorageButtons.LeftThumb:
                                    button = Xbox360Buttons.LeftThumb;
                                    break;
                                case (int)Xbox360StorageButtons.RightThumb:
                                    button = Xbox360Buttons.RightThumb;
                                    break;
                                case (int)Xbox360StorageButtons.DigitalStickUp:
                                    digitalStickUpPressed = keyboardUpdate.Value == 128 ? true : false;
                                    break;
                                case (int)Xbox360StorageButtons.DigitalStickDown:
                                    digitalStickDownPressed = keyboardUpdate.Value == 128 ? true : false;
                                    break;
                                case (int)Xbox360StorageButtons.DigitalStickLeft:
                                    digitalStickLeftPressed = keyboardUpdate.Value == 128 ? true : false;
                                    break;
                                case (int)Xbox360StorageButtons.DigitalStickRight:
                                    digitalStickRightPressed = keyboardUpdate.Value == 128 ? true : false;
                                    break;
                            }

                            if (button != null && button.HasValue)
                            {
                                bool pressed = keyboardUpdate.Value == 128 ? true : false;

                                report.SetButtonState(button.Value, pressed);
                            }

                            message.Report("Keyboard - Key: " + keyboardUpdate.Key + " Value: " + keyboardUpdate.Value);
                        }
                    }
                }

                if (leftTriggerPressed != leftTriggerLastPressed)
                {
                    if (leftTriggerPressed)
                    {
                        report.LeftTrigger = 255;
                    }
                    else
                    {
                        report.LeftTrigger = 0;
                    }

                    leftTriggerLastPressed = leftTriggerPressed;
                }

                if (rightTriggerPressed != rightTriggerLastPressed)
                {
                    if (rightTriggerPressed)
                    {
                        report.RightTrigger = 255;
                    }
                    else
                    {
                        report.RightTrigger = 0;
                    }

                    rightTriggerLastPressed = rightTriggerPressed;
                }

                if (digitalStickUpPressed != digitalStickUpLastPressed)
                {
                    if (digitalStickUpPressed)
                    {
                        report.SetAxis(digitalStickAxisY.Value, 32767);
                    }
                    else
                    {
                        report.SetAxis(digitalStickAxisY.Value, 0);
                    }

                    digitalStickUpLastPressed = digitalStickUpPressed;
                }

                if (digitalStickDownPressed != digitalStickDownLastPressed)
                {
                    if (digitalStickDownPressed)
                    {
                        report.SetAxis(digitalStickAxisY.Value, -32768);
                    }
                    else
                    {
                        report.SetAxis(digitalStickAxisY.Value, 0);
                    }

                    digitalStickDownLastPressed = digitalStickDownPressed;
                }

                if (digitalStickLeftPressed != digitalStickLeftLastPressed)
                {
                    if (digitalStickLeftPressed)
                    {
                        report.SetAxis(digitalStickAxisX.Value, -32768);
                    }
                    else
                    {
                        report.SetAxis(digitalStickAxisX.Value, 0);
                    }

                    digitalStickLeftLastPressed = digitalStickLeftPressed;
                }

                if (digitalStickRightPressed != digitalStickRightLastPressed)
                {
                    if (digitalStickRightPressed)
                    {
                        report.SetAxis(digitalStickAxisX.Value, 32767);
                    }
                    else
                    {
                        report.SetAxis(digitalStickAxisX.Value, 0);
                    }

                    digitalStickRightLastPressed = digitalStickRightPressed;
                }

                controller.SendReport(report);
                Thread.Sleep(1);
            }
        }

        protected short getConstrainedValue(int value)
        {
            if (value > 32767)
            {
                value = 32767;
            } else if (value < -32768)
            {
                value = -32768;
            }

            return (short)value;
        }

        protected void logStatus(string message)
        {
            if (checkBox1.Checked)
            {
                textBox1.Text = textBox1.Text + message + Environment.NewLine;
            }
        }

        protected void moveStick(Direction x, Direction y, Xbox360Controller controller)
        {
            if (controller != null && (x != Direction.Down || y != Direction.Down))
            {
                for (short i = 0; i < 32767; i++)
                {
                    Xbox360Report report = new Xbox360Report();

                    if (x == Direction.Up)
                    {
                        report.LeftThumbX = i;
                    }
                    else if (x == Direction.Down)
                    {
                        report.LeftThumbX = (short)(i * -1);
                    }

                    if (y == Direction.Up)
                    {
                        report.LeftThumbY = i;
                    }
                    else if (y == Direction.Down)
                    {
                        report.LeftThumbY = (short)(i * -1);
                    }

                    controller.SendReport(report);
                }

                for (short i = 32767; i > 0; i--)
                {
                    Xbox360Report report = new Xbox360Report();

                    if (x == Direction.Up)
                    {
                        report.LeftThumbX = i;
                    }
                    else if (x == Direction.Down)
                    {
                        report.LeftThumbX = (short)(i * -1);
                    }

                    if (y == Direction.Up)
                    {
                        report.LeftThumbY = i;
                    }
                    else if (y == Direction.Down)
                    {
                        report.LeftThumbY = (short)(i * -1);
                    }

                    controller.SendReport(report);
                }
            }
        }

        protected void enabledDisableMoveButtons(bool enable = true)
        {
            btnUp.Enabled = enable;
            btnDown.Enabled = enable;
            btnLeft.Enabled = enable;
            btnRight.Enabled = enable;
            btnUpLeft.Enabled = enable;
            btnUpRight.Enabled = enable;
            btnDownLeft.Enabled = enable;
            btnDownRight.Enabled = enable;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            txtX.Clear();
            txtY.Clear();
            txtRawX.Clear();
            txtRawY.Clear();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (this.testClient == null && this.testController == null)
            {
                this.testClient = new ViGEmClient();
                this.testController = new Xbox360Controller(this.testClient);
                this.testController.Connect();

                button1.Enabled = false;

                enabledDisableMoveButtons(true);
            } else
            {
                this.testController.Disconnect();
                this.testController.Dispose();
                this.testClient.Dispose();

                this.testController = null;
                this.testClient = null;
                button1.Enabled = true;

                enabledDisableMoveButtons(false);
            }
            
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() => moveStick(Direction.None, Direction.Up, this.testController));
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() => moveStick(Direction.None, Direction.Down, this.testController));
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() => moveStick(Direction.Up, Direction.None, this.testController));
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() => moveStick(Direction.Down, Direction.None, this.testController));
        }

        private void btnUpLeft_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() => moveStick(Direction.Down, Direction.Up, this.testController));
        }

        private void btnUpRight_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() => moveStick(Direction.Up, Direction.Up, this.testController));
        }

        private void btnDownLeft_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() => moveStick(Direction.Down, Direction.Down, this.testController));
        }

        private void btnDownRight_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() => moveStick(Direction.Up, Direction.Down, this.testController));
        }

        private void btnBindings_Click(object sender, EventArgs e)
        {
            ControllerBindings bindingsForm = new ControllerBindings();

            bindingsForm.ShowDialog();
        }
    }

    public enum Direction
    {
        None,
        Up,
        Down
    }
}
