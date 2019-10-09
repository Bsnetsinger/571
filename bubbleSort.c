#include <stdio.h>
#include <stdlib.h>

int main()
{
    
    int A[1000];
	srand(0);

	int i;

	for(i=0; i<1000; i++)
	{
		A[i] = rand();
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

    return 0;

}