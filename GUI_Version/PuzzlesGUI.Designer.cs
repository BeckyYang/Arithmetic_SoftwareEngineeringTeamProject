namespace ArithmeticGUI
{
    partial class PuzzlesGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PuzzlesGUI));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lab_s = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lab_left_num = new System.Windows.Forms.Label();
            this.lab_qnum = new System.Windows.Forms.Label();
            this.lab_count = new System.Windows.Forms.Label();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lab_time_num = new System.Windows.Forms.Label();
            this.lab_timer = new System.Windows.Forms.Label();
            this.btn_ok = new System.Windows.Forms.Button();
            this.tb_answer = new System.Windows.Forms.TextBox();
            this.lab_input_answer = new System.Windows.Forms.Label();
            this.lab_puzzle = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.lab_count);
            this.groupBox1.Controls.Add(this.btn_cancel);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btn_ok);
            this.groupBox1.Controls.Add(this.tb_answer);
            this.groupBox1.Controls.Add(this.lab_input_answer);
            this.groupBox1.Controls.Add(this.lab_puzzle);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.Color.SandyBrown;
            this.groupBox1.Location = new System.Drawing.Point(7, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(825, 285);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Question";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lab_s);
            this.groupBox4.ForeColor = System.Drawing.Color.SandyBrown;
            this.groupBox4.Location = new System.Drawing.Point(542, 169);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(107, 116);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Score";
            // 
            // lab_s
            // 
            this.lab_s.AutoSize = true;
            this.lab_s.ForeColor = System.Drawing.Color.OrangeRed;
            this.lab_s.Location = new System.Drawing.Point(37, 56);
            this.lab_s.Name = "lab_s";
            this.lab_s.Size = new System.Drawing.Size(20, 19);
            this.lab_s.TabIndex = 0;
            this.lab_s.Text = "0";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lab_left_num);
            this.groupBox3.Controls.Add(this.lab_qnum);
            this.groupBox3.ForeColor = System.Drawing.Color.SandyBrown;
            this.groupBox3.Location = new System.Drawing.Point(655, 168);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(174, 117);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Question Left";
            // 
            // lab_left_num
            // 
            this.lab_left_num.AutoSize = true;
            this.lab_left_num.ForeColor = System.Drawing.Color.Peru;
            this.lab_left_num.Location = new System.Drawing.Point(64, 57);
            this.lab_left_num.Name = "lab_left_num";
            this.lab_left_num.Size = new System.Drawing.Size(20, 19);
            this.lab_left_num.TabIndex = 7;
            this.lab_left_num.Text = "0";
            // 
            // lab_qnum
            // 
            this.lab_qnum.AutoSize = true;
            this.lab_qnum.Location = new System.Drawing.Point(16, 25);
            this.lab_qnum.Name = "lab_qnum";
            this.lab_qnum.Size = new System.Drawing.Size(0, 19);
            this.lab_qnum.TabIndex = 6;
            // 
            // lab_count
            // 
            this.lab_count.AutoSize = true;
            this.lab_count.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_count.ForeColor = System.Drawing.Color.SandyBrown;
            this.lab_count.Location = new System.Drawing.Point(5, 84);
            this.lab_count.Name = "lab_count";
            this.lab_count.Size = new System.Drawing.Size(42, 22);
            this.lab_count.TabIndex = 5;
            this.lab_count.Text = "NO.";
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.DimGray;
            this.btn_cancel.ForeColor = System.Drawing.Color.Linen;
            this.btn_cancel.Location = new System.Drawing.Point(249, 225);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(102, 34);
            this.btn_cancel.TabIndex = 4;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lab_time_num);
            this.groupBox2.Controls.Add(this.lab_timer);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(542, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(283, 61);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // lab_time_num
            // 
            this.lab_time_num.AutoSize = true;
            this.lab_time_num.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_time_num.ForeColor = System.Drawing.Color.IndianRed;
            this.lab_time_num.Location = new System.Drawing.Point(151, 25);
            this.lab_time_num.Name = "lab_time_num";
            this.lab_time_num.Size = new System.Drawing.Size(86, 19);
            this.lab_time_num.TabIndex = 0;
            this.lab_time_num.Text = "seconds";
            // 
            // lab_timer
            // 
            this.lab_timer.AutoSize = true;
            this.lab_timer.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_timer.ForeColor = System.Drawing.Color.Moccasin;
            this.lab_timer.Location = new System.Drawing.Point(16, 25);
            this.lab_timer.Name = "lab_timer";
            this.lab_timer.Size = new System.Drawing.Size(141, 19);
            this.lab_timer.TabIndex = 0;
            this.lab_timer.Text = "Pour Timer: ";
            // 
            // btn_ok
            // 
            this.btn_ok.BackColor = System.Drawing.Color.DimGray;
            this.btn_ok.ForeColor = System.Drawing.Color.Linen;
            this.btn_ok.Location = new System.Drawing.Point(25, 225);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(102, 34);
            this.btn_ok.TabIndex = 3;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = false;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // tb_answer
            // 
            this.tb_answer.Location = new System.Drawing.Point(156, 158);
            this.tb_answer.Name = "tb_answer";
            this.tb_answer.Size = new System.Drawing.Size(195, 29);
            this.tb_answer.TabIndex = 2;
            this.tb_answer.Tag = "Input your answer";
            // 
            // lab_input_answer
            // 
            this.lab_input_answer.AutoSize = true;
            this.lab_input_answer.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_input_answer.ForeColor = System.Drawing.Color.SandyBrown;
            this.lab_input_answer.Location = new System.Drawing.Point(9, 161);
            this.lab_input_answer.Name = "lab_input_answer";
            this.lab_input_answer.Size = new System.Drawing.Size(141, 19);
            this.lab_input_answer.TabIndex = 1;
            this.lab_input_answer.Text = "Your Answer:";
            // 
            // lab_puzzle
            // 
            this.lab_puzzle.AutoSize = true;
            this.lab_puzzle.BackColor = System.Drawing.Color.MistyRose;
            this.lab_puzzle.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_puzzle.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lab_puzzle.Location = new System.Drawing.Point(71, 84);
            this.lab_puzzle.Name = "lab_puzzle";
            this.lab_puzzle.Size = new System.Drawing.Size(79, 23);
            this.lab_puzzle.TabIndex = 0;
            this.lab_puzzle.Text = "1+1+1=?";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // PuzzlesGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(854, 303);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PuzzlesGUI";
            this.Text = "PuzzlesGUI";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.TextBox tb_answer;
        private System.Windows.Forms.Label lab_input_answer;
        private System.Windows.Forms.Label lab_puzzle;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lab_time_num;
        private System.Windows.Forms.Label lab_timer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lab_qnum;
        private System.Windows.Forms.Label lab_count;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lab_left_num;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lab_s;
    }
}