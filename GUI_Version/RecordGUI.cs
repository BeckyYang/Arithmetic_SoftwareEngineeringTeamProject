/*--------------------
功能：历史记录界面
作者：杨冰琪、谢蜜雪
日期：2019.01.15
--------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArithmeticGUI
{
    public partial class RecordGUI : Form
    {
        public RecordGUI()
        {
            InitializeComponent();
            tb_record.Text = null;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }

         private void btn_q_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you sure to leave?", "Exit Confirm", MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
            else { }
        }
        
        private void btn_query_Click(object sender, EventArgs e)
        {
            
            lab_user_name.Text = MainGUI.user_name;
            lab_score.Text = Convert.ToString(PuzzlesGUI.score);
            if(PuzzlesGUI.History[0] == null)
            {
                MessageBox.Show("You hanven't done questions yet!");
            }
            for(int i = 0; i < PuzzlesGUI .History.Length ; i++)
            {
                tb_record.Text += PuzzlesGUI.History[i];
            }            
        }
    }
}
