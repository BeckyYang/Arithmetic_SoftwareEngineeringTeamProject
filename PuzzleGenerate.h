/*
-------------------------------------
谢蜜雪 学号：1120161761
日期：2019/1/12
实现功能：PuzzleGenerate.cpp的头文件
-------------------------------------
*/

#pragma once

#include "fraction.h"

int GetGCD(int a, int b);  //求分子a好分母b的最大公约数

int RandomSymbolGenerate(char type);  //随机生成运算符

int RandLeftBracketGenerate();  //随机生成左括号

int RandRightBracketGenerate();  //随机生成右括号

int RandIntegerGeneate();   //随机生成0到9的整数

fraction& RandFractionGeneate();  //随机生成真分数（不包括0和1）,分子和分母均在0到9之间

int IntPartialResult(int A, int B, int sym); //两个整数的四则运算

fraction& FractionPartialResult(fraction &A, fraction& B, int sym);  // 两个分数的四则运算

int check(int puzzle[], int puzzle_len, int puzzle_num, int num_type);  //判断题目是否重复

void PuzzleGenerate(char* argv, int N, char type);  //生成N个四则表达式
