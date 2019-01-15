/*--------------------
功能：用户主界面
作者：杨冰琪、谢蜜雪
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
    public partial class MainGUI : Form
    {
        public MainGUI()
        {
            InitializeComponent();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }
       
        public static string user_name;
        public static string[] puzzle_str = new string[1000];//存放生成的题目
        public static int[,] puzzle_int = new int[1000, 200]; //存放表达式的整数表达形式
        N_Puzzle n_puzzle = new N_Puzzle();
        public static int[,] answer_int = new int[1000, 3];
        public static string[] answer_str = new string[1000];//存放计算结果
        public static int num = 0;
        public static char type = 'A';
        public bool CheckN = true;
        //---------获取用户选择的乘方模式，如不选择，默认为 A--------
        public void ChooseModel()
        {
            
            if (rbtn_A.Checked)
            {
                type = 'A';
            }
            else if (rbtn_B.Checked)
            {
                type = 'B';
            }
            else if (rbtn_C.Checked)
            {
                type = 'C';
            }

        }
        //---------检查输入是否合法---------
        void CheckInput(string N)
        {
            CheckN = true;
            for (int i = 0; i < N.Length; i++)
            {
                if (N[i] < '0' || N[i] > '9')
                {
                    CheckN = false;
                    break;
                }
            }
           
        }
        //--------------开始答题-----------
        private void btn_begin_Click(object sender, EventArgs e)
        {
            //将上一次的历史记录清空
            for (int i = 0; i< PuzzlesGUI.History.Length; i++)
            {
                PuzzlesGUI.History[i] = "";
            }
            PuzzlesGUI.score = 0;//清空上次答题分数
            tb_num.Focus();//鼠标自动定位到输入题目数的文本框
            num = 0;
            string N;
            user_name = tb_ID.Text;//获取用户输入
            N = tb_num.Text;

            //-------------检查输入是否合法 + 选择乘方模式-------------------
            CheckInput(N);            
            ChooseModel();
            
            if(user_name.Length == 0)
            {
                MessageBox.Show("Please enter your ID.");
            }
            else if(N.Length == 0 || N == "0")
            {
                MessageBox.Show("Please enter the number of puzzles.");
            }
            else if(N.Length >= 4 && N!= "1000")//保证题目数小于等于1000
            {
                MessageBox.Show("Number is too big!");
            }
            else if (CheckN == false)
            {
                MessageBox.Show("Error Input!\nPlease enter correct number.");
                tb_num.Text = null;
            }
            else if(CheckN == true)
            {
                num = Convert.ToInt32(N);
                //---------生成num道题目------------------- 
                n_puzzle.PuzzleGenerate(num, type);

                //----------弹出PuzzleGUI------------------
                this.Visible = false;
                PuzzlesGUI Puzzle = new PuzzlesGUI();
                Puzzle.ShowDialog();
                this.Visible = true;
            }
            
        }
       //------------------查看历史记录-----------
        private void btn_record_Click(object sender, EventArgs e)
        {
            if(tb_ID.Text == "")
            {
                MessageBox.Show("Please enter your ID.");
            }
            else
            {
                this.Visible = false;
                tb_num.Focus();
                user_name = tb_ID.Text;
                RecordGUI Record = new RecordGUI();
                Record.ShowDialog();
                this.Visible = true;
                tb_num.Text = null;
                tb_num.Focus();
            }
            
        }
        //--------------------退出---------------
        private void btn_quit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you sure to exit?", "Exit Confirm", MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning);
            if(dr == DialogResult.Yes)
            {
                Application.Exit();
            }
            else { }
        }
    }
}
