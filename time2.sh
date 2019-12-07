#!/bin/bash

declare -i x;
declare -i y;
declare -i nice1;
declare -i nice2;

nice1=0;
nice2=0;

gcc bubbleSort.c -o bubbleSort; 
gcc insertSort.c -o insertSort;

./bubbleSort &
PID1=$!;

./insertSort &
PID2=$!;

for i in {0..5}
do 
    top -b -n 1 > /home/pi/Desktop/data.txt;

    cat /home/pi/Desktop/data.txt | grep $PID1 | cut -c 49-53 | nl >> /home/pi/Desktop/cpu1.txt;
    cpu1="$(cat /home/pi/Desktop/data.txt | grep $PID1 | cut -c 49-53)";

    cat /home/pi/Desktop/data.txt | grep $PID2 | cut -c 49-53 | nl >> /home/pi/Desktop/cpu2.txt;
    cpu2="$(cat /home/pi/Desktop/data.txt | grep $PID2 | cut -c 49-53)";

    if(( $(echo "$cpu1 > $cpu2" |bc -l) ));then
        nice2=$nice2 - 1;
        renice $nice2 $PID2;
        echo $nice2;
    fi

    if(( $(echo "$cpu2 > $cpu1" |bc -l) ));then
        nice1=$nice1 - 1;
        renice $nice1 $PID1;
        echo $nice1;
    fi

done












# for i in {-20..19}
# do 
#     for j in {-20..19}
#     do
#         start=$(date +%s.%N);
#         sudo nice -n $i ./fibLoop &
#         sudo nice -n $j ./bubbleSort &
#         wait;
#        dur=$(echo "$(date +%s.%N) - $start" | bc);
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