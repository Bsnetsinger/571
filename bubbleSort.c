#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int main()
{
	time_t start, end;
	time(&start);
  

    int A[10000000];
	srand(0);

	int i;

	for(i=0; i<10000000; i++)
	{
		A[i] = 1000 - i;
	}

    int size = 10000000;

	for(int i=0; i<size; i++)
	{
		for(int j=0; j<size-1; j++)
		{
			if( A[j] > A[j+1] )
			{
				int temp = A[j];
				A[j] = A[j+1];
				A[j+1] = temp;
			}
		}
	}

	time(&end);

	double runTime = difftime(end, start);

	FILE * f;
	f = fopen("/home/pi/Desktop/bubbleSortTimes.txt", "a");
	fprintf(f, "%d", runTime);

    return 0;

}