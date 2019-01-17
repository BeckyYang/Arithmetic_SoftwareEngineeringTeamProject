/*--------------------
功能：生成题目
作者：谢蜜雪
日期：2019.01.14
--------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticGUI
{
    public partial class N_Puzzle
    {
        /*************生成题目****************/
        Random random = new Random(unchecked((int)DateTime.Now.Ticks));
        Random u1= new Random(unchecked((int)DateTime.Now.Ticks));
        Random u2 = new Random(unchecked((int)DateTime.Now.Ticks));
        static int[] priority = new int[8] { 1, 1, 2, 2, 3, 3, 0, 0 }; //一次对应 +、 -、 *、 /、^, **, (, )的优先级
        public static int[] labels = new int[1000]; //标记题目类型
        public static int[,] stack_order = new int[1000, 400];
        int[] temp = new int[200];
        Normal_Distirbution nd = new Normal_Distirbution();
        /****************初始化相关变量****************/
        void Initialze()
        {
            int i, j;
            for(i = 0; i < 1000; i++)
            {
                MainGUI.puzzle_str[i] = "";
                MainGUI.answer_str[i] = "";
                labels[i] = -1;
            }
            for (i = 0; i < 1000; i++)
            {
                for (j = 0; j < 200; j++)
                {
                    MainGUI.puzzle_int[i, j] = -1;
                }
            }
        }

        int GetGCD(int a, int b) //求分子a好分母b的最大公约数
        {
            if (b == 0 || a == 0) return 1;
            return (a % b == 0) ? b : GetGCD(b, a % b);
        }

        int RandomSymbolGenerate(char type) //随机生成运算符
        {
            int rand_symbol = random.Next();
            if (type == 'A') //普通模式，运算符只有 +， -, *, / 四种
            {
                rand_symbol = rand_symbol % 4 + 100;
            }
            if (type == 'B') //高阶模式1，运算符有 +， -, *, /，^ 五种
            {
                rand_symbol = rand_symbol % 5 + 100;
            }
            if (type == 'C') //高阶模式2，运算符有 +， -, *, /，** 五种
            {
                rand_symbol = rand_symbol % 5 + 100;
                if (rand_symbol == 104) rand_symbol += 1;
            }
            return rand_symbol;
        }

        int RandLeftBracketGenerate() //随机生成左括号
        {
            int left_bracket = random.Next() % 2;
            return left_bracket;
        }

        int RandRightBracketGenerate() //随机生成右括号
        {
            int right_bracket = random.Next() % 2;
            return right_bracket;
        }

        int RandIntegerGeneate() //随机生成0到9的整数
        {
            int number = random.Next() % 10;
            if (number < 0) number = 0;
            return number;
        }

        public static fraction IntegerToFraaction(int a) //把整数转换为分数
        {
            return new fraction(a, 1);
        }

        fraction RandFractionGeneate() //随机生成真分数（不包括0和1）,分子和分母均在0到9之间
        {
            int t;
            int rand_numerator = random.Next() % 10;
            if (rand_numerator <= 0) rand_numerator = 1;
            int rand_denominator = random.Next() % 10;
            if (rand_denominator <= 0) rand_denominator = 1;
            if (rand_numerator > rand_denominator)
            {
                t = rand_numerator;
                rand_numerator = rand_denominator;
                rand_denominator = t;
            }
            else if (rand_numerator == rand_denominator)
            {
                rand_denominator += 1;
            }
            int GCD = GetGCD(rand_numerator, rand_denominator);
            return new fraction(rand_numerator / GCD, rand_denominator / GCD);
        }

        static fraction FractionPartialResult(fraction A, fraction B, int sym) // 两个分数的四则运算
        {
            if (sym == 100) return (A + B);
            else if (sym == 101) return A - B;
            else if (sym == 102) return A * B;
            else if (sym == 103) return A / B;
            else return A ^ B;
        }

        void AnswerToString(int n) //将题目答案转换为string类型
        {
            int i = 0, z, x, y, t;
            for (i = 0; i < n; i++)
            {
                z = GetGCD(MainGUI.answer_int[i, 0], MainGUI.answer_int[i, 2]);
                x = MainGUI.answer_int[i, 0] / z;
                y = MainGUI.answer_int[i, 2] / z;
                if (x % y == 0) MainGUI.answer_str[i] = Convert.ToString(x / y);
                else
                {
                    if (x > 0 && x * y < 0)
                    {
                        t = x;
                        x = y;
                        y = t;
                    }
                    MainGUI.answer_str[i] = "";
                    MainGUI.answer_str[i] += Convert.ToString(x);
                    MainGUI.answer_str[i] += "/";
                    MainGUI.answer_str[i] += Convert.ToString(y);
                }
            }
        }

        public static int Check(int[] puzzle, int puzzle_len, int puzzle_num, int num_type) //判断题目是否重复
        {
            int i, j, L = 1, s; 
            fraction FA, FB, Ft;
            Stack<int> stack_integer = new Stack<int>();
            Stack<fraction> stack_fraction = new Stack<fraction>();
            Stack<int> stack_operator = new Stack<int>();
            int[] order = new int[400];

            /********整数表达式*******/
            if (num_type == 0)
            {
                for (i = 0; i < puzzle_len; i++)
                {
                    if (puzzle[i] < 0) continue;
                    if (puzzle[i] < 100 && puzzle[i] >= 0) //遇到数字，数字直接进入stack_integer栈
                    {
                        fraction f = IntegerToFraaction(puzzle[i]);
                        stack_fraction.Push(f);
                    }
                    else
                    {
                        if (puzzle[i] == 106) //遇到左括号，左括号直接入stack_operator栈
                        {
                            stack_operator.Push(106);
                        }
                        else if (puzzle[i] == 107) //遇到右括号，弹出所有运算符，直至遇到左括号
                        {
                            if (stack_operator.Count() != 0)
                            {
                                while(stack_operator.Count() != 0 && stack_operator.Peek() != 106)
                                {
                                    s = stack_operator.Peek(); //运算符出栈
                                    stack_operator.Pop();
                                    FB = stack_fraction.Peek(); //操作数B出栈
                                    stack_fraction.Pop();
                                    FA = stack_fraction.Peek(); //操作数A出栈
                                    stack_fraction.Pop();
                                    if (s == 100 || s == 102) //+,*法，统一按照大数在前，小数在后方式运算
                                    {
                                        if (FA < FB)
                                        {
                                            Ft = FA;
                                            FA = FB;
                                            FB = Ft;
                                        }
                                    }
                                    order[L++] = FA.GetNumerator();
                                    order[L++] = 1030;
                                    order[L++] = FA.GetDenominator();
                                    order[L++] = s;
                                    order[L++] = FB.GetNumerator();
                                    order[L++] = 1030;
                                    order[L++] = FB.GetDenominator();
                                    if ((s == 103 && FB.GetNumerator() == 0) || ((s == 104 || s == 105) && FA.GetNumerator() == 0 && FB.GetNumerator() == 0))
                                    {
                                        return -1;
                                    }
                                    stack_fraction.Push(FractionPartialResult(FA, FB, s)); //运算结果入栈
                                }
                                if (stack_operator.Count() != 0) stack_operator.Pop(); //弹出左括号
                            }
                        }
                        else
                        {
                            if (puzzle[i] == 104 || puzzle[i] == 105) //遇到乘方，乘方优先级最高,乘方直接进运算符栈
                            {
                                stack_operator.Push(puzzle[i]);
                            }
                            else if (puzzle[i] >= 100 && puzzle[i] <= 107)
                            {
                                //遇到运算符，且运算符栈为空或者栈顶运算符优先级小于当前运算符优先级,运算符直接进运算符栈
                                if (stack_operator.Count() == 0 || (stack_operator.Count() != 0 && priority[stack_operator.Peek() - 100] < priority[puzzle[i] - 100])) stack_operator.Push(puzzle[i]);
                                else
                                {
                                    while(stack_operator.Count() != 0 && priority[stack_operator.Peek() - 100] >= priority[puzzle[i] - 100])
                                    {
                                        s = stack_operator.Peek(); //运算符出栈
                                        stack_operator.Pop();
                                        FB = stack_fraction.Peek(); //操作数B出栈
                                        stack_fraction.Pop();
                                        FA = stack_fraction.Peek(); //操作数A出栈
                                        stack_fraction.Pop();                                     
                                        if ((s == 100 || s == 102) && FA < FB) //+,*法，统一按照大数在前，小数在后方式运算
                                        {
                                            Ft = FA;
                                            FA = FB;
                                            FB = Ft;
                                        }
                                        order[L++] = FA.GetNumerator();
                                        order[L++] = 1030;
                                        order[L++] = FA.GetDenominator();
                                        order[L++] = s;
                                        order[L++] = FB.GetNumerator();
                                        order[L++] = 1030;
                                        order[L++] = FB.GetDenominator();
                                        if ((s == 103 && FB.GetNumerator() == 0) || ((s == 104 || s == 105) && FA.GetNumerator() == 0 && FB.GetNumerator() == 0))
                                        {
                                            return -1;
                                        }
                                        stack_fraction.Push(FractionPartialResult(FA, FB, s)); //运算结果入栈
                                    } 
                                    stack_operator.Push(puzzle[i]); //运算符进运算符栈
                                }
                            }
                        }
                    }
                }
                if (stack_operator.Count() != 0)
                {
                    while(stack_operator.Count() != 0)
                    {
                        s = stack_operator.Peek(); //运算符出栈
                        stack_operator.Pop();
                        FB = stack_fraction.Peek(); //操作数B出栈
                        stack_fraction.Pop();
                        FA = stack_fraction.Peek(); //操作数A出栈
                        stack_fraction.Pop();
                        if ((s == 100 || s == 102) && FA < FB) //+,*法，统一按照大数在前，小数在后方式运算
                        {
                            Ft = FA;
                            FA = FB;
                            FB = Ft;
                        }
                        order[L++] = FA.GetNumerator();
                        order[L++] = 1030;
                        order[L++] = FA.GetDenominator();
                        order[L++] = s;
                        order[L++] = FB.GetNumerator();
                        order[L++] = 1030;
                        order[L++] = FB.GetDenominator();
                        if ((s == 103 && FB.GetNumerator() == 0) || ((s == 104 || s == 105) && FA.GetNumerator() == 0 && FB.GetNumerator() == 0))
                        {
                            return -1;
                        }
                        stack_fraction.Push(FractionPartialResult(FA, FB, s)); //运算结果入栈
                    } 
                    if(stack_fraction.Count() != 0)
                    {
                        Ft = stack_fraction.Peek(); //运算结果出栈
                        stack_fraction.Pop();
                        order[L++] = Ft.GetNumerator();
                        order[L++] = 1030;
                        order[L++] = Ft.GetDenominator();
                    }
                }
                else
                {
                    Ft = stack_fraction.Peek(); //运算结果出栈
                    stack_fraction.Pop();
                    order[L++] = Ft.GetNumerator();
                    order[L++] = 1030;
                    order[L++] = Ft.GetDenominator();
                }
                order[0] = L;
            }
            /****分数表达式****/
            else
            {
                for (i = 0; i < puzzle_len; i++)
                {
                    if (puzzle[i] < 0) continue;
                    if (puzzle[i] < 100 && puzzle[i] >= 0) //遇到分数，分数直接进入stack_fraction栈
                    {
                        fraction f = new fraction(puzzle[i], puzzle[i + 2]);
                        stack_fraction.Push(f);
                        i += 2;
                    }
                    else
                    {
                        if (puzzle[i] == 106) //遇到左括号，左括号直接入stack_operator栈
                        {
                            stack_operator.Push(106);
                        }
                        else if (puzzle[i] == 107) //遇到右括号，弹出所有运算符，直至遇到左括号
                        {
                            s = stack_operator.Peek(); //运算符出栈
                            while(stack_operator.Count() != 0 && (s = stack_operator.Peek()) != 106)
                            {
                                stack_operator.Pop();
                                FB = stack_fraction.Peek(); //操作数FB出栈
                                stack_fraction.Pop();
                                FA = stack_fraction.Peek(); //操作数FA出栈
                                stack_fraction.Pop();
                                if (s == 100 || s == 102) //+,*法，统一按照大数在前，小数在后方式运算
                                {
                                    if (FA < FB)
                                    {
                                        Ft = FA;
                                        FA = FB;
                                        FB = Ft;
                                    }
                                }
                                order[L++] = FA.GetNumerator();
                                order[L++] = 1030;
                                order[L++] = FA.GetDenominator();
                                order[L++] = s;
                                order[L++] = FB.GetNumerator();
                                order[L++] = 1030;
                                order[L++] = FB.GetDenominator();
                                if (FB.GetNumerator() == 0 && s == 103) return -1;
                                fraction ff = FractionPartialResult(FA, FB, s);
                                stack_fraction.Push(ff); //运算结果入栈
                            } 
                            stack_operator.Pop(); //弹出左括号
                        }
                        else if (puzzle[i] >= 100 && puzzle[i] <= 107)
                        {
                            //遇到运算符，且运算符栈为空或者栈顶运算符优先级小于当前运算符优先级,运算符直接进运算符栈
                            if (stack_operator.Count() == 0 || (stack_operator.Count() != 0 && priority[stack_operator.Peek() - 100] < priority[puzzle[i] - 100])) stack_operator.Push(puzzle[i]);
                            else
                            {
                                while(stack_operator.Count() != 0 && priority[stack_operator.Peek() - 100] >= priority[puzzle[i] - 100])
                                {
                                    s = stack_operator.Peek(); //运算符出栈
                                    stack_operator.Pop();
                                    FB = stack_fraction.Peek(); //操作数B出栈
                                    stack_fraction.Pop();
                                    FA = stack_fraction.Peek(); //操作数A出栈
                                    stack_fraction.Pop();
                                    if ((s == 100 || s == 102) && FA < FB) //+,*法，统一按照大数在前，小数在后方式运算
                                    {
                                        Ft = FA;
                                        FA = FB;
                                        FB = Ft;
                                    }
                                    order[L++] = FA.GetNumerator();
                                    order[L++] = 1030;
                                    order[L++] = FA.GetDenominator();
                                    order[L++] = s;
                                    order[L++] = FB.GetNumerator();
                                    order[L++] = 1030;
                                    order[L++] = FB.GetDenominator();
                                    if (FB.GetNumerator() == 0 && s == 103) return -1;
                                    fraction ff = FractionPartialResult(FA, FB, s);
                                    stack_fraction.Push(ff); //运算结果入栈
                                } 
                                stack_operator.Push(puzzle[i]); //运算符进运算符栈
                            }
                        }
                    }
                }
                if (stack_operator.Count() != 0)
                {
                    while(stack_operator.Count() != 0)
                    {
                        s = stack_operator.Peek(); //运算符出栈
                        stack_operator.Pop();
                        FB = stack_fraction.Peek(); //操作数B出栈
                        stack_fraction.Pop();
                        FA = stack_fraction.Peek(); //操作数A出栈
                        stack_fraction.Pop();
                        if ((s == 100 || s == 102) && FA < FB) //+,*法，统一按照大数在前，小数在后方式运算
                        {
                            Ft = FA;
                            FA = FB;
                            FB = Ft;
                        }
                        order[L++] = FA.GetNumerator();
                        order[L++] = 1030;
                        order[L++] = FA.GetDenominator();
                        order[L++] = s;
                        order[L++] = FB.GetNumerator();
                        order[L++] = 1030;
                        order[L++] = FB.GetDenominator();
                        if (FB.GetNumerator() == 0 && s == 103) return -1;
                        fraction ff = FractionPartialResult(FA, FB, s);
                        stack_fraction.Push(ff); //运算结果入栈
                    } 
                    if (stack_fraction.Count() != 0)
                    {
                        Ft = stack_fraction.Peek(); //运算结果出栈
                        stack_fraction.Pop();
                        order[L++] = Ft.GetNumerator();
                        order[L++] = 1030;
                        order[L++] = Ft.GetDenominator();
                    }
                }
                else
                {
                    Ft = stack_fraction.Peek(); //运算结果出栈
                    stack_fraction.Pop();
                    order[L++] = Ft.GetNumerator();
                    order[L++] = 1030;
                    order[L++] = Ft.GetDenominator();
                }
                order[0] = L;
            }

            /**********判断与之前的题目是否重复************/
            int flag = 0, label = 0;
            for (i = 0; i < puzzle_num; i++)
            {
                if (labels[i] != num_type || order[0] != stack_order[i, 0]) continue;
                else
                {
                    flag = 0;
                    for (j = 1; j < stack_order[i, 0]; j++)
                    {
                        if (stack_order[i, j] != order[j])
                        {
                            flag = 1;
                            break;
                        }
                    }
                    if (flag == 0)
                    {
                        label = 1;
                        break;
                    }
                }
            }
            if (label == 1) return -1; //有重复
            else
            {
                for (j = 0; j < order[0]; j++) //登记到题目记录里
                {
                    stack_order[puzzle_num, j] = order[j];
                }
                MainGUI.answer_int[puzzle_num, 0] = stack_order[puzzle_num, stack_order[puzzle_num, 0] - 3];
                MainGUI.answer_int[puzzle_num, 1] = stack_order[puzzle_num, stack_order[puzzle_num, 0] - 2];
                MainGUI.answer_int[puzzle_num, 2] = stack_order[puzzle_num, stack_order[puzzle_num, 0] - 1];
                return 1; //无重复
            }
        }

        public void PuzzleGenerate(int N, char type) //生成N个四则表达式
        {
            int i, j, number_type, operator_num, L, t, index, m;
            int left_brack_num = 0, right_bracket_num = 0;
            fraction frac;

            int divide_flag = 0; //标记当前是否有除号
            int power_flag = 0; //标记当前是否有乘方号
            Initialze(); //初始化相关变量
            for (i = 0; i < N; i++)
            {
                L = 0;

                /*随机生成运算符个数（1到10之间）*/
                operator_num = nd.Normal_Dis(u1.NextDouble(), u2.NextDouble(), 3, 4);
               //operator_num = random.
                if (operator_num < 1) operator_num = 1;
                else if (operator_num > 10) operator_num = 10;

                number_type = random.Next() % 2; //number_type == 0 为整数题，number_type == 1 为真分数题

                /************整数四则运算题目的生成**********/
                if (number_type == 0)
                {
                    labels[i] = 0;
                    do
                    {
                        L = 0;
                        divide_flag = power_flag = 0;
                        left_brack_num = right_bracket_num = 0;
                        for (j = 0; j < operator_num; j++)
                        {
                            /**********随机生成左括号***********/
                            if (right_bracket_num < operator_num - 1 && right_bracket_num <= 5)
                            {
                                if (divide_flag == 0 && power_flag == 0) //为了避免除数为0，不允许除号右边为左括号;为了是乘方易求解，不允许乘方右边为左括号
                                {
                                    if (RandLeftBracketGenerate() != 0)
                                    {
                                        MainGUI.puzzle_int[i, L++] = 106; //左括号
                                        right_bracket_num += 1;
                                    }
                                }
                            }

                            /****************生成随机整数******************/
                            if (divide_flag == 1)  //除号,除数不能为0，且为了计算方便，整数尽可能满足整除
                            {
                                do
                                {
                                    t = RandIntegerGeneate();
                                } while (t == 0 || (t != 0 && MainGUI.puzzle_int[i, j] != 106 && MainGUI.puzzle_int[i, L - 2] % t != 0));
                                MainGUI.puzzle_int[i, L++] = t;
                                divide_flag = 0;
                            }
                            else if (power_flag == 1) //乘方，未来避免底数为0，乘方左边不能为右括号
                            {
                                m = L - 2;
                                while (m >= 0 && (MainGUI.puzzle_int[i, m] == 107 || MainGUI.puzzle_int[i, m] == -2))
                                {
                                    if (MainGUI.puzzle_int[i, m] == 107) right_bracket_num += 1;
                                    MainGUI.puzzle_int[i, m] = -2;
                                    m -= 1;
                                }
                                if (m >= 0 && MainGUI.puzzle_int[i, m] == 0)
                                {
                                    do
                                    {
                                        t = RandIntegerGeneate();
                                    } while (t == 0);
                                    MainGUI.puzzle_int[i, m] = t;
                                }
                                MainGUI.puzzle_int[i, L++] = RandIntegerGeneate() % 3; //为了易计算，乘方的幂限制在0到2
                                power_flag = 0;
                            }
                            else MainGUI.puzzle_int[i, L++] = RandIntegerGeneate();


                            index = RandomSymbolGenerate(type);

                            /************随机生成右括号***********/
                            if (right_bracket_num > 0 && index != 104 && index != 105) //为了避免底数为0，乘方前面不允许为右括号
                            {
                                m = L - 2;
                                while (m >= 0 && MainGUI.puzzle_int[i, m] == -2)
                                {
                                    m -= 1;
                                }
                                if (m >= 0 && MainGUI.puzzle_int[i, m] == 106) { }
                                else if (RandRightBracketGenerate() == 1)
                                {
                                    MainGUI.puzzle_int[i, L++] = 107; //右括号
                                    right_bracket_num -= 1;
                                }
                            }
                            /**********生成随机运算符**********/
                            MainGUI.puzzle_int[i, L++] = index;

                            /*********标记除号和乘方号********/
                            if (index == 103) divide_flag = 1;
                            else if (index == 104 || index == 105) power_flag = 1;
                        }

                        /*************生成表达式的最后一个随机整数*************/
                        if (divide_flag == 1)  //除号
                        {
                            do
                            {
                                t = RandIntegerGeneate();
                            } while (t == 0);
                            MainGUI.puzzle_int[i, L++] = t;
                            divide_flag = 0;
                        }
                        else if (power_flag == 1) //乘方号
                        {
                            m = L - 2;
                            while (m >= 0 && (MainGUI.puzzle_int[i, m] == 107 || MainGUI.puzzle_int[i, m] == -2))  //为了避免底数为0，乘方前面不允许为右括号
                            {
                                if (MainGUI.puzzle_int[i, m] == 107) right_bracket_num += 1;
                                MainGUI.puzzle_int[i, m] = -2;
                                m -= 1;
                            }
                            if (m >= 0 && MainGUI.puzzle_int[i, m] == 0)
                            {
                                do
                                {
                                    t = RandIntegerGeneate();
                                } while (t == 0);
                                MainGUI.puzzle_int[i, m] = t;
                            }
                            MainGUI.puzzle_int[i, L++] = RandIntegerGeneate() % 3; //为了易计算，乘方的幂限制在0到2
                            power_flag = 0;
                        }
                        else MainGUI.puzzle_int[i, L++] = RandIntegerGeneate();

                        /***********填补剩下的括号对***********/
                        for (j = right_bracket_num; j > 0; j--)
                        {
                            MainGUI.puzzle_int[i, L++] = 107;
                        }
                        for (j = 0; j < L; j++)
                        {
                            temp[j] = MainGUI.puzzle_int[i, j];
                        }
                    } while (Check(temp, L, i, number_type) != 1);
                }

                /*********分数四则运算题目的生成**********/
                else
                {
                    labels[i] = 1;
                    do
                    {
                        L = 0;
                        divide_flag = power_flag = 0;
                        left_brack_num = right_bracket_num = 0;
                        for (j = 0; j < operator_num; j++)
                        {
                            /******随机生成左括号******/
                            if (right_bracket_num < operator_num - 1 && right_bracket_num <= 5)
                            {
                                if (divide_flag == 0 && RandLeftBracketGenerate() == 1)
                                {
                                    MainGUI.puzzle_int[i, L++] = 106;
                                    right_bracket_num += 1;
                                }

                            }
                            if (divide_flag == 1) divide_flag = 0;

                            /******生成随机真分数******/
                            frac = RandFractionGeneate();
                            MainGUI.puzzle_int[i, L++] = frac.GetNumerator();
                            MainGUI.puzzle_int[i, L++] = 1030;
                            MainGUI.puzzle_int[i, L++] = frac.GetDenominator();

                            /*******随机生成右括号********/
                            if (L - 4 >= 0 && MainGUI.puzzle_int[i, L - 4] != 106 && right_bracket_num > 0 && RandRightBracketGenerate() == 1)
                            {
                                MainGUI.puzzle_int[i, L++] = 107;
                                right_bracket_num -= 1;
                            }

                            /*********生成随机运算符********/
                            MainGUI.puzzle_int[i, L++] = index = RandomSymbolGenerate('A');  //考虑到小学生的难度，真分数不设置乘方运算，故选用普通模式A
                            if (index == 103)
                            {
                                divide_flag = 1; //标记当前运算符为除号
                            }
                        }

                        /*******生成表达式的最后一个随机真分数******/
                        frac = RandFractionGeneate();
                        MainGUI.puzzle_int[i, L++] = frac.GetNumerator();
                        MainGUI.puzzle_int[i, L++] = 1030;
                        MainGUI.puzzle_int[i, L++] = frac.GetDenominator();

                        /********填补剩下的括号对*********/
                        for (j = right_bracket_num; j > 0; j--)
                        {
                            MainGUI.puzzle_int[i, L++] = 107;
                        }
                        for (j = 0; j < L; j++)
                        {
                            temp[j] = MainGUI.puzzle_int[i, j];
                        }
                    } while (Check(temp, L, i, number_type) != 1);
                }
            }

            /********将题目输出到puzzle_str[][]中********/
            for (i = 0; i < N; i++)
            {
                j = 0;
                if (labels[i] == 0) //整数表达式
                {
                    while (j < 600 && MainGUI.puzzle_int[i, j] != -1)
                    {
                        if (MainGUI.puzzle_int[i, j] == -2) continue;
                        if (MainGUI.puzzle_int[i, j] == 106) MainGUI.puzzle_str[i] += "( ";
                        else if (MainGUI.puzzle_int[i, j] == 107) MainGUI.puzzle_str[i] += " )";
                        else if (MainGUI.puzzle_int[i, j] == 100) MainGUI.puzzle_str[i] += " + ";
                        else if (MainGUI.puzzle_int[i, j] == 101) MainGUI.puzzle_str[i] += " - ";
                        else if (MainGUI.puzzle_int[i, j] == 102) MainGUI.puzzle_str[i] += " * ";
                        else if (MainGUI.puzzle_int[i, j] == 103) MainGUI.puzzle_str[i] += " / ";
                        else if (MainGUI.puzzle_int[i, j] == 104) MainGUI.puzzle_str[i] += " ^ ";
                        else if (MainGUI.puzzle_int[i, j] == 105) MainGUI.puzzle_str[i] += " ** ";
                        else MainGUI.puzzle_str[i] += Convert.ToString(MainGUI.puzzle_int[i, j]);
                        j++;
                    }
                }
                else //真分数表达式
                {
                    while (j < 600 && MainGUI.puzzle_int[i, j] != -1)
                    {
                        if (MainGUI.puzzle_int[i, j] == -2) continue;
                        if (MainGUI.puzzle_int[i, j] == 106) MainGUI.puzzle_str[i] += "( ";
                        else if (MainGUI.puzzle_int[i, j] == 107) MainGUI.puzzle_str[i] += " )";
                        else if (MainGUI.puzzle_int[i, j] == 100) MainGUI.puzzle_str[i] += " + ";
                        else if (MainGUI.puzzle_int[i, j] == 101) MainGUI.puzzle_str[i] += " - ";
                        else if (MainGUI.puzzle_int[i, j] == 102) MainGUI.puzzle_str[i] += " * ";
                        else if (MainGUI.puzzle_int[i, j] == 103) MainGUI.puzzle_str[i] += " / ";
                        else
                        {
                            if (MainGUI.puzzle_int[i, j] == 1030) MainGUI.puzzle_str[i] += "/";
                            else MainGUI.puzzle_str[i] += Convert.ToString(MainGUI.puzzle_int[i, j]);
                        }
                        j++;
                    }
                }
                MainGUI.puzzle_str[i] += " = ?";
            }
            AnswerToString(N);
        }
    }
}
