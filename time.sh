#!/bin/bash

declare -i x;
declare -i y;

start=$(date +%s.%N);
sleep 0.851111111;
temp=$(echo "$(date +%s.%N) - $start" | bc);

gcc fibLoop.c -o fibLoop;
gcc bubbleSort.c -o bubbleSort;

for i in {-20..19}
do 
    for j in {-20..19}
    do
        start=$(date +%s.%N);
        sudo nice -n $i ./fibLoop &
        sudo nice -n $j ./bubbleSort;
        dur=$(echo "$(date +%s.%N) - $start" | bc);
        echo "$i $j $dur" >> /home/pi/Desktop/data.txt;
        if (( $(echo "$temp > $dur" |bc -l) ))
        then
            temp=$dur;
            x=$i;
            y=$j;
        fi
    done
done

echo "Best: $x $y $temp" >> /home/pi/Desktop/data.txt;


