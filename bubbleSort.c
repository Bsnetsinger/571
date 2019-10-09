int main()
{
    int A[8] = {3,8,1,9,7,2,0,4} ;
    int size = 8;

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

}