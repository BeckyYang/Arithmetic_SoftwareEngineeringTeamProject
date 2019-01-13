/*
------------------------
���ܣ�����������Ŀ���
���ߣ������
���ڣ�2019.01.12
-------------------------
*/
#include<iostream>
#include<cstdio>
#include<cstdlib>
#include<cstring>
#include<string>
#include<algorithm>
#include<stack>
#include<fstream>
#include<math.h>

using namespace std;

stack<long long int> Data; //����
stack<char> Operator;  
stack<long long int> Numerator;//����
stack<long long int> Denominator;//��ĸ
string result;
int PowModel = 0;//Ĭ�ϳ˷�Ϊ ^
string userAnswer;

#pragma region MainFunc
bool CheckQuestion(string Question);
void Clear();//���ջ
void Calculate(string Question);
void UserGUI();
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

bool CheckQuestion(string Question) {
	int i = 0;
	while (Question[i] != '/' && Question[i] != '=') {
		i++;
	}
	
	if (Question[i] == '=') {
		return true;
	}
	if (Question[i] == '/') {
		i++;
	}
	if (Question[i] >= '0' && Question[i] <= '9') {
		return false;
	}
	else if (Question[i] == ' ') {
		return true;
	}
	return false;
}
void ReadInt(string Question) {
	for (int i = 0; Question[i] != '='; i++) {
		//------------�ո� + ������-----------
		if (Question[i] == ' ') {
			continue;
		}
		if (Question[i] == '(') {
			Operator.push('(');
			continue;
		}
		//---------------���ֲ���---------------
		int number = 0;
		if (Question[i] >= '0' && Question[i] <= '9') {
			while (Question[i] >= '0' && Question[i] <= '9') {
				number = number * 10 + Question[i] - '0';
				i++;
			}
			i--;
			Data.push(number);
			continue;
		}
		//----------------����� + ����----------------
		if ((Question[i] < '0' || Question[i] > '9') && Question[i] != ' ') {
			if (Question[i] == ')') {//��ǰ�����Ϊ������
				while (Operator.top() != '(') {
					Integer();
				}
				Operator.pop();
			}
			else if (Question[i] == '^') {//��ǰ�����Ϊ�˷�,ֱ�ӷ���ջ�м���
				Operator.push(Question[i]);
			}
			else if(Question[i] != '^'){//�����ǰ�������Ϊ�˷�
				if (Question[i] == '(') {
					Operator.push(Question[i]);
					continue;
				}
				while (!Operator.empty() && Operator.top() == '^') {//�ȼ���֮ǰ�������ĳ˷������ҵ���
					Integer();
				}
				if (!Operator.empty() &&( Operator.top() == '*' || Operator.top() == '/' ) ) {//��ջ��Ԫ�ز�Ϊ�˷��󣬳˳�������
					while (!Operator.empty() && (Operator.top() != '+' && Operator.top() != '-' && Operator.top()!='(')) {
						Integer();
					}
				}
				if (!Operator.empty() && (Question[i] == '+' || Question[i] == '-')) {//ͬһ���ȼ�����������
					while (!Operator.empty() && Operator.top() != '(') {
						Integer();
					}
				}
				Operator.push(Question[i]);
			}			
		}
	}
}
void ReadFraction(string Question) {
	for (int i = 0; Question[i] != '='; i++) {
		//---------------------���Ŵ���-------------
		if (Question[i] == '(') {   //������ֱ����ջ
			Operator.push('(');
			i++;//����֮��Ŀո�
			continue;
		}
		if (Question[i] == ')') {//�����Ų���ջ���������ֱ����������ջ�������һ��������
			while (!Operator.empty() && Operator.top() != '(') {
				Fraction();
			}
			Operator.pop();//����������
			i++;//����֮��ո�
			if (Question[i] == '=') {
				return;
			}
			continue;
		}
		//--------------------���ӷ�ĸ����---------------------
		int number = 0;
		int flag = 0;
		while (Question[i] >= '0' && Question[i] <= '9') {
			flag = 1;
			number = number * 10 + Question[i] - '0';
			i++;
		}
		if (flag != 0 && Question[i] == '/') {//��һλΪ / ��Ϊ����
			Numerator.push(number);
			continue;
		}
		else if (flag != 0 && Question[i] == ' ') {
			Denominator.push(number);
			continue;
		}
		//--------------------�������ջ + ����-------------------------
		if (Question[i] == ' ') {
			char before = Question[i - 1];
			if (Operator.empty() || Operator.top() == '(') {//���ջΪ�գ�����ջ��Ԫ��Ϊ�����ţ���ô���������ջ,Ȼ������
				Operator.push(before);
				continue;
			}
			else {
				if (!Operator.empty() && (before == '+' || before == '-')) {
					while (!Operator.empty() && Operator.top() != '(') {//�Ӽ���֮ǰ�ĳ˳��Ӽ���Ҫ����
						Fraction();
					}
					
				}
				else if (!Operator.empty() &&(before == '*' || before == '/')) {//�˳���֮ǰ�ĳ˳���Ҫ����
					if (!Operator.empty() && Operator.top() != '+' && Operator.top() != '-') {
						Fraction();
					}
				}
				Operator.push(before);
			}
		}
	}
}
void Integer() {
	char op = Operator.top();
	long long int temp1 = Data.top();
	Data.pop();
	long long int temp2 = Data.top();
	long long int ans = 0;
	if (op == '+') {
		ans = temp1 + temp2;
	}
	else if (op == '-') {
		ans = temp2 - temp1;
	}
	else if (op == '*') {
		ans = temp1 * temp2;
	}
	else if (op == '/') {
		ans = temp2 / temp1;
	}
	else if (op == '^') {
		ans = pow(temp2, temp1);
	}
	Data.top() = ans;
	Operator.pop();
}
void CalInt() {
	while (Data.size() > 1 && Operator.size() > 0) {
		Integer();
	}
	result = Transform(Data.top());
}
int gcd(int x, int y) {
	return y == 0 ? x : gcd(y, x%y);
}
int lcm(int x, int y) {
	return x * y / gcd(x, y);
}
void Fraction() {
	int numerator1 = 1;
	numerator1 = Numerator.top();
	Numerator.pop();
	int numerator2 = 1;
	numerator2 = Numerator.top();
	Numerator.pop();
	int numerator3 = 1;

	int denominator1 = 1;
	denominator1 = Denominator.top();
	Denominator.pop();
	int denominator2 = 1;
	denominator2 = Denominator.top();
	Denominator.pop();
	int denominator3 = 1;

	char op = Operator.top();
	//------------�Ӽ��˳�-----------
	if (op == '+' || op == '-') {
		denominator3 = lcm(denominator1, denominator2);
		numerator1 *= denominator3 / denominator1;
		numerator2 *= denominator3 / denominator2;
		if (op == '+') {
			numerator3 = numerator2 + numerator1;
		}
		else {
			numerator3 = numerator2 - numerator1;
		}
	}
	else if (op == '*') {
		numerator3 = numerator1 * numerator2;
		denominator3 = denominator1 * denominator2;
	}
	else if (op == '/') {
		numerator3 = numerator2 * denominator1;
		denominator3 = denominator2 * numerator1;
	}
	//-------------�����Ϊ����---------
	if (numerator3 * denominator3 < 0) {
		numerator3 = numerator3 < 0 ? numerator3 : 0 - numerator3;
		denominator3 = abs(denominator3);
	 }

	Numerator.push(numerator3);
	Denominator.push(denominator3);
	Operator.pop();
}
void Simple() {
	int gg = gcd(Numerator.top(), Denominator.top());;
	gg = abs(gg);
	Numerator.top() /= gg;
	Denominator.top() /= gg;
}
void CalFraction() {
	while (!Operator.empty()) {
		Fraction();
	}
	//---------�������-------------
	if (Numerator.top() == 0) {//����Ϊ 0
		result = "0";
		return;
	}
	
	int temp = 0;
	temp = Numerator.top() / Denominator.top();

	if (abs(temp) == 1 && (abs(Numerator.top()) - abs(Denominator.top()) == 0)) { //���Ϊ ��1
		result = Transform(temp);
		return;
	}

	Numerator.top() = Numerator.top() % Denominator.top();
	Simple();
	//------------���Ϊ�����---------
	result = Transform(Numerator.top()) + "/" + Transform(Denominator.top());
	//------------���Ϊ�ٷ���----------
	if (abs(temp) > 0) {
		result = Transform(temp) + "+" + result;
	}
	
}
void Clear() {
	while (!Data.empty()) {
		Data.pop();
	}
	while (!Operator.empty()) {
		Operator.pop();
	}
	while (!Numerator.empty()) {
		Numerator.pop();
	}
	while (!Denominator.empty()) {
		Denominator.pop();
	}
}
string Transform(int data) {
	string str;
	int temp = 0;
	if (data < 0) {
		temp = 1;
	}
	data = abs(data);
	if (data == 0) { //����Ϊ0�����
		return "0";
	}
	while (data != 0) {
		char ch[2];
		ch[0] = data % 10 + '0';
		ch[1] = '\0';
		str = ch + str;
		data /= 10;
	}
	if (temp == 1) {
		str = "-" + str;
	}
	return str;
}
string ToPower(string Question) {
	string Power;
	for (int i = 0,j = 0; i < Question.length(); i++) {
		if (Question[i] != '*') {
			Power[j] = Question[i];
			j++;
			continue;
		}
		else {
			i++;
			if (Question[i] != '*') {
				Power[j] = Question[i - 1];
				j++;
				Power[j] = Question[i];
				j++;
			}
			else {
				Power[j] == '^';
				j++;
			}
		}
	}
	return Power;
}
void Calculate(string Question) {
	Clear();
	if (PowModel) {
		Question = ToPower(Question);
	}
	if (CheckQuestion(Question)) {
		ReadInt(Question);
		CalInt();
	}
	else {
		ReadFraction(Question);
		CalFraction();
	}
}
void UserGUI() {
	int chance = 2;
	while (chance) {
		if (userAnswer == result) {
			cout << "Rright!" << endl;
			break;
		}
		else {
			cout << "Wrong! You have " << chance << " chance to answer." << endl;
			cin >> userAnswer;
		}
		chance--;
	}
	if (!chance) {
		cout << "So Sorry,This is right answer:" << result << endl;
	}
	cout << endl;
}
int main()
{
	string Question;
	ifstream inf;
	inf.open("puzzle1.txt");
	if (inf.fail() == true){
		cout << "Fail to open file!" << endl;
		}
	int count = 0;//���
	while (getline(inf, Question))
	{
		cout << "No." << count++ << ": " << Question << endl;
		cout << "Your answer:";
		cin >> userAnswer;
		Calculate(Question);
		UserGUI();
	}
	system("pause");
	return 0;
}