#!/bin/bash

echo "Input names in the following format: Jane_Doe John_Doe >>>"
read nm_list

echo "Enter class name"
read class_name

cd "The Nova Folder"

mkdir $class_name
cd $class_name

mkdir $nm_list

cd ..
cd ..

cd "Nova Profiles"
touch $class_name
echo $nm_list > $class_name

echo Process Complete
echo =================
echo "Your folders have been created in The Nova Folder/$class_name"
echo "A config file has been saved ... Nova Profiles/$class_name"

echo "Created by Aarav Hattangadi (VI-A)[2020-21]"
exit
