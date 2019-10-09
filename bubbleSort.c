#include <stdio.h>

int main()
{
    
    int A[20] = {3,8,1,9,7,2,0,4,6,5, 10,15,16,11,18,12,17,13,19,14} ;
     int size = 20;

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