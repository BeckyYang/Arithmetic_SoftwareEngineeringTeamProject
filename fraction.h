/*
------------------------
л��ѩ ѧ�ţ�1120161761
------------------------
*/

#pragma once
#include <stdio.h>
#include <iostream>

using namespace std;

class fraction
{
	private:
		int numerator; //����
		int denominator; //��ĸ

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
