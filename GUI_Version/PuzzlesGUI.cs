/*--------------------
功能：实现答题界面
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
using System.IO;

namespace ArithmeticGUI
{
    public partial class PuzzlesGUI : Form
    {
        public int seconds = 20;
        public static string userAnswer;
        public static string result;
        public static string[] History = new string[1000];
        public static int current = 0;
        public static int score = 0;
        public static bool IsTrue = false;       
        
        public PuzzlesGUI()
        {

            InitializeComponent();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            lab_puzzle.Text = null;
            lab_puzzle.Text = MainGUI.puzzle_str[current];
            lab_count.Text = "No." + current;            
            lab_left_num.Text = Convert.ToString(MainGUI.num - current);
        }
        
        private void PuzzlesGUI_Load(object sender,EventArgs e)
        {
           
        }

        //--------------将计算结果转换为真分数-----------
        public void ToTrueFraction(string Question)
        {
            int numerator = 0;
            int denominator = 0;
            int i = 0;
            string sym = null;
            if (Question[0] == '-')
            {
                sym = "-";
                i++;//如果结果为负数，从第二位开始是数字
            }
            else
            { }

            for (; i < Question.Length && Question[i] != '/'; i++)
            {
                numerator *= 10;
                numerator += Question[i] - '0';
            }
            if (i == Question.Length)
            {
                result = Question;
                return;
            }
            else
            {
                i++;//略掉除号
                for (; i < Question.Length; i++)
                {
                    denominator *= 10;
                    denominator += Question[i] - '0';
                }
                int temp = numerator / denominator;
                if (temp == 0)
                {
                    result = Question;
                    return;
                }
                else
                {
                    numerator = numerator % denominator;
                    result = Convert.ToString(numerator) + "/" + Convert.ToString(denominator);
                    if (sym == "-")
                    {
                        result = "-" + Convert.ToString(temp) + "-" + result;
                    }
                    else
                    {
                        result = Convert.ToString(temp) + "+" + result;
                    }
                }
            }


        }
        
        //--------------核对答案-----------------------
        public void CheckAnswer()
        {
            if(userAnswer == result)
            {
                MessageBox.Show(" Right!");
                IsTrue = true;
                score += 1;
                lab_s.Text = Convert.ToString(score);
            }
            else
            {
                MessageBox.Show("Wrong! \nThis is correct answer: " + result + "\nYour Answer:" + userAnswer );
                IsTrue = false;
            }

        }
        //--------------------------------------

        //-------------倒计时--------------------------------
        private void timer1_Tick(object sender, EventArgs e)
        {
            lab_time_num.Text = (seconds--).ToString() + " seconds";

            if (seconds == -1)//超时后弹出提示窗口，更新题目、题号、剩余题目数,,清空答案输入框，进入下一轮计时
            {
                timer1.Stop();
                lab_time_num.Visible = false;//倒计时显示关闭
                MessageBox.Show("Time Out!");
                lab_puzzle.Text = MainGUI.puzzle_str[++current];
                lab_count.Text = "No." + current; 
                lab_left_num.Text = lab_left_num.Text = Convert.ToString(MainGUI.num - current);
                tb_answer.Text = null;
                seconds = 20;
                timer1.Start();
                lab_time_num.Text = (seconds--).ToString() + " seconds";
                lab_time_num.Visible = true; //倒计时显示打开
            }
        }
        //-------------退出--------------
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            DialogResult dr = MessageBox.Show("Do you sure to leave?", "Exit Confirm", MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                MainGUI.tb_num.Text = null;
                current = 0;//退出答题界面，题号重置为零
                this.Close();

            }
            else
            {
                timer1.Start();
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            tb_answer.Focus();
            timer1.Stop();//停止计时
            userAnswer = this.tb_answer.Text;//获取用户的输入
            ToTrueFraction(MainGUI.answer_str[current]);//调用存储的计算结果
           
            CheckAnswer();//核对用户答案
            this.tb_answer.Text = "";//将输入框清空
            History[current] = "NO." + current + ": " + MainGUI.puzzle_str[current] + Environment.NewLine 
                                + Environment.NewLine + IsTrue
                                + "  UserAnswer: " + userAnswer
                                + "  CorrectAnswer: " + result
                                + Environment.NewLine + Environment.NewLine;
                                //传递答题数据到历史记录
            lab_puzzle.Text = MainGUI.puzzle_str[++current];//更新PuzzleGUI的题目显示
            seconds = 20;//重置计时时间
            timer1.Start();//进行下一轮计时
            lab_count.Text = "No." + current;//更新题号
            IsTrue = false;
            lab_left_num.Text = Convert.ToString(MainGUI.num - current);
            if (current == MainGUI .num)//题目做完后，退出答题界面
            {
                timer1.Stop();
                current = 0;  //重置
                MainGUI.tb_num.Text = null;
                MessageBox.Show("All questions are completed!");
                this.Close();
            }
        }
    }
}
