/*--------------------
功能：用户主界面入口
作者：杨冰琪
日期：2019.01.14
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
    public partial class MainInterface : Form
    {
        public MainInterface()
        {
            InitializeComponent();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }

        private void MainInterface_Load(object sender, EventArgs e)
        {

        }
        public static MainGUI mainGUI = new MainGUI();
        private void btn_main_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            mainGUI.ShowDialog();            
        }
    }
}
