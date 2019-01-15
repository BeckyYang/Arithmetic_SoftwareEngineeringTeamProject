namespace ArithmeticGUI
{
    partial class MainInterface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainInterface));
            this.btn_main = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lab_date = new System.Windows.Forms.Label();
            this.lab_title = new System.Windows.Forms.Label();
            this.lab_wel = new System.Windows.Forms.Label();
            this.groupbox1 = new System.Windows.Forms.GroupBox();
            this.groupbox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_main
            // 
            this.btn_main.BackColor = System.Drawing.Color.LightCyan;
            this.btn_main.Font = new System.Drawing.Font("楷体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_main.ForeColor = System.Drawing.Color.RosyBrown;
            this.btn_main.Location = new System.Drawing.Point(41, 152);
            this.btn_main.Name = "btn_main";
            this.btn_main.Size = new System.Drawing.Size(145, 62);
            this.btn_main.TabIndex = 1;
            this.btn_main.Tag = "点击进入答题系统";
            this.btn_main.Text = "开始";
            this.btn_main.UseVisualStyleBackColor = false;
            this.btn_main.Click += new System.EventHandler(this.btn_main_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.CadetBlue;
            this.label1.Location = new System.Drawing.Point(6, 277);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "开发者：谢蜜雪、杨冰琪";
            // 
            // lab_date
            // 
            this.lab_date.AutoSize = true;
            this.lab_date.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_date.ForeColor = System.Drawing.Color.CadetBlue;
            this.lab_date.Location = new System.Drawing.Point(6, 307);
            this.lab_date.Name = "lab_date";
            this.lab_date.Size = new System.Drawing.Size(219, 19);
            this.lab_date.TabIndex = 3;
            this.lab_date.Text = "完成日期：2019.01.17";
            // 
            // lab_title
            // 
            this.lab_title.AutoSize = true;
            this.lab_title.Font = new System.Drawing.Font("楷体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_title.ForeColor = System.Drawing.Color.Salmon;
            this.lab_title.Location = new System.Drawing.Point(-2, 93);
            this.lab_title.Name = "lab_title";
            this.lab_title.Size = new System.Drawing.Size(296, 33);
            this.lab_title.TabIndex = 0;
            this.lab_title.Text = "四则运算答题挑战!";
            // 
            // lab_wel
            // 
            this.lab_wel.AutoSize = true;
            this.lab_wel.Font = new System.Drawing.Font("楷体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_wel.ForeColor = System.Drawing.Color.Salmon;
            this.lab_wel.Location = new System.Drawing.Point(35, 37);
            this.lab_wel.Name = "lab_wel";
            this.lab_wel.Size = new System.Drawing.Size(147, 33);
            this.lab_wel.TabIndex = 1;
            this.lab_wel.Text = "欢迎来到";
            // 
            // groupbox1
            // 
            this.groupbox1.BackColor = System.Drawing.Color.Transparent;
            this.groupbox1.Controls.Add(this.lab_date);
            this.groupbox1.Controls.Add(this.lab_wel);
            this.groupbox1.Controls.Add(this.label1);
            this.groupbox1.Controls.Add(this.lab_title);
            this.groupbox1.Controls.Add(this.btn_main);
            this.groupbox1.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupbox1.Location = new System.Drawing.Point(14, 0);
            this.groupbox1.Name = "groupbox1";
            this.groupbox1.Size = new System.Drawing.Size(693, 518);
            this.groupbox1.TabIndex = 0;
            this.groupbox1.TabStop = false;
            // 
            // MainInterface
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(719, 530);
            this.Controls.Add(this.groupbox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainInterface";
            this.Tag = "";
            this.Text = "MainInterface";
            this.Load += new System.EventHandler(this.MainInterface_Load);
            this.groupbox1.ResumeLayout(false);
            this.groupbox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_main;
        private System.Windows.Forms.Label lab_date;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lab_title;
        private System.Windows.Forms.Label lab_wel;
        private System.Windows.Forms.GroupBox groupbox1;
    }
}