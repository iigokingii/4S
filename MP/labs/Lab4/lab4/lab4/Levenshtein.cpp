//levenshtein.cpp
#include <iomanip>
#include<iostream>
#include <algorithm>
#include "Levenshtein.h"
#define DD(i,j) d[(i)*(ly+1)+(j)] 
namespace Leven {
	int min3(int x1, int x2, int x3)
	{
		return std::min(std::min(x1, x2), x3);
	}

	int levenshtein(int lx, const char x[], int ly, const char y[])
	{
		int* d = new int[(lx + 1) * (ly + 1)];
		for (int i = 0; i <= lx; i++)
			DD(i, 0) = i;
		for (int j = 0; j <= ly; j++)
			DD(0, j) = j;
		for (int i = 1; i <= lx; i++)
			for (int j = 1; j <= ly; j++)
			{
				DD(i, j) = min3(DD(i - 1, j) + 1, DD(i, j - 1) + 1,
					DD(i - 1, j - 1) + (x[i - 1] == y[j - 1] ? 0 : 1));
			}
		return DD(lx, ly);
	}

	int levenshtein_r(
		int lx, const char x[],
		int ly, const char y[]
	)
	{
		int rc = 0;
		if (lx == 0) rc = ly;
		else  if (ly == 0) rc = lx;
		else  if (lx == 1 && ly == 1 && x[0] == y[0]) rc = 0;
		else  if (lx == 1 && ly == 1 && x[0] != y[0]) rc = 1;
		else  rc = min3(
			levenshtein_r(lx - 1, x, ly, y) + 1,
			levenshtein_r(lx, x, ly - 1, y) + 1,
			levenshtein_r(lx - 1, x, ly - 1, y) + (x[lx - 1] == y[ly - 1] ? 0 : 1)
		);
		return rc;
	};
	char* generateString(int len) {
		char *arr = new char[len];
		char symbols[27] = "abcdefghijklmnopqrstuvwxyz";
		int random;
		for (size_t i = 0; i < len; i++)
		{
			random = rand() % 26;
			arr[i] = symbols[random];
		}
		std::cout << "Generated string:";
		for (size_t i = 0; i < len; i++)
		{
			if (i % 50 == 0) {
				std::cout << std::endl;
			}
			std::cout << arr[i];
		}
		std::cout << std::endl<<std::endl;
		return arr;
	}


}

