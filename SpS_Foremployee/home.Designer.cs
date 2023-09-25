namespace SpS_Foremployee
{
    partial class home
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.Text.ASCIIEncoding asciiEncodingSealed2 = new System.Text.ASCIIEncoding();
            System.Text.DecoderReplacementFallback decoderReplacementFallback2 = new System.Text.DecoderReplacementFallback();
            System.Text.EncoderReplacementFallback encoderReplacementFallback2 = new System.Text.EncoderReplacementFallback();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            comboBox1 = new ComboBox();
            groupBox1 = new GroupBox();
            panel1 = new Panel();
            pictureBox4 = new PictureBox();
            pictureBox3 = new PictureBox();
            groupBox2 = new GroupBox();
            panel2 = new Panel();
            label7 = new Label();
            pbreadcarplate = new PictureBox();
            comboBox2 = new ComboBox();
            tb_readcarplate = new TextBox();
            pbcamerafontin = new PictureBox();
            pictureBox5 = new PictureBox();
            textBox1 = new TextBox();
            tb_datetime = new TextBox();
            tb_username = new TextBox();
            panel3 = new Panel();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            comboBox3 = new ComboBox();
            pictureBox2 = new PictureBox();
            btcamout = new Button();
            panel4 = new Panel();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            tb_carplateout = new TextBox();
            tb_usernameout = new TextBox();
            tb_timeout = new TextBox();
            txt_note = new Label();
            serCOM = new System.IO.Ports.SerialPort(components);
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            Gv_history = new DataGridView();
            pictureBox6 = new PictureBox();
            textBox2 = new TextBox();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            groupBox2.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbreadcarplate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbcamerafontin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Gv_history).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Location = new Point(2337, 80);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(523, 434);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(2337, 528);
            button1.Name = "button1";
            button1.Size = new Size(523, 33);
            button1.TabIndex = 1;
            button1.Text = "Start";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(2337, 42);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(523, 33);
            comboBox1.TabIndex = 4;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(panel1);
            groupBox1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(616, 42);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(829, 983);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Car Out";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.InactiveCaption;
            panel1.Controls.Add(label8);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(pictureBox6);
            panel1.Controls.Add(pictureBox4);
            panel1.Controls.Add(pictureBox3);
            panel1.Location = new Point(19, 38);
            panel1.Name = "panel1";
            panel1.Size = new Size(786, 927);
            panel1.TabIndex = 0;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = SystemColors.ButtonHighlight;
            pictureBox4.BorderStyle = BorderStyle.Fixed3D;
            pictureBox4.Location = new Point(400, 78);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(325, 431);
            pictureBox4.TabIndex = 1;
            pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = SystemColors.ButtonHighlight;
            pictureBox3.BorderStyle = BorderStyle.Fixed3D;
            pictureBox3.Location = new Point(46, 78);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(325, 431);
            pictureBox3.TabIndex = 0;
            pictureBox3.TabStop = false;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(panel2);
            groupBox2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox2.Location = new Point(1467, 42);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(829, 983);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Car In";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.InactiveCaption;
            panel2.Controls.Add(label7);
            panel2.Controls.Add(pbreadcarplate);
            panel2.Controls.Add(comboBox2);
            panel2.Controls.Add(tb_readcarplate);
            panel2.Controls.Add(pbcamerafontin);
            panel2.Controls.Add(pictureBox5);
            panel2.Location = new Point(20, 38);
            panel2.Name = "panel2";
            panel2.Size = new Size(786, 927);
            panel2.TabIndex = 1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(51, 681);
            label7.Name = "label7";
            label7.Size = new Size(127, 38);
            label7.TabIndex = 15;
            label7.Text = "Car Plate";
            // 
            // pbreadcarplate
            // 
            pbreadcarplate.BackColor = SystemColors.ButtonHighlight;
            pbreadcarplate.BorderStyle = BorderStyle.Fixed3D;
            pbreadcarplate.Location = new Point(51, 531);
            pbreadcarplate.Name = "pbreadcarplate";
            pbreadcarplate.Size = new Size(484, 111);
            pbreadcarplate.TabIndex = 14;
            pbreadcarplate.TabStop = false;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(207, 27);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(523, 46);
            comboBox2.TabIndex = 5;
            // 
            // tb_readcarplate
            // 
            tb_readcarplate.Location = new Point(221, 674);
            tb_readcarplate.Name = "tb_readcarplate";
            tb_readcarplate.Size = new Size(314, 45);
            tb_readcarplate.TabIndex = 3;
            // 
            // pbcamerafontin
            // 
            pbcamerafontin.BackColor = SystemColors.ButtonHighlight;
            pbcamerafontin.BorderStyle = BorderStyle.Fixed3D;
            pbcamerafontin.Location = new Point(404, 78);
            pbcamerafontin.Name = "pbcamerafontin";
            pbcamerafontin.Size = new Size(325, 431);
            pbcamerafontin.TabIndex = 2;
            pbcamerafontin.TabStop = false;
            pbcamerafontin.Click += pbcamerafontin_Click;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = SystemColors.ButtonHighlight;
            pictureBox5.BorderStyle = BorderStyle.Fixed3D;
            pictureBox5.Location = new Point(51, 78);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(325, 431);
            pictureBox5.TabIndex = 1;
            pictureBox5.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(149, 68);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(371, 51);
            textBox1.TabIndex = 7;
            // 
            // tb_datetime
            // 
            tb_datetime.Location = new Point(149, 150);
            tb_datetime.Multiline = true;
            tb_datetime.Name = "tb_datetime";
            tb_datetime.Size = new Size(371, 51);
            tb_datetime.TabIndex = 8;
            // 
            // tb_username
            // 
            tb_username.Location = new Point(149, 232);
            tb_username.Multiline = true;
            tb_username.Name = "tb_username";
            tb_username.Size = new Size(371, 51);
            tb_username.TabIndex = 9;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.InactiveCaption;
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(textBox1);
            panel3.Controls.Add(tb_username);
            panel3.Controls.Add(tb_datetime);
            panel3.Location = new Point(2337, 578);
            panel3.Name = "panel3";
            panel3.Size = new Size(523, 427);
            panel3.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(3, 243);
            label3.Name = "label3";
            label3.Size = new Size(150, 38);
            label3.TabIndex = 12;
            label3.Text = "User name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(3, 162);
            label2.Name = "label2";
            label2.Size = new Size(109, 38);
            label2.TabIndex = 11;
            label2.Text = "Time In";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(3, 80);
            label1.Name = "label1";
            label1.Size = new Size(127, 38);
            label1.TabIndex = 10;
            label1.Text = "Car Plate";
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(11, 42);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(523, 33);
            comboBox3.TabIndex = 13;
            // 
            // pictureBox2
            // 
            pictureBox2.BorderStyle = BorderStyle.Fixed3D;
            pictureBox2.Location = new Point(11, 93);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(523, 434);
            pictureBox2.TabIndex = 14;
            pictureBox2.TabStop = false;
            // 
            // btcamout
            // 
            btcamout.Location = new Point(11, 533);
            btcamout.Name = "btcamout";
            btcamout.Size = new Size(523, 33);
            btcamout.TabIndex = 15;
            btcamout.Text = "Start Camera Out";
            btcamout.UseVisualStyleBackColor = true;
            btcamout.Click += btcamout_Click;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.InactiveCaption;
            panel4.Controls.Add(label4);
            panel4.Controls.Add(label5);
            panel4.Controls.Add(label6);
            panel4.Controls.Add(tb_carplateout);
            panel4.Controls.Add(tb_usernameout);
            panel4.Controls.Add(tb_timeout);
            panel4.Location = new Point(11, 578);
            panel4.Name = "panel4";
            panel4.Size = new Size(523, 427);
            panel4.TabIndex = 16;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(3, 243);
            label4.Name = "label4";
            label4.Size = new Size(150, 38);
            label4.TabIndex = 12;
            label4.Text = "User name";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(3, 162);
            label5.Name = "label5";
            label5.Size = new Size(132, 38);
            label5.TabIndex = 11;
            label5.Text = "Time Out";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(3, 80);
            label6.Name = "label6";
            label6.Size = new Size(127, 38);
            label6.TabIndex = 10;
            label6.Text = "Car Plate";
            // 
            // tb_carplateout
            // 
            tb_carplateout.Location = new Point(149, 68);
            tb_carplateout.Multiline = true;
            tb_carplateout.Name = "tb_carplateout";
            tb_carplateout.Size = new Size(371, 51);
            tb_carplateout.TabIndex = 7;
            // 
            // tb_usernameout
            // 
            tb_usernameout.Location = new Point(149, 232);
            tb_usernameout.Multiline = true;
            tb_usernameout.Name = "tb_usernameout";
            tb_usernameout.Size = new Size(371, 51);
            tb_usernameout.TabIndex = 9;
            // 
            // tb_timeout
            // 
            tb_timeout.Location = new Point(149, 150);
            tb_timeout.Multiline = true;
            tb_timeout.Name = "tb_timeout";
            tb_timeout.Size = new Size(371, 51);
            tb_timeout.TabIndex = 8;
            // 
            // txt_note
            // 
            txt_note.AutoSize = true;
            txt_note.BackColor = Color.Lime;
            txt_note.Font = new Font("Segoe UI", 25F, FontStyle.Regular, GraphicsUnit.Point);
            txt_note.Location = new Point(2529, 1756);
            txt_note.Name = "txt_note";
            txt_note.Size = new Size(328, 67);
            txt_note.TabIndex = 17;
            txt_note.Text = "DISCONNECT";
            txt_note.Click += txt_note_Click;
            // 
            // serCOM
            // 
            this.serCOM.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serCOM_DataReceived);
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // Gv_history
            // 
            Gv_history.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Gv_history.Location = new Point(14, 1148);
            Gv_history.Name = "Gv_history";
            Gv_history.RowHeadersWidth = 62;
            Gv_history.RowTemplate.Height = 33;
            Gv_history.Size = new Size(2843, 411);
            Gv_history.TabIndex = 18;
            // 
            // pictureBox6/*/*/*/*/*/*/**/*/*/*/*/*/*/
            // 
            pictureBox6.BackColor = SystemColors.ButtonHighlight;
            pictureBox6.BorderStyle = BorderStyle.Fixed3D;
            pictureBox6.Location = new Point(241, 531);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(484, 111);
            pictureBox6.TabIndex = 15;
            pictureBox6.TabStop = false;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(411, 674);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(314, 45);
            textBox2.TabIndex = 16;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(241, 677);
            label8.Name = "label8";
            label8.Size = new Size(127, 38);
            label8.TabIndex = 17;
            label8.Text = "Car Plate";
            // 
            // home
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2931, 1832);
            Controls.Add(Gv_history);
            Controls.Add(txt_note);
            Controls.Add(panel4);
            Controls.Add(btcamout);
            Controls.Add(pictureBox2);
            Controls.Add(comboBox3);
            Controls.Add(panel3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(comboBox1);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Name = "home";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            groupBox2.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbreadcarplate).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbcamerafontin).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Gv_history).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button button1;
        private ComboBox comboBox1;
        private GroupBox groupBox1;
        private Panel panel1;
        private GroupBox groupBox2;
        private Panel panel2;
        private TextBox textBox1;
        private TextBox tb_datetime;
        private TextBox tb_username;
        private Panel panel3;
        private Label label1;
        private Label label3;
        private Label label2;
        private ComboBox comboBox3;
        private PictureBox pictureBox2;
        private Button btcamout;
        private Panel panel4;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox tb_carplateout;
        private TextBox tb_usernameout;
        private TextBox tb_timeout;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private PictureBox pbcamerafontin;
        private PictureBox pictureBox5;
        private TextBox tb_readcarplate;
        private ComboBox comboBox2;
        private PictureBox pbreadcarplate;
        private Label txt_note;
        private System.IO.Ports.SerialPort serCOM;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private Label label7;
        private DataGridView Gv_history;
        private Label label8;
        private TextBox textBox2;
        private PictureBox pictureBox6;
    }
}