#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int main()
{
    clock_t start_t, end_t;

	double total_t;
	
	start_t = clock();

    int sum = 1; 
    int current = 1, prev = 0;

    while(1){
        while(current < 20000)
        {
            sum = current + prev;
            prev = current;
            current = sum;
        }

        end_t = clock();

	    total_t = ((double)(end_t - start_t)) / CLOCKS_PER_SEC; 

         FILE * f;
	    f = fopen("/home/pi/Desktop/fibLoopTimes.txt", "a");
	    fprintf(f, "%f\n", total_t);

        return 0;

    }

}

