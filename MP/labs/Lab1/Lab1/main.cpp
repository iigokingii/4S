#include <iostream>
#include"Auxil.h"
#include <ctime>

#define CYCLE 1000000

using namespace std;

int fibonachi(int end) {
	if (end == 0)
		return 0;
	if (end == 1)
		return 1;
	else {
		return fibonachi(end - 1)+fibonachi(end-2);
	}
}
void main() {
	setlocale(LC_CTYPE, "Ru");
	double av1 = 0, av2 = 0;
	clock_t t1 = 0, t2 = 0;
	Auxil::start();
	t1 = clock();
	for (int i = 0; i < CYCLE; i++)
	{
		av1 += (double)Auxil::iget(-100, 100);
		av2 += Auxil::dget(-100, 100);
	}
	t2 = clock();
	cout << "\nколичество циклов:         " << CYCLE;
	cout << "\nсреднее значение (int):    " << av1 / CYCLE;
	cout << "\nсреднее значение (double): " << av2 / CYCLE;
	cout << "\nпродолжительность (у.е):   " << (t2 - t1);
	cout << "\n                  (сек):   " <<((double)(t2 - t1)) / ((double)CLOCKS_PER_SEC);
	cout << endl;
	

	const int a = 45;
	clock_t t3 = 0, t4 = 0;

	t3 = clock();
	
	for (int number = 0; number < a; number++)
	{
		cout << fibonachi(number)<<"\n";
	}

	t4 = clock();

	cout << "\n\nНомер числа, которое необходимо было вычислить : " << a;
	cout << "\nпродолжительность (у.е):                           " << (t4 - t3);
	cout << "\n                  (сек):                           " << ((double)(t4 - t3)) / ((double)CLOCKS_PER_SEC);
	cout << endl;
	system("pause");



}
