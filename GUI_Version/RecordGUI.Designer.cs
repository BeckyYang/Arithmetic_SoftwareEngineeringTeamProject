namespace ArithmeticGUI
{
    partial class RecordGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecordGUI));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lab_score = new System.Windows.Forms.Label();
            this.lab_score_title = new System.Windows.Forms.Label();
            this.lab_user_name = new System.Windows.Forms.Label();
            this.lab_name = new System.Windows.Forms.Label();
            this.btn_query = new System.Windows.Forms.Button();
            this.btn_q = new System.Windows.Forms.Button();
            this.tb_record = new System.Windows.Forms.TextBox();
            this.lab_userID = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.lab_score);
            this.groupBox1.Controls.Add(this.lab_score_title);
            this.groupBox1.Controls.Add(this.lab_user_name);
            this.groupBox1.Controls.Add(this.lab_name);
            this.groupBox1.Controls.Add(this.btn_query);
            this.groupBox1.Controls.Add(this.btn_q);
            this.groupBox1.Controls.Add(this.tb_record);
            this.groupBox1.Controls.Add(this.lab_userID);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.Color.SandyBrown;
            this.groupBox1.Location = new System.Drawing.Point(9, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(696, 335);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "History Record";
            // 
            // lab_score
            // 
            this.lab_score.AutoSize = true;
            this.lab_score.ForeColor = System.Drawing.Color.Crimson;
            this.lab_score.Location = new System.Drawing.Point(341, 25);
            this.lab_score.Name = "lab_score";
            this.lab_score.Size = new System.Drawing.Size(20, 19);
            this.lab_score.TabIndex = 7;
            this.lab_score.Text = "0";
            // 
            // lab_score_title
            // 
            this.lab_score_title.AutoSize = true;
            this.lab_score_title.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lab_score_title.Location = new System.Drawing.Point(264, 25);
            this.lab_score_title.Name = "lab_score_title";
            this.lab_score_title.Size = new System.Drawing.Size(77, 21);
            this.lab_score_title.TabIndex = 6;
            this.lab_score_title.Text = "Score:";
            // 
            // lab_user_name
            // 
            this.lab_user_name.AutoSize = true;
            this.lab_user_name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lab_user_name.ForeColor = System.Drawing.Color.Violet;
            this.lab_user_name.Location = new System.Drawing.Point(106, 25);
            this.lab_user_name.Name = "lab_user_name";
            this.lab_user_name.Size = new System.Drawing.Size(33, 21);
            this.lab_user_name.TabIndex = 5;
            this.lab_user_name.Text = "  ";
            // 
            // lab_name
            // 
            this.lab_name.AutoSize = true;
            this.lab_name.Location = new System.Drawing.Point(106, 25);
            this.lab_name.Name = "lab_name";
            this.lab_name.Size = new System.Drawing.Size(0, 19);
            this.lab_name.TabIndex = 4;
            // 
            // btn_query
            // 
            this.btn_query.BackColor = System.Drawing.Color.DimGray;
            this.btn_query.ForeColor = System.Drawing.Color.Linen;
            this.btn_query.Location = new System.Drawing.Point(521, 18);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(72, 33);
            this.btn_query.TabIndex = 3;
            this.btn_query.Text = "Query";
            this.btn_query.UseVisualStyleBackColor = false;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // btn_q
            // 
            this.btn_q.BackColor = System.Drawing.Color.DimGray;
            this.btn_q.ForeColor = System.Drawing.Color.Linen;
            this.btn_q.Location = new System.Drawing.Point(615, 18);
            this.btn_q.Name = "btn_q";
            this.btn_q.Size = new System.Drawing.Size(66, 33);
            this.btn_q.TabIndex = 2;
            this.btn_q.Text = "Quit";
            this.btn_q.UseVisualStyleBackColor = false;
            this.btn_q.Click += new System.EventHandler(this.btn_q_Click);
            // 
            // tb_record
            // 
            this.tb_record.BackColor = System.Drawing.Color.LightBlue;
            this.tb_record.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_record.ForeColor = System.Drawing.Color.LightCoral;
            this.tb_record.Location = new System.Drawing.Point(11, 67);
            this.tb_record.Multiline = true;
            this.tb_record.Name = "tb_record";
            this.tb_record.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tb_record.Size = new System.Drawing.Size(679, 256);
            this.tb_record.TabIndex = 1;
            this.tb_record.WordWrap = false;
            // 
            // lab_userID
            // 
            this.lab_userID.AutoSize = true;
            this.lab_userID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lab_userID.Location = new System.Drawing.Point(19, 25);
            this.lab_userID.Name = "lab_userID";
            this.lab_userID.Size = new System.Drawing.Size(88, 21);
            this.lab_userID.TabIndex = 0;
            this.lab_userID.Text = "UserID:";
            // 
            // RecordGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(728, 368);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RecordGUI";
            this.Text = "RecordGUI";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lab_userID;
        private System.Windows.Forms.TextBox tb_record;
        private System.Windows.Forms.Button btn_q;
        private System.Windows.Forms.Button btn_query;
        private System.Windows.Forms.Label lab_name;
        private System.Windows.Forms.Label lab_user_name;
        private System.Windows.Forms.Label lab_score;
        private System.Windows.Forms.Label lab_score_title;
    }
}