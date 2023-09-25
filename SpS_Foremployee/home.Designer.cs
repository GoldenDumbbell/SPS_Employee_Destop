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
            System.Text.ASCIIEncoding asciiEncodingSealed1 = new System.Text.ASCIIEncoding();
            System.Text.DecoderReplacementFallback decoderReplacementFallback1 = new System.Text.DecoderReplacementFallback();
            System.Text.EncoderReplacementFallback encoderReplacementFallback1 = new System.Text.EncoderReplacementFallback();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            comboBox1 = new ComboBox();
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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Gv_history).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Location = new Point(1654, 117);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(523, 434);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(1654, 565);
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
            comboBox1.Location = new Point(1654, 79);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(523, 33);
            comboBox1.TabIndex = 4;
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
            panel3.Location = new Point(1654, 615);
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
            comboBox3.Location = new Point(677, 66);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(523, 33);
            comboBox3.TabIndex = 13;
            // 
            // pictureBox2
            // 
            pictureBox2.BorderStyle = BorderStyle.Fixed3D;
            pictureBox2.Location = new Point(677, 117);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(523, 434);
            pictureBox2.TabIndex = 14;
            pictureBox2.TabStop = false;
            // 
            // btcamout
            // 
            btcamout.Location = new Point(677, 557);
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
            panel4.Location = new Point(677, 602);
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
            serCOM.BaudRate = 9600;
            serCOM.DataBits = 8;
            serCOM.DiscardNull = false;
            serCOM.DtrEnable = false;
            asciiEncodingSealed1.DecoderFallback = decoderReplacementFallback1;
            asciiEncodingSealed1.EncoderFallback = encoderReplacementFallback1;
            serCOM.Encoding = asciiEncodingSealed1;
            serCOM.Handshake = System.IO.Ports.Handshake.None;
            serCOM.NewLine = "\n";
            serCOM.Parity = System.IO.Ports.Parity.None;
            serCOM.ParityReplace = 63;
            serCOM.PortName = "COM1";
            serCOM.ReadBufferSize = 4096;
            serCOM.ReadTimeout = -1;
            serCOM.ReceivedBytesThreshold = 1;
            serCOM.RtsEnable = false;
            serCOM.StopBits = System.IO.Ports.StopBits.One;
            serCOM.WriteBufferSize = 2048;
            serCOM.WriteTimeout = -1;
            serCOM.DataReceived += serCOM_DataReceived;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // Gv_history
            // 
            Gv_history.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Gv_history.Location = new Point(677, 1148);
            Gv_history.Name = "Gv_history";
            Gv_history.RowHeadersWidth = 62;
            Gv_history.RowTemplate.Height = 33;
            Gv_history.Size = new Size(1500, 411);
            Gv_history.TabIndex = 18;
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
            Controls.Add(comboBox1);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Name = "home";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Gv_history).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button button1;
        private ComboBox comboBox1;
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
        private Label txt_note;
        private System.IO.Ports.SerialPort serCOM;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private DataGridView Gv_history;
    }
}