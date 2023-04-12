#include<iostream>
#include"Levenshtein.h"
#include<iomanip>
#include"LCH.h"
#include"LCS.h"
using namespace std;
void main() {
	setlocale(LC_ALL, "rus");
	
	/*char S1[300] = Leven::generateString(300);
	char *S2 = Leven::generateString(200);*/
	clock_t t1 = 0, t2 = 0, t3, t4;
	char x[] = "abcdefghklmnoxm",
		 y[] = "xyabcdefghomnkm";
	int  lx = sizeof(x) - 1,
		 ly = sizeof(y) - 1;
	std::cout << std::endl;
	std::cout << std::endl << "-- расстояние Левенштейна -----" << std::endl;
	std::cout << std::endl << "--длина --- рекурсия -- дин.програм. ---"
		<< std::endl;
	for (int i = 8; i < std::min(lx, ly); i++)
	{
		t1 = clock();
		Leven::levenshtein_r(i, x, i - 2, y);
		t2 = clock();
		t3 = clock();
		Leven::levenshtein(i, x, i - 2, y);
		t4 = clock();
		std::cout << std::right << std::setw(2) << i - 2 << "/" << std::setw(2) << i
			<< "        " << std::left << std::setw(10) << (t2 - t1)
			<< "   " << std::setw(10) << (t4 - t3) << std::endl;
	}
	system("pause");
	///////////////////////////////////////////////////////////////////////////////////////////
	char z[100] = "";
	char x1[] = "BXWAFRE",
		y1[] = "XCDUFR";
	clock_t start1 = clock();
	/*char* x1= Leven::generateString(300);
	char* y1= Leven::generateString(200);*/
	
	int l = lcsd(x1, y1, z);
	
	std::cout << std::endl
		<< "-- наибольшая общая подпоследовательость - LCS(динамическое"
		<< "программирование)" << std::endl;
	std::cout << std::endl << "последовательость X: " << x1;
	std::cout << std::endl << "последовательость Y: " << y1;
	std::cout << std::endl << "                LCS: " << z;
	std::cout << std::endl << "          длина LCS: " << l;
	std::cout << std::endl;
	clock_t end1 = clock();
	cout << "Время затраченное на нахождение обшей подпоследовательности(ДП): " << ((float)end1 - (float)start1) / CLOCKS_PER_SEC << " сек.\n";
	system("pause");
	///////////////////////////////////////////////////////////////////////////////////////////
	/*char X[] = "BXWAFRE", Y[] = "XCDUFR";*/
	std::cout << std::endl << "-- вычисление длины LCS для X и Y(рекурсия)";
	std::cout << std::endl << "-- последовательность X: " << x1;
	std::cout << std::endl << "-- последовательность Y: " << y1;
	clock_t start2 = clock();
	int s = lcs(
		sizeof(x1) - 1,  // длина   последовательности  X   
		x1,       // последовательность X
		sizeof(y1) - 1,  // длина   последовательности  Y
		y1       // последовательность Y
	);
	clock_t end2 = clock();
	std::cout << std::endl << "-- длина LCS: " << s << std::endl;
	
	cout << "Время затраченное на нахождение обшей подпоследовательности(рекурсия): " << ((float)start2 - (float)end2) / CLOCKS_PER_SEC << " сек.\n";
	system("pause");
}