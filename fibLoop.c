#include <stdio.h>

int main()
{
    int sum = 1; 
    int current = 1, prev = 0;

    while(1){
        while(current < 200)
        {
            sum = current + prev;
            prev = current;
            current = sum;
        }

        return 0;

    }
    

}

