#!/bin/bash
declare -i x;
declare -i y;

start=$(date +%s.%N);
sleep 0.851111111;
temp=$(echo "$(date +%s.%N) - $start" | bc);

gcc fibLoop.c -o fibLoop;
gcc bubbleSort.c -o bubbleSort;
x=0.000;
y=0.000;

for i in {0..100}
do 
    start=$(date +%s.%N);
    ./fibLoop;
    dur=$(echo "$(date +%s.%N) - $start" | bc);
    x=$($x+$dur);
done
for j in {0..100}
do 
    start=$(date +%s.%N);
    ./bubbleSort;
    dur=$(echo "$(date +%s.%N) - $start" | bc);
    y=$($y+$dur);
done
echo "100 Runs of fibLoop: $x \n 100 Runs of bubbleSort: $y" >> /home/pi/Desktop/runTimes.txt;