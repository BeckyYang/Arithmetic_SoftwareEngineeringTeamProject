/*
------------------------
谢蜜雪 学号：1120161761
------------------------
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
		//friend fraction operator +(fraction a, fraction b);
		//friend fraction operator -(fraction a, fraction b);
		//friend fraction operator *(fraction a, fraction b);
		//friend fraction operator /(fraction a, fraction b);
		//friend fraction operator ^(fraction a, fraction b);
		fraction& operator = (fraction a);
		int GetNumerator();
		int GetDenominator();

};
