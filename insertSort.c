#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int main()
{
	clock_t start_t, end_t;

	double total_t;
	
	start_t = clock();
  

    int A[1000];
	srand(0);

	int i, j;

    int size = 1000;
	int loop = 0;

	int i, key, j;
    while(loop < 6500)
    {
        for(i=0; i<1000; i++)
		{
			A[i] = 1000 - i;
		} 
        for (i = 1; i < size; i++) 
        {  
             key = A[i];  
            j = i - 1;  

            while (j >= 0 && A[j] > key) 
            {  
                A[j + 1] = A[j];  
                j = j - 1;  
            }  
            A[j + 1] = key;  
        }

    }

	end_t = clock();

	total_t = ((double)(end_t - start_t)) / CLOCKS_PER_SEC;

	FILE * f;
	f = fopen("/home/pi/Desktop/insertSortTimes.txt", "a");
	fprintf(f, "%f\n", total_t);
    return 0;

}