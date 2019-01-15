namespace ArithmeticGUI
{
    partial class MainGUI
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGUI));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtn_C = new System.Windows.Forms.RadioButton();
            this.rbtn_B = new System.Windows.Forms.RadioButton();
            this.rbtn_A = new System.Windows.Forms.RadioButton();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btn_quit = new System.Windows.Forms.Button();
            this.btn_record = new System.Windows.Forms.Button();
            this.btn_begin = new System.Windows.Forms.Button();
            this.lab_top = new System.Windows.Forms.Label();
            tb_num = new System.Windows.Forms.TextBox();
            this.lab_num = new System.Windows.Forms.Label();
            this.tb_ID = new System.Windows.Forms.TextBox();
            this.lab_ID = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.btn_quit);
            this.groupBox1.Controls.Add(this.btn_record);
            this.groupBox1.Controls.Add(this.btn_begin);
            this.groupBox1.Controls.Add(this.lab_top);
            this.groupBox1.Controls.Add(tb_num);
            this.groupBox1.Controls.Add(this.lab_num);
            this.groupBox1.Controls.Add(this.tb_ID);
            this.groupBox1.Controls.Add(this.lab_ID);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.Color.LightCoral;
            this.groupBox1.Location = new System.Drawing.Point(5, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(505, 392);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtn_C);
            this.groupBox2.Controls.Add(this.rbtn_B);
            this.groupBox2.Controls.Add(this.rbtn_A);
            this.groupBox2.ForeColor = System.Drawing.Color.DarkCyan;
            this.groupBox2.Location = new System.Drawing.Point(6, 180);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(471, 121);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Power Model";
            // 
            // rbtn_C
            // 
            this.rbtn_C.AutoSize = true;
            this.rbtn_C.Location = new System.Drawing.Point(360, 61);
            this.rbtn_C.Name = "rbtn_C";
            this.rbtn_C.Size = new System.Drawing.Size(71, 23);
            this.rbtn_C.TabIndex = 12;
            this.rbtn_C.TabStop = true;
            this.rbtn_C.Text = "C.**";
            this.rbtn_C.UseVisualStyleBackColor = true;
            // 
            // rbtn_B
            // 
            this.rbtn_B.AutoSize = true;
            this.rbtn_B.Location = new System.Drawing.Point(212, 61);
            this.rbtn_B.Name = "rbtn_B";
            this.rbtn_B.Size = new System.Drawing.Size(60, 23);
            this.rbtn_B.TabIndex = 11;
            this.rbtn_B.TabStop = true;
            this.rbtn_B.Text = "B.^";
            this.rbtn_B.UseVisualStyleBackColor = true;
            // 
            // rbtn_A
            // 
            this.rbtn_A.AutoSize = true;
            this.rbtn_A.Location = new System.Drawing.Point(10, 61);
            this.rbtn_A.Name = "rbtn_A";
            this.rbtn_A.Size = new System.Drawing.Size(137, 23);
            this.rbtn_A.TabIndex = 10;
            this.rbtn_A.TabStop = true;
            this.rbtn_A.Text = "A.No Power";
            this.rbtn_A.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarForeColor = System.Drawing.Color.Yellow;
            this.dateTimePicker1.CalendarTitleForeColor = System.Drawing.SystemColors.HotTrack;
            this.dateTimePicker1.Location = new System.Drawing.Point(143, 18);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(205, 29);
            this.dateTimePicker1.TabIndex = 8;
            // 
            // btn_quit
            // 
            this.btn_quit.BackColor = System.Drawing.Color.DimGray;
            this.btn_quit.ForeColor = System.Drawing.SystemColors.Info;
            this.btn_quit.Location = new System.Drawing.Point(376, 339);
            this.btn_quit.Name = "btn_quit";
            this.btn_quit.Size = new System.Drawing.Size(89, 34);
            this.btn_quit.TabIndex = 7;
            this.btn_quit.Text = "Quit";
            this.btn_quit.UseVisualStyleBackColor = false;
            this.btn_quit.Click += new System.EventHandler(this.btn_quit_Click);
            // 
            // btn_record
            // 
            this.btn_record.BackColor = System.Drawing.Color.DimGray;
            this.btn_record.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_record.Location = new System.Drawing.Point(206, 339);
            this.btn_record.Name = "btn_record";
            this.btn_record.Size = new System.Drawing.Size(89, 34);
            this.btn_record.TabIndex = 6;
            this.btn_record.Text = "Record";
            this.btn_record.UseVisualStyleBackColor = false;
            this.btn_record.Click += new System.EventHandler(this.btn_record_Click);
            // 
            // btn_begin
            // 
            this.btn_begin.BackColor = System.Drawing.Color.DimGray;
            this.btn_begin.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_begin.ForeColor = System.Drawing.SystemColors.Info;
            this.btn_begin.Location = new System.Drawing.Point(16, 339);
            this.btn_begin.Name = "btn_begin";
            this.btn_begin.Size = new System.Drawing.Size(89, 34);
            this.btn_begin.TabIndex = 5;
            this.btn_begin.Text = "Begin";
            this.btn_begin.UseVisualStyleBackColor = false;
            this.btn_begin.Click += new System.EventHandler(this.btn_begin_Click);
            // 
            // lab_top
            // 
            this.lab_top.AutoSize = true;
            this.lab_top.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_top.ForeColor = System.Drawing.Color.SlateBlue;
            this.lab_top.Location = new System.Drawing.Point(189, 65);
            this.lab_top.Name = "lab_top";
            this.lab_top.Size = new System.Drawing.Size(106, 21);
            this.lab_top.TabIndex = 4;
            this.lab_top.Text = "Welcome!";
            // 
            // tb_num
            // 
            tb_num.Location = new System.Drawing.Point(366, 111);
            tb_num.Name = "tb_num";
            tb_num.Size = new System.Drawing.Size(87, 29);
            tb_num.TabIndex = 3;
            // 
            // lab_num
            // 
            this.lab_num.AutoSize = true;
            this.lab_num.ForeColor = System.Drawing.Color.Peru;
            this.lab_num.Location = new System.Drawing.Point(239, 121);
            this.lab_num.Name = "lab_num";
            this.lab_num.Size = new System.Drawing.Size(119, 19);
            this.lab_num.TabIndex = 2;
            this.lab_num.Text = "N_Puzzles:";
            // 
            // tb_ID
            // 
            this.tb_ID.Location = new System.Drawing.Point(68, 111);
            this.tb_ID.Name = "tb_ID";
            this.tb_ID.Size = new System.Drawing.Size(96, 29);
            this.tb_ID.TabIndex = 1;
            // 
            // lab_ID
            // 
            this.lab_ID.AutoSize = true;
            this.lab_ID.ForeColor = System.Drawing.Color.Peru;
            this.lab_ID.Location = new System.Drawing.Point(23, 121);
            this.lab_ID.Name = "lab_ID";
            this.lab_ID.Size = new System.Drawing.Size(42, 19);
            this.lab_ID.TabIndex = 0;
            this.lab_ID.Text = "ID:";
            // 
            // MainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(522, 402);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainGUI";
            this.Text = "Arithmetic";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_quit;
        private System.Windows.Forms.Button btn_record;
        private System.Windows.Forms.Button btn_begin;
        private System.Windows.Forms.Label lab_top;
        private System.Windows.Forms.Label lab_num;
        private System.Windows.Forms.TextBox tb_ID;
        private System.Windows.Forms.Label lab_ID;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbtn_C;
        private System.Windows.Forms.RadioButton rbtn_B;
        private System.Windows.Forms.RadioButton rbtn_A;
        public static System.Windows.Forms.TextBox tb_num;
    }
}

