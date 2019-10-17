#!/bin/bash
gcc fibLoop.c -o fibLoop;
start=$(date +%s.%N);
./fibLoop;
dur=$(echo "$(date +%s.%N) - $start" | bc);
echo "$dur" >> /home/pi/Desktop/data.txt;
