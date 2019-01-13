/*
----------------------------------
谢蜜雪 学号：1120161761
日期：2019/1/12
实现功能：分数的类fraction的源文件
----------------------------------
*/
#pragma once
#include "stdafx.h"
#include "fraction.h"

fraction::fraction(int x, int y)
{
	numerator = x;
	denominator = y;
}

int fraction::GetNumerator()
{
	return numerator;
}

int fraction::GetDenominator()
{
	return denominator;
}

int FracionGetGCD(int a, int b)
{
	return (a % b == 0) ? b : FracionGetGCD(b, a%b);
}

fraction& operator +(fraction& A, fraction &B)
{
	int x, y, z;
	x = A.numerator * B.denominator + A.denominator * B.numerator;
	y = A.denominator * B.denominator;
	z = FracionGetGCD(x, y);
	fraction f(x / z, y / z);
	return f;
}

fraction& operator -(fraction &A, fraction &B)
{
	int x, y, z;
	x = A.numerator * B.denominator - A.denominator * B.numerator;
	y = A.denominator * B.denominator;
	z = FracionGetGCD(x, y);
	fraction f(x / z, y / z);
	return f;
}

fraction& operator *(fraction &A, fraction &B)
{
	int x, y, z;
	x = A.numerator * B.numerator;
	y = A.denominator * B.denominator;
	z = FracionGetGCD(x, y);
	fraction f(x / z, y / z);
	return f;
}

fraction& operator /(fraction &A, fraction &B)
{
	int x, y, z;
	x = A.numerator * B.denominator;
	y = A.denominator * B.numerator;
	z = FracionGetGCD(x, y);
	fraction f(x / z, y / z);
	return f;
}

int operator <(fraction&A, fraction &B)
{
	int x, y, z;
	x = A.numerator * B.denominator - A.denominator * B.numerator;
	y = A.denominator * B.denominator;
	z = (x > 0 && y < 0) || (x < 0 && y > 0);
	return z;

}
