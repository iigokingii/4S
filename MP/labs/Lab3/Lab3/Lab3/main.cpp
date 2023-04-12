#include<iostream>
#include<iomanip>
#include <list>
#define DIAGONAL 99999
#define LENGTH 6
using namespace std;

int matrix[LENGTH][LENGTH]{
	{DIAGONAL,9,8,4,10,0},
	{6,DIAGONAL,4,5,7,0},
	{5,3,DIAGONAL,6,2,0},
	{1,7,2,DIAGONAL,8,0},
	{2,4,5,2,DIAGONAL,0},
	{0,0,0,0,0,0},
};

struct Pair {
	int indexI;
	int indexJ;
	int Weight;
	bool included = false;
	Pair(int i, int j) {
		indexI = i;
		indexJ = j;
	}
	Pair(){}
};

int CastByColumn(int** matrix, int& countOfNull, list<Pair>& listOfIndexes, int l=0);
int CastByRow(int** matrix, int& countOfNull, list<Pair>& listOfIndexes, int l=0);
void Print(int** matrix, int length , int countOfNull=0);
Pair getMaxArcWithoutArc(list<Pair>list,int countOfNull,int**matrix);
Pair getMaxArcWithArc(list<Pair>list, int countOfNull, int** matrix, Pair* MaxPair);
void main() {
	setlocale(LC_CTYPE, "ru");
	int min;
	int countOfNull=0;
	list<Pair>listOfIndexes;
	list<Pair>nodes;
	int* p[LENGTH];
	for (int i = 0; i < LENGTH; i++)
	{
		p[i] = matrix[i];
	}
	int sumOfCastConst = 0;

	sumOfCastConst+=CastByRow(p, countOfNull, listOfIndexes);
	sumOfCastConst+=CastByColumn(p, countOfNull, listOfIndexes);
	matrix[LENGTH - 1][LENGTH - 1] = sumOfCastConst;
	Pair parent = Pair(0, 0);
	parent.Weight = sumOfCastConst;
	nodes.push_back(parent);
	
	cout << "Начальная(приведенная) матрица: " << endl;
	Print(p,LENGTH,countOfNull);
	int* SumOfCastConst = new int[countOfNull];
	for (size_t i = 0; i < countOfNull; i++)
	{
		SumOfCastConst[i] = 0;
	}

	Pair MaxPairWithoutArc = getMaxArcWithoutArc(listOfIndexes, countOfNull, p);
	matrix[MaxPairWithoutArc.indexI][MaxPairWithoutArc.indexJ] = DIAGONAL;
	for (int i = 0; i < LENGTH; i++)
	{
		p[i] = matrix[i];
	}
	Pair MaxPairWithArc = getMaxArcWithArc(listOfIndexes, countOfNull, p, &MaxPairWithoutArc);
	MaxPairWithoutArc.Weight += sumOfCastConst;
	nodes.push_back(MaxPairWithoutArc);
	MaxPairWithArc.Weight += sumOfCastConst;
	nodes.push_back(MaxPairWithArc);
	






	
	//TODO
	//Print(p,countOfNull);
}

Pair getMaxArcWithArc(list<Pair>listOfIndexes, int countOfNull, int** matrix,Pair* MaxPair) {
	int nextM[LENGTH - 1][LENGTH - 1];

	for (int i = 0; i < LENGTH - 1; i++)
	{
		for (int j = 0; j < LENGTH - 1; j++)
		{
			if (i == (*MaxPair).indexI) {
				if (j != (*MaxPair).indexJ) {
					nextM[i][j] = matrix[i + 1][j];
					continue;
				}
				else {
					nextM[i][j] = matrix[i + 1][j + 1];
					i++;
					continue;
				}
			}
			if (j == (*MaxPair).indexJ) {
				nextM[i - 1][j] = matrix[i][j + 1];
				j++;
				continue;
			}
			nextM[i - 1][j] = matrix[i][j];
		}
	}
	cout << endl << endl;
	int sumOfCastConst = 0;
	int* ptr[LENGTH - 1];
	for (int i = 0; i < LENGTH - 1; i++)
	{
		ptr[i] = nextM[i];
	}
	sumOfCastConst += CastByRow(ptr, countOfNull, listOfIndexes, 1);
	sumOfCastConst += CastByColumn(ptr, countOfNull, listOfIndexes, 1);
	Pair pa = Pair((*MaxPair).indexI, (*MaxPair).indexJ);
	pa.Weight = sumOfCastConst;
	nextM[LENGTH - 2][LENGTH - 2]= sumOfCastConst+14;
	cout << "Matrix with Arc("<< ((*MaxPair).indexI+1)<<","<< ((*MaxPair).indexJ+1)<< "):" << endl;
	Print(ptr,LENGTH-1);
	pa.included = true;
	return pa;
}




Pair getMaxArcWithoutArc(list<Pair>listOfIndexes, int countOfNull, int** matrix) {
	list<Pair>buffList;
	list<Pair>buff;
	int* SumOfCastConst = new int[countOfNull];
	for (size_t i = 0; i < countOfNull; i++)
	{
		SumOfCastConst[i] = 0;
	}
	int* BuffPointer[LENGTH];
	int buffMatrix[LENGTH][LENGTH];
	//определение дуги, которая повлечет наибольшее изменение нижней границы(дуга не включается)
	for (int k = 0; k < countOfNull; k++)
	{
		//создание копии матрицы(для определения дуги, которая повлечет наибольшее изменение нижней границы)
		int buffcountOfNull = 0;
		
		for (size_t i = 0; i < LENGTH; i++)
		{
			for (int j = 0; j < LENGTH; j++)
			{
				buffMatrix[i][j] = matrix[i][j];
			}
		}
		Pair pair = listOfIndexes.front();
		buff.push_back(listOfIndexes.front());
		listOfIndexes.pop_front();

		buffMatrix[pair.indexI][pair.indexJ] = DIAGONAL;
		
		for (int i = 0; i < LENGTH; i++)
		{
			BuffPointer[i] = buffMatrix[i];
		}
		SumOfCastConst[k] += CastByRow(BuffPointer, buffcountOfNull, buffList);
		SumOfCastConst[k] += CastByColumn(BuffPointer, buffcountOfNull, buffList);
	}
	int max = SumOfCastConst[0];
	int maxIndex = 0;
	//cout << SumOfCastConst[0] << "\t";
	for (int i = 1; i < countOfNull; i++)
	{
		//cout << SumOfCastConst[i] << "\t";
		if (max < SumOfCastConst[i]) {
			max = SumOfCastConst[i];
			maxIndex = i;
		}
	}

	for (int i = 0; i < maxIndex; i++)
	{
		buff.pop_front();
	}
	Pair MaxPair = buff.front();
	MaxPair.Weight = max;
	////////////////////////////////////////////////////////////////////////////////////////////
	cout << "Matrix without arc("<<(MaxPair.indexI+1)<<","<< (MaxPair.indexJ + 1) <<"):" << endl;
	buffMatrix[LENGTH - 2][LENGTH - 2] = max+14;

	Print(BuffPointer,LENGTH-1);
	return MaxPair;
}

void Print(int**matrix,int length, int countOfNull) {
	////////////////////////////////////////////////////////Print
	for (int i = 0; i < length; i++)
	{
		if (i + 1 == length)
			cout << endl;
		for (int j = 0; j < length; j++)
		{
			cout << setw(8) << matrix[i][j];
		}
		cout << endl;
	}
	if(countOfNull!=0)
	cout << "Number of arcs with zero weight: " << countOfNull;
	cout << endl << endl;
}

int CastByColumn(int** matrixx,int&countOfNull, list<Pair>&listOfIndexes,int l) {
	//приведение по столбцу
	int min;
	int sum = 0;
	int castConst;
	for (int i = 0; i < LENGTH - 1-l; i++)
	{
		min = matrixx[0][i];
		for (int j = 0; j < LENGTH - 1-l; j++)
		{
			if (min > matrixx[j][i])
				min = matrixx[j][i];
		}
		matrixx[LENGTH - 1-l][i] = min;
		sum += min;
	}
	for (int i = 0; i < LENGTH - 1-l; i++)
	{
		castConst = matrixx[LENGTH - 1-l][i];
		for (int j = 0; j < LENGTH - 1-l; j++)
		{
			matrixx[j][i] = matrixx[j][i] - castConst;
			if (matrixx[j][i] == 0 && castConst != 0) {
				countOfNull++;
				Pair pair = Pair(j, i);						
				listOfIndexes.push_back(pair);
			}
		}
	}
	return sum;
}
int CastByRow(int* matrix[], int& countOfNull, list<Pair>& listOfIndexes,int l) {
	//приведение по строке
	int sum = 0;
	int min;
	for (int i = 0; i < LENGTH - 1-l; i++)
	{
		min = matrix[i][0];
		for (int j = 1; j < LENGTH - 1-l; j++)
		{
			if (min > matrix[i][j])
				min = matrix[i][j];
		}
		matrix[i][LENGTH - 1-l] = min;
		sum += min;
	}
	int castConst;
	for (int i = 0; i < LENGTH - 1-l; i++)
	{
		castConst = matrix[i][LENGTH - 1-l];
		for (int j = 0; j < LENGTH - 1-l; j++)
		{
			matrix[i][j] = matrix[i][j] - castConst;
			if (matrix[i][j] == 0 && castConst != 0) {
				countOfNull++;
				Pair pair = Pair(i, j);
				listOfIndexes.push_back(pair);
			}
		}
	}
	return sum;
}
