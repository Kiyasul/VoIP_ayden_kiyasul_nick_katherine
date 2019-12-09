#!/bin/bash
echo
echo CPU MEMORY AND RESOURCES---------------------
#Pull CPU information from uptime and store to a variable
a=$(uptime | awk -F users, '{print $2}')
echo CPU ${a//  } 
OUTPUT=$(free -m | grep Mem: | awk '{print $4}')
echo FREE RAM: $OUTPUT MB
echo
echo CURRENT LINUX VERSION AND DISTROBUTION---------------
LINUXV=$(cat /proc/version)
echo $LINUXV
echo

echo NETWORK CONNECTIONS--------------------------
loR=$(column -t /proc/net/dev | grep lo | awk '{print $2}') 
loT=$(column -t /proc/net/dev | grep lo | awk '{print $10}')
enp0s3T=$(column -t /proc/net/dev | grep usb0 | awk '{print $10}')
enp0s3R=$(column -t /proc/net/dev | grep usb0 | awk '{print $2}')
echo lo:
echo Bytes Received: $loR
echo Bytes Transmitted: $loT
echo usb0:
echo Bytes Received: $enp0s3R
echo Bytes Transmitted: $enp0s3T
#Ping a server to see if you have internet connection
ping -c 3 8.8.8.8 2>&1 >/dev/null
retVal=$?
if [ $retVal -ne 0 ]; then
	echo Internet Connectivity: NO
else
	echo Internet Connectivity: YES
fi
echo

#Pull information from the /etc/passwd directory and store to variables
NOLOGIN=$(cat /etc/passwd | grep /sbin/nologin | wc -l)
BASH=$(cat /etc/passwd | grep /bin/bash | wc -l)
FALSE=$(cat /etc/passwd | grep /bin/false | wc -l)
TUSERS=$(cat /etc/passwd | wc -l)
USER=$(who | wc -l)
echo ACCOUNT INFORMATION--------------------------
echo Total Users: $TUSERS
echo Number Active: $USER
echo SHELLS:
echo /sbin/nologin: $NOLOGIN
echo /bin/bash: $BASH
echo /bin/false: $False

echo

#Display the number of processes
PROCESS=$(ps -aux| wc -l)
PROCESSES=$(ps)
echo PROCESS INFORMATION-----------------------
echo Total Number of Running Processes: $PROCESS
echo Running Processes: $PROCESSES
echo 
#Pull file and directory # information and store to a variable
FILES=$(find / -type f 2> /dev/null | wc -l)
DIRECTORIES=$(find / -type d 2> /dev/null | wc -l)
echo FILESYSTEM INFORMATION-----------------------
echo Total Number of Files: $FILES
echo Total Number of Directories: $DIRECTORIES
echo
