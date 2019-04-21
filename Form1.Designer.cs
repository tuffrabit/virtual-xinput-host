namespace TuFFrabitX360
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtX = new System.Windows.Forms.TextBox();
            this.txtY = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.txtRawY = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRawX = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUpLeft = new System.Windows.Forms.Button();
            this.btnDownLeft = new System.Windows.Forms.Button();
            this.btnUpRight = new System.Windows.Forms.Button();
            this.btnDownRight = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnBindings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.toolTip1.SetToolTip(this.button1, "Detects TuFFrabit Joystick, creates virtual Xbox 360 controller for the OS, and s" +
        "tarts converting input.");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(93, 34);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Stop";
            this.toolTip1.SetToolTip(this.button2, "Stops the TuFFrabit Joystick to virtual Xbox 360 input conversion process and the" +
        "n destroys the virtual controller.");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox1.Location = new System.Drawing.Point(0, 114);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(804, 337);
            this.textBox1.TabIndex = 2;
            this.textBox1.WordWrap = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(274, 39);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(86, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Show Status";
            this.toolTip1.SetToolTip(this.checkBox1, "Outputs conversion status and errors to the textbox below. Can slow down conversi" +
        "on, use for troubleshooting only.");
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Status:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(72, 86);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Clear";
            this.toolTip1.SetToolTip(this.button3, "Clear status textbox below.");
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "X:";
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(187, 93);
            this.txtX.Name = "txtX";
            this.txtX.ReadOnly = true;
            this.txtX.Size = new System.Drawing.Size(131, 20);
            this.txtX.TabIndex = 7;
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(349, 93);
            this.txtY.Name = "txtY";
            this.txtY.ReadOnly = true;
            this.txtY.Size = new System.Drawing.Size(131, 20);
            this.txtY.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(326, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Y:";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(366, 38);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(136, 17);
            this.checkBox2.TabIndex = 10;
            this.checkBox2.Text = "Show Individual Values";
            this.toolTip1.SetToolTip(this.checkBox2, "Populates the RawX, RawY, X, and Y fields below during input conversion. Used for" +
        " troubleshooting.");
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // txtRawY
            // 
            this.txtRawY.Location = new System.Drawing.Point(366, 67);
            this.txtRawY.Name = "txtRawY";
            this.txtRawY.ReadOnly = true;
            this.txtRawY.Size = new System.Drawing.Size(114, 20);
            this.txtRawY.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(326, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "RawY:";
            // 
            // txtRawX
            // 
            this.txtRawX.Location = new System.Drawing.Point(209, 67);
            this.txtRawX.Name = "txtRawX";
            this.txtRawX.ReadOnly = true;
            this.txtRawX.Size = new System.Drawing.Size(109, 20);
            this.txtRawX.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(164, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "RawX:";
            // 
            // btnLeft
            // 
            this.btnLeft.Enabled = false;
            this.btnLeft.Image = global::TuFFrabitX360.Properties.Resources.left;
            this.btnLeft.Location = new System.Drawing.Point(536, 49);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(28, 28);
            this.btnLeft.TabIndex = 15;
            this.toolTip1.SetToolTip(this.btnLeft, "Moves the virtual Xbox 360 controller stick left and then back to center.");
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnRight
            // 
            this.btnRight.Enabled = false;
            this.btnRight.Image = global::TuFFrabitX360.Properties.Resources.right;
            this.btnRight.Location = new System.Drawing.Point(596, 49);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(28, 28);
            this.btnRight.TabIndex = 16;
            this.toolTip1.SetToolTip(this.btnRight, "Moves the virtual Xbox 360 controller stick right and then back to center.");
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnUp
            // 
            this.btnUp.Enabled = false;
            this.btnUp.Image = global::TuFFrabitX360.Properties.Resources.up;
            this.btnUp.Location = new System.Drawing.Point(566, 18);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(28, 28);
            this.btnUp.TabIndex = 17;
            this.toolTip1.SetToolTip(this.btnUp, "Moves the virtual Xbox 360 controller stick up and then back to center.");
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Enabled = false;
            this.btnDown.Image = global::TuFFrabitX360.Properties.Resources.down;
            this.btnDown.Location = new System.Drawing.Point(566, 80);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(28, 28);
            this.btnDown.TabIndex = 18;
            this.toolTip1.SetToolTip(this.btnDown, "Moves the virtual Xbox 360 controller stick down and then back to center.");
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUpLeft
            // 
            this.btnUpLeft.Enabled = false;
            this.btnUpLeft.Image = global::TuFFrabitX360.Properties.Resources.upleft;
            this.btnUpLeft.Location = new System.Drawing.Point(536, 18);
            this.btnUpLeft.Name = "btnUpLeft";
            this.btnUpLeft.Size = new System.Drawing.Size(28, 28);
            this.btnUpLeft.TabIndex = 19;
            this.toolTip1.SetToolTip(this.btnUpLeft, "Moves the virtual Xbox 360 controller stick up and left and then back to center.");
            this.btnUpLeft.UseVisualStyleBackColor = true;
            this.btnUpLeft.Click += new System.EventHandler(this.btnUpLeft_Click);
            // 
            // btnDownLeft
            // 
            this.btnDownLeft.Enabled = false;
            this.btnDownLeft.Image = global::TuFFrabitX360.Properties.Resources.downleft;
            this.btnDownLeft.Location = new System.Drawing.Point(536, 80);
            this.btnDownLeft.Name = "btnDownLeft";
            this.btnDownLeft.Size = new System.Drawing.Size(28, 28);
            this.btnDownLeft.TabIndex = 20;
            this.toolTip1.SetToolTip(this.btnDownLeft, "Moves the virtual Xbox 360 controller stick down and left and then back to center" +
        ".");
            this.btnDownLeft.UseVisualStyleBackColor = true;
            this.btnDownLeft.Click += new System.EventHandler(this.btnDownLeft_Click);
            // 
            // btnUpRight
            // 
            this.btnUpRight.Enabled = false;
            this.btnUpRight.Image = global::TuFFrabitX360.Properties.Resources.upright;
            this.btnUpRight.Location = new System.Drawing.Point(596, 18);
            this.btnUpRight.Name = "btnUpRight";
            this.btnUpRight.Size = new System.Drawing.Size(28, 28);
            this.btnUpRight.TabIndex = 21;
            this.toolTip1.SetToolTip(this.btnUpRight, "Moves the virtual Xbox 360 controller stick up and right and then back to center." +
        "");
            this.btnUpRight.UseVisualStyleBackColor = true;
            this.btnUpRight.Click += new System.EventHandler(this.btnUpRight_Click);
            // 
            // btnDownRight
            // 
            this.btnDownRight.Enabled = false;
            this.btnDownRight.Image = global::TuFFrabitX360.Properties.Resources.downright;
            this.btnDownRight.Location = new System.Drawing.Point(596, 80);
            this.btnDownRight.Name = "btnDownRight";
            this.btnDownRight.Size = new System.Drawing.Size(28, 28);
            this.btnDownRight.TabIndex = 22;
            this.toolTip1.SetToolTip(this.btnDownRight, "Moves the virtual Xbox 360 controller stick down and right and then back to cente" +
        "r.");
            this.btnDownRight.UseVisualStyleBackColor = true;
            this.btnDownRight.Click += new System.EventHandler(this.btnDownRight_Click);
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(566, 49);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(28, 28);
            this.btnGo.TabIndex = 23;
            this.toolTip1.SetToolTip(this.btnGo, "Creates virtual Xbox 360 controller for the OS. Used for testing.");
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnBindings
            // 
            this.btnBindings.Location = new System.Drawing.Point(174, 35);
            this.btnBindings.Name = "btnBindings";
            this.btnBindings.Size = new System.Drawing.Size(75, 23);
            this.btnBindings.TabIndex = 24;
            this.btnBindings.Text = "Bindings";
            this.toolTip1.SetToolTip(this.btnBindings, "Opens the controller bindings window.");
            this.btnBindings.UseVisualStyleBackColor = true;
            this.btnBindings.Click += new System.EventHandler(this.btnBindings_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 451);
            this.Controls.Add(this.btnBindings);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.btnDownRight);
            this.Controls.Add(this.btnUpRight);
            this.Controls.Add(this.btnDownLeft);
            this.Controls.Add(this.btnUpLeft);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.txtRawY);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRawX);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.txtY);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(820, 490);
            this.MinimumSize = new System.Drawing.Size(820, 490);
            this.Name = "Form1";
            this.Text = "TuFFrabit X360";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.TextBox txtRawY;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRawX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUpLeft;
        private System.Windows.Forms.Button btnDownLeft;
        private System.Windows.Forms.Button btnUpRight;
        private System.Windows.Forms.Button btnDownRight;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnBindings;
    }
}

