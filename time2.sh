#!/bin/bash

declare -i x;
declare -i y;

gcc bubbleSort.c -o bubbleSort; 

./bubbleSort & temp=$(echo "$!") &
top -b -n 1 > /home/pi/Desktop/data.txt;

echo $temp;

#cat /home/pi/Desktop/data.txt | grep $temp


#49 - 53



















# for i in {-20..19}
# do 
#     for j in {-20..19}
#     do
#         start=$(date +%s.%N);
#         sudo nice -n $i ./fibLoop &
#         sudo nice -n $j ./bubbleSort &
#         wait;
#         dur=$(echo "$(date +%s.%N) - $start" | bc);
#         echo "$i $j $dur" >> /home/pi/Desktop/data.txt;
#         if (( $(echo "$temp > $dur" |bc -l) ))
#         then
#             temp=$dur;
#             x=$i;
#             y=$j;
#         fi
#     done
# done

# echo "Best: $x $y $temp" >> /home/pi/Desktop/data.txt;