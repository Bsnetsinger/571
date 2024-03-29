#!/bin/bash
 
declare -i x;
declare -i y;
declare -i nice;
 
nice=0;
flag1=1;
flag2=1;
stop=1;
 
read -p 'File: ' userFile
read -p 'CPU Percentage: ' userP
 
gcc $userFile -o userFile;
 
gcc insertSort.c -o insertSort;
 
start=$(date +%s.%N);
 
./insertSort &
PID2=$!;

start=$(date +%s.%N);

./userFile &
PID1=$!;
 
while [ $stop -eq 1 ]
do 
    
    top -b -n 1 > /home/pi/Desktop/data.txt;
    
    data1="$(cat /home/pi/Desktop/data.txt | grep $PID1 | cut -c 20-23,49-53)";
    cpu1="$(cat /home/pi/Desktop/data.txt | grep $PID1 | cut -c 49-53)";
    
    cat /home/pi/Desktop/data.txt | grep $PID2 | cut -c 20-23,49-53 | nl >> /home/pi/Desktop/cpu2.txt;
    cpu2="$(cat /home/pi/Desktop/data.txt | grep $PID2 | cut -c 49-53)";
    
    diff=$(echo "$cpu1 - $userP" | bc);
    
    if [ -z "$cpu1" ] ; then
        break;
    fi
    
    if(( $(echo "$diff < -25" |bc -l) ));then
         nice=$(($nice - 2));
        sudo renice $nice $PID1;
    fi

    if [ -z "$cpu1" ] ; then
        break;
    fi
     
    if(( $(echo "($diff > -25) && ($diff < -5)" |bc -l) ));then
        nice=$(($nice - 1));
        sudo renice $nice $PID1;
    fi
    
    if(( $(echo "($diff > -5) && ($diff < 0)" |bc -l) ));then
        if [ "$flag1" -eq "1" ] ; then
            dur=$(echo "$(date +%s.%N) - $start" | bc);
            flag1=0;
        fi
    fi
 
    if [ -z "$cpu1" ] ; then
        break;
    fi

    if(( $(echo "$diff > 25" |bc -l) ));then
        nice=$(($nice + 2));
        sudo renice $nice $PID1;
    fi
 
    if [ -z "$cpu1" ] ; then
        break;
    fi

    if(( $(echo "($diff < 25) && ($diff > 5)" |bc -l) ));then
        nice=$(($nice + 1));
        sudo renice $nice $PID1;
    fi

    if [ -z "$cpu1" ] ; then
        break;
    fi

    if(( $(echo "($diff < 5) && ($diff > 0)" |bc -l) ));then
        if [ "$flag1" -eq "1" ] ; then
            dur=$(echo "$(date +%s.%N) - $start" | bc);
            flag1=0;
        fi
    fi

    x=$(($x + 1));

    echo "$x $data1" >> /home/pi/Desktop/x.txt;
    
    if [ "$x" -eq "30" ] ; then
        ./insertSort &
        echo $!;
    fi

done

killall insertSort;
 
echo "Time: $dur" >> /home/pi/Desktop/time.txt
 
 
 
     # if [ -z "$cpu1" ] && [ "$flag1" -eq "1" ] ; then
    #     dur1=$(echo "$(date +%s.%N) - $start" | bc);
    #     flag1=0;
    #     stop=0;
    # fi
 
    # if [ -z "$cpu2" ] && [ "$flag2" -eq "1" ] ; then
    #     dur2=$(echo "$(date +%s.%N) - $start" | bc);
    #     flag2=0;
    #     stop=0;
    # fi
 
    # if [ -z "$cpu1" ] && [ -z "$cpu2" ] ; then
    # break;
    # fi
 
    # if [ "$stop" -eq "1" ] ; then
    #     if(( $(echo "$cpu1 > $cpu2" |bc -l) ));then
    #         nice2=$(($nice2 - 1));
    #         sudo renice $nice2 $PID2;
    #         nice1=$(($nice1 + 1));
    #         sudo renice $nice1 $PID1;
    #         #echo $nice2;
    #     fi
 
    #     if(( $(echo "$cpu2 > $cpu1" |bc -l) ));then
    #         nice1=$(($nice1 - 1));
    #         sudo renice $nice1 $PID1;
    #         nice2=$(($nice2 + 1));
    #         sudo renice $nice2 $PID2;
    #         #echo $nice1;
    #     fi
    # fi
 
 
 
 
 
 
 
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

