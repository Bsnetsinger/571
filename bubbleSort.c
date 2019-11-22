#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int main()
{
	time_t start, end;
	time(&start);
  

    int A[1000];
	srand(0);

	int i;

    int size = 1000;
	int loop = 0;

	while(loop < 1000)
	{
		for(i=0; i<1000; i++)
		{
			A[i] = 1000 - i;
		}
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

		loop += 1;
	}

	time(&end);

	double runTime = double(end - start);

	FILE * f;
	f = fopen("/home/pi/Desktop/bubbleSortTimes.txt", "a");
	fprintf(f, "%f", runTime);

    return 0;

}