#!/bin/bash

gcc fibLoop.c -o fibLoop;
gcc bubbleSort.c -o bubbleSort;

for i in {-20..19}
do 
    for j in {-20..19}
    do
        start=$(date +%s.%N);
        nice -n $i ./fibLoop &
        nice -n $j ./bubbleSort;
        dur=$(echo "$(date +%s.%N) - $start" | bc);
        echo "$i $j $dur" >> /home/pi/Desktop/data.txt;
    done
done


