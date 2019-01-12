#pragma once
#include "stdafx.h"
#include "fraction.h"

fraction& fraction:: operator = (fraction a)
{
	numerator = a.numerator;
	denominator = a.denominator;
	return *this;
}

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