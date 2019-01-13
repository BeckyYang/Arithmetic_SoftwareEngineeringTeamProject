/*
---------------------------------------
谢蜜雪 学号：1120161761
日期：2019/1/13
实现功能：生成N个type类型的四则运算题目
---------------------------------------
*/
#pragma once

#include "stdafx.h"
#include "fraction.h"
#include "PuzzleGenerate.h"
#include <iostream>
#include <stdio.h>
#include <random>
#include <fstream>
#include <cstring>
#include <string>
#include <ctime>
#include <vector>
#include <stack>
#include <functional>
using namespace std;

vector <string> puzzle_string(1000);
int puzzle_int[1000][600];
int labels[1000];
int stack_order[1000][600];
int  priority[8] = {1,1,2,2,3,3,0,0}; //一次对应 +、 -、 *、 /、^, **, (, )的优先级
string filepath = "";
ofstream out;
default_random_engine e(time(NULL));
default_random_engine seed(time(NULL));
normal_distribution<double> operator_num_distribution(3, 3); //运算符个数符合正态分布，期望值为3，方差为3
normal_distribution<double> bracket_num_distribution(2, 2); //括号对个数符合正态分布，期望值为2，方差为2
auto operator_num_distribution_dice = bind(operator_num_distribution, seed);
auto bracket_num_distribution_dice = bind(bracket_num_distribution, seed);

int GetGCD(int a, int b) //求分子a好分母b的最大公约数
{
	return (a % b == 0) ? b : GetGCD(b, a%b);
}

int RandomSymbolGenerate(char type) //随机生成运算符
{
	int rand_symbol;
	rand_symbol = rand();
	if (type == 'A') //普通模式，运算符只有 +， -, *, / 四种
	{
		rand_symbol = rand_symbol % 4+100;
	}
	if (type == 'B') //高阶模式1，运算符有 +， -, *, /，^ 五种
	{
		rand_symbol = rand_symbol % 5+100;
	}
	if (type == 'C') //高阶模式2，运算符有 +， -, *, /，** 五种
	{
		rand_symbol = rand_symbol % 5+100;
		if (rand_symbol == 104) rand_symbol += 1;
	}
	return rand_symbol;
}

int RandLeftBracketGenerate() //随机生成左括号
{
	int left_bracket = rand() % 2;
	return left_bracket;
}

int RandRightBracketGenerate() //随机生成右括号
{
	int right_bracket = rand() % 2;
	return right_bracket;
}

int RandIntegerGeneate() //随机生成0到9的整数
{
	int number = rand() % 10;
	if (number < 0) number = 0;
	return number;
}

fraction& RandFractionGeneate() //随机生成真分数（不包括0和1）,分子和分母均在0到9之间
{
	int t;
	int rand_numerator = rand() % 10;
	if (rand_numerator <= 0) rand_numerator = 1;
	int rand_denominator = rand() % 10;
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
	fraction number(rand_numerator/GCD, rand_denominator/GCD);
	return number;
}

int IntPartialResult(int A, int B, int sym) //两个整数的四则运算
{
	if (sym == 100) return A + B;
	else if (sym == 101) return A - B;
	else if (sym == 102) return A * B;
	else if (sym == 103) return A / B;
	else return int(pow(A, B));
}

fraction& FractionPartialResult(fraction &A, fraction& B, int sym) // 两个分数的四则运算
{
	if (sym == 100) return A + B;
	else if (sym == 101) return A - B;
	else if (sym == 102) return A * B;
	else return A / B;
}

int Check(int puzzle[], int puzzle_len, int puzzle_num, int num_type) //判断题目是否重复
{
	int i, j, L = 1, s, A, B, t, first = 0;
	fraction FA, FB, Ft;
	stack<int> stack_integer;
	stack<fraction> stack_fraction;
	stack<int> stack_operator;
	int order[600];
	memset(order, 0, sizeof(order));
	/********整数表达式*******/
	if (num_type == 0)
	{
		for (i = 0; i < puzzle_len; i++)
		{
			if (puzzle[i] < 0) continue;
			if (puzzle[i] < 100 && puzzle[i] >=0) //遇到数字，数字直接进入stack_integer栈
			{
				stack_integer.push(puzzle[i]);
			}
			else
			{
				if (puzzle[i] == 106) //遇到左括号，左括号直接入stack_operator栈
				{
					stack_operator.push(106);
				}
				else if (puzzle[i] == 107) //遇到右括号，弹出所有运算符，直至遇到左括号
				{
					if (!stack_operator.empty())
					{
						do
						{
							s = stack_operator.top(); //运算符出栈
							stack_operator.pop();
							B = stack_integer.top(); //操作数B出栈
							stack_integer.pop();
							A = stack_integer.top(); //操作数A出栈
							stack_integer.pop();
							if (s == 100 || s == 102) //+,*法，统一按照大数在前，小数在后方式运算
							{
								if (A < B)
								{
									t = A;
									A = B;
									B = t;
								}
							}
							order[L++] = A;
							order[L++] = s;
							order[L++] = B;
							if ((s == 103 && B == 0) || ((s == 104 || s == 105) && A == 0 && B == 0))
							{
								return -1;
							}
							stack_integer.push(IntPartialResult(A, B, s)); //运算结果入栈
						} while (stack_operator.empty() == false && stack_operator.top() != 106);
						if (!stack_operator.empty()) stack_operator.pop(); //弹出左括号
					}
				}
				else
				{
					if (puzzle[i] == 104 || puzzle[i] == 105) //遇到乘方，乘方优先级最高,乘方直接进运算符栈
					{
						stack_operator.push(puzzle[i]);
					}
					else
					{
						//遇到运算符，且运算符栈为空或者栈顶运算符优先级小于当前运算符优先级,运算符直接进运算符栈
						if (stack_operator.empty() == true || (stack_operator.empty() == false && priority[stack_operator.top()-100] < priority[puzzle[i]-100])) stack_operator.push(puzzle[i]);
						else
						{
							do
							{
								s = stack_operator.top(); //运算符出栈
								stack_operator.pop();
								B = stack_integer.top(); //操作数B出栈
								stack_integer.pop();
								A = stack_integer.top(); //操作数A出栈
								stack_integer.pop();
								if ((s == 100 || s == 102) && A < B) //+,*法，统一按照大数在前，小数在后方式运算
								{
									t = A;
									A = B;
									B = t;
								}
								order[L++] = A;
								order[L++] = s;
								order[L++] = B;
								if ((s == 103 && B == 0) || ((s == 104 || s == 105) && A == 0 && B == 0))
								{
									return -1;
								}
								stack_integer.push(IntPartialResult(A, B, s)); //运算结果入栈
							} while (stack_operator.empty() == false && priority[stack_operator.top() - 100] >= priority[puzzle[i]-100]);
							stack_operator.push(puzzle[i]); //运算符进运算符栈
						}
					}	
				}
			}
		}
		if (stack_operator.empty() == false)
		{
			do
			{
				s = stack_operator.top(); //运算符出栈
				stack_operator.pop();
				B = stack_integer.top(); //操作数B出栈
				stack_integer.pop();
				A = stack_integer.top(); //操作数A出栈
				stack_integer.pop();
				if ((s == 100 || s == 102) && A < B) //+,*法，统一按照大数在前，小数在后方式运算
				{
					t = A;
					A = B;
					B = t;
				}
				order[L++] = A;
				order[L++] = s;
				order[L++] = B;
				if ((s == 103 && B == 0) || ((s == 104 || s == 105) && A == 0 && B == 0))
				{
					return -1;
				}
				stack_integer.push(IntPartialResult(A, B, s)); //运算结果入栈
			}while (stack_operator.empty() == false);
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
				fraction f(puzzle[i], puzzle[i + 2]);
				stack_fraction.push(f);
				i += 2;
			}
			else
			{
				if (puzzle[i] == 106) //遇到左括号，左括号直接入stack_operator栈
				{
					stack_operator.push(106);
				}
				else if (puzzle[i] == 107) //遇到右括号，弹出所有运算符，直至遇到左括号
				{
					s = stack_operator.top(); //运算符出栈
					do 
					{
						stack_operator.pop();
						FB = stack_fraction.top(); //操作数FB出栈
						stack_fraction.pop();
						FA = stack_fraction.top(); //操作数FA出栈
						stack_fraction.pop();
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
						stack_fraction.push(ff); //运算结果入栈
					} while (stack_operator.empty() == false && (s = stack_operator.top()) != 106);
					stack_operator.pop(); //弹出左括号
				}
				else
				{
					//遇到运算符，且运算符栈为空或者栈顶运算符优先级小于当前运算符优先级,运算符直接进运算符栈
					if (stack_operator.empty() == true || (stack_operator.empty() == false && priority[stack_operator.top() - 100] < priority[puzzle[i] - 100])) stack_operator.push(puzzle[i]);
					else
					{
						do
						{
							s = stack_operator.top(); //运算符出栈
							stack_operator.pop();
							FB = stack_fraction.top(); //操作数B出栈
							stack_fraction.pop();
							FA = stack_fraction.top(); //操作数A出栈
							stack_fraction.pop();
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
							stack_fraction.push(ff); //运算结果入栈
						} while (stack_operator.empty() == false && priority[stack_operator.top() - 100] >= priority[puzzle[i] - 100]);
						stack_operator.push(puzzle[i]); //运算符进运算符栈
					}
				}
			}
		}
		if (stack_operator.empty() == false)
		{
			do
			{
				s = stack_operator.top(); //运算符出栈
				stack_operator.pop();
				FB = stack_fraction.top(); //操作数B出栈
				stack_fraction.pop();
				FA = stack_fraction.top(); //操作数A出栈
				stack_fraction.pop();
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
				stack_fraction.push(ff); //运算结果入栈
			} while (stack_operator.empty() == false);
		}
		order[0] = L;
	}

	/**********判断与之前的题目是否重复************/
	int flag = 0, label = 0;
	for (i = 0; i < puzzle_num; i++)
	{
		if (labels[i] != num_type || order[0] != stack_order[i][0]) continue;
		else
		{
			flag = 0;
			for (j = 1; j < stack_order[i][0]; j++)
			{
				if (stack_order[i][j] != order[j])
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
			stack_order[puzzle_num][j] = order[j];
		}
		return 1; //无重复
	}
}
 
void PuzzleGenerate(char* argv, int N, char type) //生成N个四则表达式
{
	filepath = argv;
	int l = filepath.length() - 14;
	filepath.erase(l);
	filepath += "puzzle.txt";

	int i, j, number_type, operator_num, L, t, index, m;
	int left_brack_num = 0, right_bracket_num = 0, left_bracket_flag = 0;;
	string str;
	fraction frac;


	int divide_flag = 0; //标记当前是否有除号
	int power_flag = 0; //标记当前是否有乘方号
	memset(labels, -1, sizeof(labels));
	memset(puzzle_int, -1, sizeof(puzzle_int));
	for (i = 0; i < N; i++)
	{
		L = 0;

		/*随机生成运算符个数（1到10之间）*/
		operator_num = int(round(operator_num_distribution_dice())); 
		if (operator_num < 1) operator_num = 1;
		else if (operator_num > 10) operator_num = 10;

		number_type = rand() % 2; //number_type == 0 为整数题，number_type == 1 为真分数题

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
					left_bracket_flag = 0;
					if (right_bracket_num < operator_num - 1)
					{
						if (divide_flag == 0 && power_flag == 0) //为了避免除数为0，不允许除号右边为左括号;为了是乘方易求解，不允许乘方右边为左括号
						{
							if (RandLeftBracketGenerate() != 0)
							{
								puzzle_int[i][L++] = 106; //左括号
								right_bracket_num += 1;
								left_bracket_flag = 1;
							}
						}
					}

					/****************生成随机整数******************/
					if (divide_flag == 1)  //除号,除数不能为0，且为了计算方便，整数尽可能满足整除
					{
						do
						{
							t = RandIntegerGeneate();
						} while (t == 0 || (t != 0 && puzzle_int[i][j] != 106 && puzzle_int[i][L - 2] % t != 0));
						puzzle_int[i][L++] = t;
						divide_flag = 0;
					}
					else if (power_flag == 1) //乘方，未来避免底数为0，乘方左边不能为右括号
					{
						m = L - 2;
						while (m >= 0 && (puzzle_int[i][m] == 107 || puzzle_int[i][m] == -2))
						{
							if (puzzle_int[i][m] == 107) right_bracket_num += 1;
							puzzle_int[i][m] = -2;
							m -= 1;
						}
						if (m >= 0 && puzzle_int[i][m] == 0)
						{
							do
							{
								t = RandIntegerGeneate();
							} while (t == 0);
							puzzle_int[i][m] = t;
						}
						puzzle_int[i][L++] = RandIntegerGeneate() % 3; //为了易计算，乘方的幂限制在0到2
						power_flag = 0;
					}
					else puzzle_int[i][L++] = RandIntegerGeneate();


					index = RandomSymbolGenerate(type);

					/************随机生成右括号***********/
					if (right_bracket_num > 0 && index != 104 && index != 105) //为了避免底数为0，乘方前面不允许为右括号
					{
						m = L - 2;
						while (m >= 0 && puzzle_int[i][m] == -2)
						{
							m -= 1;
						}
						if (m >= 0 && puzzle_int[i][m] == 106);
						else if (RandRightBracketGenerate() == 1)
						{
							puzzle_int[i][L++] = 107; //右括号
							right_bracket_num -= 1;
						}
					}
					/**********生成随机运算符**********/
					puzzle_int[i][L++] = index;

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
					puzzle_int[i][L++] = t;
					divide_flag = 0;
				}
				else if (power_flag == 1) //乘方号
				{
					m = L - 2;
					while (m >= 0 && (puzzle_int[i][m] == 107 || puzzle_int[i][m] == -2))  //为了避免底数为0，乘方前面不允许为右括号
					{
						if (puzzle_int[i][m] == 107) right_bracket_num += 1;
						puzzle_int[i][m] = -2;
						m -= 1;
					}
					if (m >= 0 && puzzle_int[i][m] == 0)
					{
						do
						{
							t = RandIntegerGeneate();
						} while (t == 0);
						puzzle_int[i][m] = t;
					}
					puzzle_int[i][L++] = RandIntegerGeneate() % 3; //为了易计算，乘方的幂限制在0到2
					power_flag = 0;
				}
				else puzzle_int[i][L++] = RandIntegerGeneate();

				/***********填补剩下的括号对***********/
				for (j = right_bracket_num; j > 0; j--)
				{
					puzzle_int[i][L++] = 107;
				}
			}while (Check(puzzle_int[i], L, i, number_type) != 1);
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
					if (right_bracket_num < operator_num - 1)
					{
						if (divide_flag == 0 && RandLeftBracketGenerate() == 1)
						{
							puzzle_int[i][L++] = 106;
							right_bracket_num += 1;
						}

					}
					if (divide_flag == 1) divide_flag = 0;

					/******生成随机真分数******/
					frac = RandFractionGeneate();
					puzzle_int[i][L++] = frac.GetNumerator();
					puzzle_int[i][L++] = 1030;
					puzzle_int[i][L++] = frac.GetDenominator();

					/*******随机生成右括号********/
					if (L - 4 >= 0 && puzzle_int[i][L - 4] != 106 && right_bracket_num > 0 && RandRightBracketGenerate() == 1)
					{
						puzzle_int[i][L++] = 107;
						right_bracket_num -= 1;
					}

					/*********生成随机运算符********/
					puzzle_int[i][L++] = index = RandomSymbolGenerate('A');  //考虑到小学生的难度，真分数不设置乘方运算，故选用普通模式A
					if (index == 103)
					{
						divide_flag = 1; //标记当前运算符为除号
					}
				}

				/*******生成表达式的最后一个随机真分数******/
				frac = RandFractionGeneate();
				puzzle_int[i][L++] = frac.GetNumerator();
				puzzle_int[i][L++] = 1030;
				puzzle_int[i][L++] = frac.GetDenominator();

				/********填补剩下的括号对*********/
				for (j = right_bracket_num; j > 0; j--)
				{
					puzzle_int[i][L++] = 107;
				}
			} while (Check(puzzle_int[i], L, i, number_type) != 1);
		}
	}

	/********将题目输出到puzzle.txt文件中********/
	for (i = 0; i < N; i++)
	{
		j = 0;
		if (labels[i] == 0) //整数表达式
		{
			while (puzzle_int[i][j] != -1)
			{
				if (puzzle_int[i][j] == -2) continue;
				if (puzzle_int[i][j] == 106) puzzle_string[i] += "( ";
				else if (puzzle_int[i][j] == 107) puzzle_string[i] += " )";
				else if (puzzle_int[i][j] == 100) puzzle_string[i] += " + ";
				else if (puzzle_int[i][j] == 101) puzzle_string[i] += " - ";
				else if(puzzle_int[i][j] == 102) puzzle_string[i] += " * ";
				else if (puzzle_int[i][j] == 103) puzzle_string[i] += " / ";
				else if (puzzle_int[i][j] == 104) puzzle_string[i] += " ^ ";
				else if (puzzle_int[i][j] == 105) puzzle_string[i] += " ** ";
				else  puzzle_string[i] += to_string(puzzle_int[i][j]);
				j++;
			}
		}
		else //真分数表达式
		{
			while (puzzle_int[i][j] != -1)
			{
				if (puzzle_int[i][j] == -2) continue;
				if(puzzle_int[i][j] == 106) puzzle_string[i] += "( ";
				else if (puzzle_int[i][j] == 107) puzzle_string[i] += " )"; 
				else if (puzzle_int[i][j] == 100) puzzle_string[i] += " + ";
				else if (puzzle_int[i][j] == 101) puzzle_string[i] += " - ";
				else if (puzzle_int[i][j] == 102) puzzle_string[i] += " * ";
				else if (puzzle_int[i][j] == 103) puzzle_string[i] += " / ";
				else
				{
					if (puzzle_int[i][j] == 1030) puzzle_string[i] += "/";
					else  puzzle_string[i] += to_string(puzzle_int[i][j]);
				}
				j++;
			}
		}
		puzzle_string[i] += " = ?";
	}
	out.open(filepath, ios::trunc); //清空puzzle.txt的原有内容
	for (i = 0; i < N; i++)
	{
		if(i< N-1) out << puzzle_string[i] <<endl;
		else out << puzzle_string[i];
	}
	out.close();
}
