gcc bubbleSort.c -o bubbleSort;
start=$(date +%s.%N);
./bubbleSort;
dur=$(echo "$(date +%s.%N) - $start" \ bc);
echo "$dur" >> Desktop/data.txt;
