#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int main()
{
	time_t start = time(NULL);
  

    int A[1000];
	srand(0);

	int i;

	for(i=0; i<1000; i++)
	{
		A[i] = 1000 - i;
	}

    int size = 1000;

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

	time_t end = time(NULL);

	int runTime = end - start;

	file = fopen("/home/pi/Desktop/bubbleSortTimes.txt", "a");
	fprintf(file, "%d", runTime);

    return 0;

}