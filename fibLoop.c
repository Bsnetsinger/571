#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int main()
{
    clock_t start_t, end_t;

	double total_t;
	
	start_t = clock();

    float count = 0;
    float sum = 1; 
    float current = 1, prev = 0;

    while(count < 12500000){
        while(current < 700000000)
        {
            sum = current + prev;
            prev = current;
            current = sum;
        }
        sum = 1;
        current = 1;
        prev = 0;
        count += 1;
    }
    end_t = clock();

	total_t = ((double)(end_t - start_t)) / CLOCKS_PER_SEC; 

    FILE * f;
	f = fopen("/home/pi/Desktop/fibLoopTimes.txt", "a");
	fprintf(f, "%f\n", total_t);

    return 0;

}

