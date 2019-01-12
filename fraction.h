/*
----------------------------------
谢蜜雪 学号：1120161761
日期：2019/1/12
实现功能：分数的类fraction的头文件
----------------------------------
*/

#pragma once
#include <stdio.h>
#include <iostream>

using namespace std;

class fraction
{
	private:
		int numerator; //分子
		int denominator; //分母

	public:
		fraction(int x = 0, int y = 1);  
		int GetNumerator();
		int GetDenominator();
		friend fraction& operator +(fraction &A, fraction &B);
		friend fraction& operator -(fraction &A, fraction &B);
		friend fraction& operator *(fraction &A, fraction &B);
		friend fraction& operator /(fraction &A, fraction &B);
		friend int operator <(fraction&A, fraction &B);
		friend int FracionGetGCD(int a, int b); //求分子分母的最大公约数
};
