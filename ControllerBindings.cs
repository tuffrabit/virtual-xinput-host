using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TuFFrabitX360
{
    public partial class ControllerBindings : Form
    {
        public ControllerBindings()
        {
            InitializeComponent();
            initDropDownBoxes();
            populateDropDownBoxes();
            btnSave.Enabled = false;
            btnApply.Enabled = false;
        }

        private void initDropDownBoxes()
        {
            Array keyValues = Key.GetValues(typeof(Key));
            cmbHome.DataSource = keyValues.Clone();
            cmbStart.DataSource = keyValues.Clone();
            cmbBack.DataSource = keyValues.Clone();
            cmbLeftBumper.DataSource = keyValues.Clone();
            cmbRightBumper.DataSource = keyValues.Clone();
            cmbLeftTrigger.DataSource = keyValues.Clone();
            cmbRightTrigger.DataSource = keyValues.Clone();
            cmbA.DataSource = keyValues.Clone();
            cmbB.DataSource = keyValues.Clone();
            cmbX.DataSource = keyValues.Clone();
            cmbY.DataSource = keyValues.Clone();
            cmbDUp.DataSource = keyValues.Clone();
            cmbDDown.DataSource = keyValues.Clone();
            cmbDLeft.DataSource = keyValues.Clone();
            cmbDRight.DataSource = keyValues.Clone();
            cmbLeftStickPress.DataSource = keyValues.Clone();
            cmbRightStickPress.DataSource = keyValues.Clone();
            cmbDigitalStickUp.DataSource = keyValues.Clone();
            cmbDigitalStickDown.DataSource = keyValues.Clone();
            cmbDigitalStickLeft.DataSource = keyValues.Clone();
            cmbDigitalStickRight.DataSource = keyValues.Clone();
            cmbAnalogStick.DataSource = AnalogStickBinding.GetValues(typeof(AnalogStickBinding));
        }

        private void populateDropDownBoxes()
        {
            ControllerBindingsStorage storage = new ControllerBindingsStorage();
            Dictionary<int, int> bindings = storage.load();

            if (bindings.Count > 0)
            {
                foreach (KeyValuePair<int, int> binding in bindings)
                {
                    switch (binding.Key)
                    {
                        case (int)Xbox360StorageButtons.Guide:
                            cmbHome.SelectedItem = (Key)Enum.Parse(typeof(Key), binding.Value.ToString());
                            break;
                        case (int)Xbox360StorageButtons.Start:
                            cmbStart.SelectedItem = (Key)Enum.Parse(typeof(Key), binding.Value.ToString());
                            break;
                        case (int)Xbox360StorageButtons.Back:
                            cmbBack.SelectedItem = (Key)Enum.Parse(typeof(Key), binding.Value.ToString());
                            break;
                        case (int)Xbox360StorageButtons.LeftShoulder:
                            cmbLeftBumper.SelectedItem = (Key)Enum.Parse(typeof(Key), binding.Value.ToString());
                            break;
                        case (int)Xbox360StorageButtons.RightShoulder:
                            cmbRightBumper.SelectedItem = (Key)Enum.Parse(typeof(Key), binding.Value.ToString());
                            break;
                        case (int)Xbox360StorageButtons.LeftTrigger:
                            cmbLeftTrigger.SelectedItem = (Key)Enum.Parse(typeof(Key), binding.Value.ToString());
                            break;
                        case (int)Xbox360StorageButtons.RightTrigger:
                            cmbRightTrigger.SelectedItem = (Key)Enum.Parse(typeof(Key), binding.Value.ToString());
                            break;
                        case (int)Xbox360StorageButtons.A:
                            cmbA.SelectedItem = (Key)Enum.Parse(typeof(Key), binding.Value.ToString());
                            break;
                        case (int)Xbox360StorageButtons.B:
                            cmbB.SelectedItem = (Key)Enum.Parse(typeof(Key), binding.Value.ToString());
                            break;
                        case (int)Xbox360StorageButtons.X:
                            cmbX.SelectedItem = (Key)Enum.Parse(typeof(Key), binding.Value.ToString());
                            break;
                        case (int)Xbox360StorageButtons.Y:
                            cmbY.SelectedItem = (Key)Enum.Parse(typeof(Key), binding.Value.ToString());
                            break;
                        case (int)Xbox360StorageButtons.Up:
                            cmbDUp.SelectedItem = (Key)Enum.Parse(typeof(Key), binding.Value.ToString());
                            break;
                        case (int)Xbox360StorageButtons.Down:
                            cmbDDown.SelectedItem = (Key)Enum.Parse(typeof(Key), binding.Value.ToString());
                            break;
                        case (int)Xbox360StorageButtons.Left:
                            cmbDLeft.SelectedItem = (Key)Enum.Parse(typeof(Key), binding.Value.ToString());
                            break;
                        case (int)Xbox360StorageButtons.Right:
                            cmbDRight.SelectedItem = (Key)Enum.Parse(typeof(Key), binding.Value.ToString());
                            break;
                        case (int)Xbox360StorageButtons.LeftThumb:
                            cmbLeftStickPress.SelectedItem = (Key)Enum.Parse(typeof(Key), binding.Value.ToString());
                            break;
                        case (int)Xbox360StorageButtons.RightThumb:
                            cmbRightStickPress.SelectedItem = (Key)Enum.Parse(typeof(Key), binding.Value.ToString());
                            break;
                        case (int)Xbox360StorageButtons.DigitalStickUp:
                            cmbDigitalStickUp.SelectedItem = (Key)Enum.Parse(typeof(Key), binding.Value.ToString());
                            break;
                        case (int)Xbox360StorageButtons.DigitalStickDown:
                            cmbDigitalStickDown.SelectedItem = (Key)Enum.Parse(typeof(Key), binding.Value.ToString());
                            break;
                        case (int)Xbox360StorageButtons.DigitalStickLeft:
                            cmbDigitalStickLeft.SelectedItem = (Key)Enum.Parse(typeof(Key), binding.Value.ToString());
                            break;
                        case (int)Xbox360StorageButtons.DigitalStickRight:
                            cmbDigitalStickRight.SelectedItem = (Key)Enum.Parse(typeof(Key), binding.Value.ToString());
                            break;
                        case (int)Xbox360StorageButtons.AnalogStick:
                            cmbAnalogStick.SelectedItem = (AnalogStickBinding)Enum.Parse(typeof(AnalogStickBinding), binding.Value.ToString());
                            break;
                    }
                }
            }
        }

        private void save()
        {
            Dictionary<int, int> values = new Dictionary<int, int>();
            ControllerBindingsStorage storage = new ControllerBindingsStorage();

            values.Add((int)Xbox360StorageButtons.Guide, (int)((Key)cmbHome.SelectedValue));
            values.Add((int)Xbox360StorageButtons.Start, (int)((Key)cmbStart.SelectedValue));
            values.Add((int)Xbox360StorageButtons.Back, (int)((Key)cmbBack.SelectedValue));
            values.Add((int)Xbox360StorageButtons.LeftShoulder, (int)((Key)cmbLeftBumper.SelectedValue));
            values.Add((int)Xbox360StorageButtons.RightShoulder, (int)((Key)cmbRightBumper.SelectedValue));
            values.Add((int)Xbox360StorageButtons.LeftTrigger, (int)((Key)cmbLeftTrigger.SelectedValue));
            values.Add((int)Xbox360StorageButtons.RightTrigger, (int)((Key)cmbRightTrigger.SelectedValue));
            values.Add((int)Xbox360StorageButtons.A, (int)((Key)cmbA.SelectedValue));
            values.Add((int)Xbox360StorageButtons.B, (int)((Key)cmbB.SelectedValue));
            values.Add((int)Xbox360StorageButtons.X, (int)((Key)cmbX.SelectedValue));
            values.Add((int)Xbox360StorageButtons.Y, (int)((Key)cmbY.SelectedValue));
            values.Add((int)Xbox360StorageButtons.Up, (int)((Key)cmbDUp.SelectedValue));
            values.Add((int)Xbox360StorageButtons.Down, (int)((Key)cmbDDown.SelectedValue));
            values.Add((int)Xbox360StorageButtons.Left, (int)((Key)cmbDLeft.SelectedValue));
            values.Add((int)Xbox360StorageButtons.Right, (int)((Key)cmbDRight.SelectedValue));
            values.Add((int)Xbox360StorageButtons.LeftThumb, (int)((Key)cmbLeftStickPress.SelectedValue));
            values.Add((int)Xbox360StorageButtons.RightThumb, (int)((Key)cmbRightStickPress.SelectedValue));
            values.Add((int)Xbox360StorageButtons.DigitalStickUp, (int)((Key)cmbDigitalStickUp.SelectedValue));
            values.Add((int)Xbox360StorageButtons.DigitalStickDown, (int)((Key)cmbDigitalStickDown.SelectedValue));
            values.Add((int)Xbox360StorageButtons.DigitalStickLeft, (int)((Key)cmbDigitalStickLeft.SelectedValue));
            values.Add((int)Xbox360StorageButtons.DigitalStickRight, (int)((Key)cmbDigitalStickRight.SelectedValue));
            values.Add((int)Xbox360StorageButtons.AnalogStick, (int)((AnalogStickBinding)cmbAnalogStick.SelectedValue));

            storage.save(values);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save();
            this.Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            save();
            btnSave.Enabled = false;
            btnApply.Enabled = false;
        }

        private void handleDropDownChanged()
        {
            btnSave.Enabled = true;
            btnApply.Enabled = true;
        }

        private void cmbHome_SelectedIndexChanged(object sender, EventArgs e)
        {
            handleDropDownChanged();
        }

        private void cmbStart_SelectedIndexChanged(object sender, EventArgs e)
        {
            handleDropDownChanged();
        }

        private void cmbBack_SelectedIndexChanged(object sender, EventArgs e)
        {
            handleDropDownChanged();
        }

        private void cmbLeftBumper_SelectedIndexChanged(object sender, EventArgs e)
        {
            handleDropDownChanged();
        }

        private void cmbRightBumper_SelectedIndexChanged(object sender, EventArgs e)
        {
            handleDropDownChanged();
        }

        private void cmbLeftTrigger_SelectedIndexChanged(object sender, EventArgs e)
        {
            handleDropDownChanged();
        }

        private void cmbRightTrigger_SelectedIndexChanged(object sender, EventArgs e)
        {
            handleDropDownChanged();
        }

        private void cmbA_SelectedIndexChanged(object sender, EventArgs e)
        {
            handleDropDownChanged();
        }

        private void cmbB_SelectedIndexChanged(object sender, EventArgs e)
        {
            handleDropDownChanged();
        }

        private void cmbX_SelectedIndexChanged(object sender, EventArgs e)
        {
            handleDropDownChanged();
        }

        private void cmbY_SelectedIndexChanged(object sender, EventArgs e)
        {
            handleDropDownChanged();
        }

        private void cmbDUp_SelectedIndexChanged(object sender, EventArgs e)
        {
            handleDropDownChanged();
        }

        private void cmbDDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            handleDropDownChanged();
        }

        private void cmbDLeft_SelectedIndexChanged(object sender, EventArgs e)
        {
            handleDropDownChanged();
        }

        private void cmbDRight_SelectedIndexChanged(object sender, EventArgs e)
        {
            handleDropDownChanged();
        }

        private void cmbLeftStickPress_SelectedIndexChanged(object sender, EventArgs e)
        {
            handleDropDownChanged();
        }

        private void cmbRightStickPress_SelectedIndexChanged(object sender, EventArgs e)
        {
            handleDropDownChanged();
        }

        private void cmbAnalogStick_SelectedIndexChanged(object sender, EventArgs e)
        {
            handleDropDownChanged();
        }

        private void cmbDigitalStickUp_SelectedIndexChanged(object sender, EventArgs e)
        {
            handleDropDownChanged();
        }

        private void cmbDigitalStickDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            handleDropDownChanged();
        }

        private void cmbDigitalStickLeft_SelectedIndexChanged(object sender, EventArgs e)
        {
            handleDropDownChanged();
        }

        private void cmbDigitalStickRight_SelectedIndexChanged(object sender, EventArgs e)
        {
            handleDropDownChanged();
        }
    }
}
