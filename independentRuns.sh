#!/bin/bash


start=$(date +%s.%N);
sleep 0.851111111;
temp=$(echo "$(date +%s.%N) - $start" | bc);

gcc fibLoop.c -o fibLoop;
gcc bubbleSort.c -o bubbleSort;
x=0.00;
y=0.00;

for i in {0..100}
do 
    start=$(date +%s.%N);
    ./fibLoop;
    dur=$(echo "$(date +%s.%N) - $start" | bc);
    x=$(echo "$x + $dur" | bc);
done

for j in {0..100}
do 
    start=$(date +%s.%N);
    ./bubbleSort;
    dur2=$(echo "$(date +%s.%N) - $start" | bc);
    y=$(echo "$y + $dur2" | bc);
done

echo "100 Runs of fibLoop: $x \n 100 Runs of bubbleSort: $y" >> /home/pi/Desktop/runTimes.txt;