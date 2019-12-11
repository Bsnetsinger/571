#!/bin/bash

declare -i x;
declare -i y;
declare -i nice1;
declare -i nice2;

flag1=1;
flag2=1;
stop=1;

nice1=0;
nice2=19;

gcc bubbleSort.c -o bubbleSort; 
gcc insertSort.c -o insertSort;

start=$(date +%s.%N);

./bubbleSort &
PID1=$!;

sudo renice 0 $PID1;


./insertSort &
PID2=$!;

sudo renice 19 $PID2;

for i in {0..100}
do 
    top -b -n 1 > /home/pi/Desktop/data.txt;

    if [ "$flag1" ] ; then
    cat /home/pi/Desktop/data.txt | grep $PID1 | cut -c 49-53 | nl >> /home/pi/Desktop/cpu1.txt;
    cpu1="$(cat /home/pi/Desktop/data.txt | grep $PID1 | cut -c 49-53)";
    fi
    
    if [ "$flag2" ] ; then
    cat /home/pi/Desktop/data.txt | grep $PID2 | cut -c 49-53 | nl >> /home/pi/Desktop/cpu2.txt;
    cpu2="$(cat /home/pi/Desktop/data.txt | grep $PID2 | cut -c 49-53)";
    fi
    
    if(( $(echo "$cpu2 - $cpu1 == 1" |bc -l) ));then
        stop=0;
    fi

    if [ -z "$cpu1" ] && [ "$flag1"] ; then
        dur1=$(echo "$(date +%s.%N) - $start" | bc);
        flag1=0;
        stop=0;
    fi

    if [ -z "$cpu2" ] && [ "$flag2" ] ; then
        dur2=$(echo "$(date +%s.%N) - $start" | bc);
        flag2=0;
        stop=0;
    fi

    if [ -z "$cpu1" ] && [ -z "$cpu2" ] ; then
        break;
    fi

    if [ "$stop" ] ; then
        if(( $(echo "$cpu1 > $cpu2" |bc -l) ));then
            nice2=$(($nice2 - 1));
            sudo renice $nice2 $PID2;
            #echo $nice2;
        fi

        if(( $(echo "$cpu2 > $cpu1" |bc -l) ));then
            nice1=$(($nice1 - 1));
            sudo renice $nice1 $PID1;
            #echo $nice1;
        fi
    fi
    
    
done

echo "CPU1 $dur1 CPU2 $dur2" >> /home/pi/Desktop/durations.txt











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