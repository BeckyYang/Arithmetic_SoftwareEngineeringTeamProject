/*
----------------------------
���ߣ������
���ڣ�2019.01.13
���ܣ�����������Ŀ���ͷ�ļ�
----------------------------
*/
#pragma once
#include <string.h>
#include <stdio.h>
#include <iostream>

using namespace std;

#pragma region MainFunc
bool CheckQuestion(string Question);
void Clear();//���ջ
void Calculate(string Question);
void UserGUI(string user_answer);
string Transform(int data);//����ֵת��Ϊ�ַ���
#pragma endregion

#pragma region Integer
void ReadInt(string Question);
void Integer();//+-*/^
void CalInt();//ȷ��OperatorջΪ��
string ToPower(string Question);//�� ** ת��Ϊ ^
#pragma endregion

#pragma region Fraction
void ReadFraction(string Question);
int gcd(int x, int y);//�����Լ��
int lcm(int x, int y);//��С������ = ������� / �����Լ��
void Fraction();//+-*/
void CalFraction();
void Simple();//�������
#pragma endregion