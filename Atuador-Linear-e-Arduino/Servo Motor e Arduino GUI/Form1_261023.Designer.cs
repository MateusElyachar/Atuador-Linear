﻿namespace Servo_Motor_e_Arduino_GUI
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Parâmetros_Motor = new System.Windows.Forms.GroupBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.Enviar = new System.Windows.Forms.Button();
            this.Velocity = new System.Windows.Forms.Button();
            this.Direction2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.PulseQntd = new System.Windows.Forms.Button();
            this.Direction = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.SemAcelerar = new System.Windows.Forms.Button();
            this.En_Button = new System.Windows.Forms.Button();
            this.onButton = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.serialPort2 = new System.IO.Ports.SerialPort(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button11 = new System.Windows.Forms.Button();
            this.portComboBox = new System.Windows.Forms.ComboBox();
            this.button7 = new System.Windows.Forms.Button();
            this.ModoCalibracao = new System.Windows.Forms.Button();
            this.ModoMovimentacao = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.Aceleracao_calibracao = new System.Windows.Forms.Button();
            this.Sem_Aceleracao_calibracao = new System.Windows.Forms.Button();
            this.calibrar = new System.Windows.Forms.Button();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.A_laser = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Parâmetros_Motor.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // Parâmetros_Motor
            // 
            resources.ApplyResources(this.Parâmetros_Motor, "Parâmetros_Motor");
            this.Parâmetros_Motor.Controls.Add(this.textBox15);
            this.Parâmetros_Motor.Controls.Add(this.textBox8);
            this.Parâmetros_Motor.Controls.Add(this.textBox10);
            this.Parâmetros_Motor.Controls.Add(this.textBox9);
            this.Parâmetros_Motor.Controls.Add(this.Enviar);
            this.Parâmetros_Motor.Controls.Add(this.Velocity);
            this.Parâmetros_Motor.Controls.Add(this.Direction2);
            this.Parâmetros_Motor.Controls.Add(this.textBox1);
            this.Parâmetros_Motor.Controls.Add(this.PulseQntd);
            this.Parâmetros_Motor.Controls.Add(this.Direction);
            this.Parâmetros_Motor.Controls.Add(this.textBox2);
            this.Parâmetros_Motor.Controls.Add(this.button13);
            this.Parâmetros_Motor.Controls.Add(this.button14);
            this.Parâmetros_Motor.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Parâmetros_Motor.Name = "Parâmetros_Motor";
            this.Parâmetros_Motor.TabStop = false;
            // 
            // textBox15
            // 
            resources.ApplyResources(this.textBox15, "textBox15");
            this.textBox15.Name = "textBox15";
            // 
            // textBox8
            // 
            resources.ApplyResources(this.textBox8, "textBox8");
            this.textBox8.Name = "textBox8";
            // 
            // textBox10
            // 
            this.textBox10.AcceptsReturn = true;
            resources.ApplyResources(this.textBox10, "textBox10");
            this.textBox10.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.textBox10.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            // 
            // textBox9
            // 
            this.textBox9.AcceptsReturn = true;
            resources.ApplyResources(this.textBox9, "textBox9");
            this.textBox9.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.textBox9.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            // 
            // Enviar
            // 
            resources.ApplyResources(this.Enviar, "Enviar");
            this.Enviar.Name = "Enviar";
            this.Enviar.UseVisualStyleBackColor = true;
            this.Enviar.Click += new System.EventHandler(this.Enviar_Click_1);
            // 
            // Velocity
            // 
            resources.ApplyResources(this.Velocity, "Velocity");
            this.Velocity.Name = "Velocity";
            this.Velocity.UseVisualStyleBackColor = true;
            this.Velocity.Click += new System.EventHandler(this.Velocity_Click_1);
            // 
            // Direction2
            // 
            resources.ApplyResources(this.Direction2, "Direction2");
            this.Direction2.Name = "Direction2";
            this.Direction2.UseVisualStyleBackColor = true;
            this.Direction2.Click += new System.EventHandler(this.Direction2_Click_1);
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // PulseQntd
            // 
            resources.ApplyResources(this.PulseQntd, "PulseQntd");
            this.PulseQntd.Name = "PulseQntd";
            this.PulseQntd.UseVisualStyleBackColor = true;
            this.PulseQntd.Click += new System.EventHandler(this.PulseQntd_Click_1);
            // 
            // Direction
            // 
            resources.ApplyResources(this.Direction, "Direction");
            this.Direction.Name = "Direction";
            this.Direction.UseVisualStyleBackColor = true;
            this.Direction.Click += new System.EventHandler(this.Direction_Click_1);
            // 
            // textBox2
            // 
            resources.ApplyResources(this.textBox2, "textBox2");
            this.textBox2.Name = "textBox2";
            // 
            // button13
            // 
            resources.ApplyResources(this.button13, "button13");
            this.button13.Name = "button13";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click_1);
            // 
            // button14
            // 
            resources.ApplyResources(this.button14, "button14");
            this.button14.Name = "button14";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.SemAcelerar);
            this.groupBox1.Controls.Add(this.En_Button);
            this.groupBox1.Controls.Add(this.onButton);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.StopButton);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // button6
            // 
            resources.ApplyResources(this.button6, "button6");
            this.button6.Name = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // SemAcelerar
            // 
            resources.ApplyResources(this.SemAcelerar, "SemAcelerar");
            this.SemAcelerar.Name = "SemAcelerar";
            this.SemAcelerar.UseVisualStyleBackColor = true;
            this.SemAcelerar.Click += new System.EventHandler(this.SemAcelerar_Click_1);
            // 
            // En_Button
            // 
            resources.ApplyResources(this.En_Button, "En_Button");
            this.En_Button.Name = "En_Button";
            this.En_Button.UseVisualStyleBackColor = true;
            this.En_Button.Click += new System.EventHandler(this.En_Button_Click);
            // 
            // onButton
            // 
            resources.ApplyResources(this.onButton, "onButton");
            this.onButton.Name = "onButton";
            this.onButton.UseVisualStyleBackColor = true;
            this.onButton.Click += new System.EventHandler(this.onButton_Click_1);
            // 
            // textBox4
            // 
            this.textBox4.AcceptsReturn = true;
            resources.ApplyResources(this.textBox4, "textBox4");
            this.textBox4.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.textBox4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged_1);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // StopButton
            // 
            resources.ApplyResources(this.StopButton, "StopButton");
            this.StopButton.Name = "StopButton";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click_1);
            // 
            // serialPort2
            // 
            this.serialPort2.PortName = "COM9";
            this.serialPort2.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort2_DataReceived);
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.Parâmetros_Motor);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Controls.Add(this.button11);
            this.groupBox3.Controls.Add(this.portComboBox);
            this.groupBox3.Controls.Add(this.button7);
            this.groupBox3.Controls.Add(this.ModoCalibracao);
            this.groupBox3.Controls.Add(this.ModoMovimentacao);
            this.groupBox3.Controls.Add(this.button12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // button11
            // 
            resources.ApplyResources(this.button11, "button11");
            this.button11.Name = "button11";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // portComboBox
            // 
            resources.ApplyResources(this.portComboBox, "portComboBox");
            this.portComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.portComboBox.FormattingEnabled = true;
            this.portComboBox.Name = "portComboBox";
            this.portComboBox.Sorted = true;
            this.portComboBox.SelectedIndexChanged += new System.EventHandler(this.portComboBox_SelectedIndexChanged);
            // 
            // button7
            // 
            resources.ApplyResources(this.button7, "button7");
            this.button7.Name = "button7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // ModoCalibracao
            // 
            resources.ApplyResources(this.ModoCalibracao, "ModoCalibracao");
            this.ModoCalibracao.Name = "ModoCalibracao";
            this.ModoCalibracao.UseVisualStyleBackColor = true;
            this.ModoCalibracao.Click += new System.EventHandler(this.ModoCalibracao_Click);
            // 
            // ModoMovimentacao
            // 
            resources.ApplyResources(this.ModoMovimentacao, "ModoMovimentacao");
            this.ModoMovimentacao.Name = "ModoMovimentacao";
            this.ModoMovimentacao.UseVisualStyleBackColor = true;
            this.ModoMovimentacao.Click += new System.EventHandler(this.ModoMovimentacao_Click);
            // 
            // button12
            // 
            resources.ApplyResources(this.button12, "button12");
            this.button12.Name = "button12";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // groupBox4
            // 
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Controls.Add(this.textBox16);
            this.groupBox4.Controls.Add(this.button10);
            this.groupBox4.Controls.Add(this.button9);
            this.groupBox4.Controls.Add(this.button8);
            this.groupBox4.Controls.Add(this.textBox12);
            this.groupBox4.Controls.Add(this.button5);
            this.groupBox4.Controls.Add(this.textBox11);
            this.groupBox4.Controls.Add(this.Aceleracao_calibracao);
            this.groupBox4.Controls.Add(this.Sem_Aceleracao_calibracao);
            this.groupBox4.Controls.Add(this.calibrar);
            this.groupBox4.Controls.Add(this.textBox7);
            this.groupBox4.Controls.Add(this.textBox6);
            this.groupBox4.Controls.Add(this.A_laser);
            this.groupBox4.Controls.Add(this.button4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // textBox16
            // 
            this.textBox16.AcceptsReturn = true;
            resources.ApplyResources(this.textBox16, "textBox16");
            this.textBox16.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.textBox16.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox16.Name = "textBox16";
            this.textBox16.ReadOnly = true;
            this.textBox16.TextChanged += new System.EventHandler(this.textBox16_TextChanged);
            // 
            // button10
            // 
            resources.ApplyResources(this.button10, "button10");
            this.button10.Name = "button10";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button9
            // 
            resources.ApplyResources(this.button9, "button9");
            this.button9.Name = "button9";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            resources.ApplyResources(this.button8, "button8");
            this.button8.Name = "button8";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // textBox12
            // 
            resources.ApplyResources(this.textBox12, "textBox12");
            this.textBox12.Name = "textBox12";
            // 
            // button5
            // 
            resources.ApplyResources(this.button5, "button5");
            this.button5.Name = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // textBox11
            // 
            this.textBox11.AcceptsReturn = true;
            resources.ApplyResources(this.textBox11, "textBox11");
            this.textBox11.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.textBox11.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            // 
            // Aceleracao_calibracao
            // 
            resources.ApplyResources(this.Aceleracao_calibracao, "Aceleracao_calibracao");
            this.Aceleracao_calibracao.Name = "Aceleracao_calibracao";
            this.Aceleracao_calibracao.UseVisualStyleBackColor = true;
            this.Aceleracao_calibracao.Click += new System.EventHandler(this.Aceleracao_calibracao_Click);
            // 
            // Sem_Aceleracao_calibracao
            // 
            resources.ApplyResources(this.Sem_Aceleracao_calibracao, "Sem_Aceleracao_calibracao");
            this.Sem_Aceleracao_calibracao.Name = "Sem_Aceleracao_calibracao";
            this.Sem_Aceleracao_calibracao.UseVisualStyleBackColor = true;
            this.Sem_Aceleracao_calibracao.Click += new System.EventHandler(this.Sem_Aceleracao_calibracao_Click);
            // 
            // calibrar
            // 
            resources.ApplyResources(this.calibrar, "calibrar");
            this.calibrar.Name = "calibrar";
            this.calibrar.UseVisualStyleBackColor = true;
            this.calibrar.Click += new System.EventHandler(this.calibrar_Click);
            // 
            // textBox7
            // 
            resources.ApplyResources(this.textBox7, "textBox7");
            this.textBox7.Name = "textBox7";
            // 
            // textBox6
            // 
            resources.ApplyResources(this.textBox6, "textBox6");
            this.textBox6.Name = "textBox6";
            // 
            // A_laser
            // 
            resources.ApplyResources(this.A_laser, "A_laser");
            this.A_laser.Name = "A_laser";
            this.A_laser.UseVisualStyleBackColor = true;
            this.A_laser.Click += new System.EventHandler(this.A_laser_Click);
            // 
            // button4
            // 
            resources.ApplyResources(this.button4, "button4");
            this.button4.Name = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // pictureBox2
            // 
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox2.Image = global::Servo_Motor_e_Arduino_GUI.Properties.Resources.LM2C_Retina__1_downsise;
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // saveFileDialog1
            // 
            resources.ApplyResources(this.saveFileDialog1, "saveFileDialog1");
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Parâmetros_Motor.ResumeLayout(false);
            this.Parâmetros_Motor.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox Parâmetros_Motor;
        private System.Windows.Forms.Button Enviar;
        private System.Windows.Forms.Button Velocity;
        private System.Windows.Forms.Button Direction2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button PulseQntd;
        private System.Windows.Forms.Button Direction;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button SemAcelerar;
        private System.Windows.Forms.Button En_Button;
        private System.Windows.Forms.Button onButton;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button StopButton;
        private System.IO.Ports.SerialPort serialPort2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button ModoCalibracao;
        private System.Windows.Forms.Button ModoMovimentacao;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Button A_laser;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Button calibrar;
        private System.Windows.Forms.Button Sem_Aceleracao_calibracao;
        private System.Windows.Forms.Button Aceleracao_calibracao;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.ComboBox portComboBox;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

