/*
----------------------------
作者：杨冰琪
日期：2019.01.13
功能：四则运算题目求解头文件
----------------------------
*/
#pragma once
#include <string.h>
#include <stdio.h>
#include <iostream>

using namespace std;

#pragma region MainFunc
bool CheckQuestion(string Question);
void Clear();//清空栈
void Calculate(string Question);
void UserGUI(string user_answer);
string Transform(int data);//将数值转换为字符串
#pragma endregion

#pragma region Integer
void ReadInt(string Question);
void Integer();//+-*/^
void CalInt();//确保Operator栈为空
string ToPower(string Question);//将 ** 转换为 ^
#pragma endregion

#pragma region Fraction
void ReadFraction(string Question);
int gcd(int x, int y);//最大因约数
int lcm(int x, int y);//最小公倍数 = 两数相乘 / 最大因约数
void Fraction();//+-*/
void CalFraction();
void Simple();//分数最简化
#pragma endregion
