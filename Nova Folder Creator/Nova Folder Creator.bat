@echo off

color 70

SET /P names="Input names in following format:  John_Doe Jane_Doe >>>  "

SET /P config_name="Enter Name of class  >>>  "


cd "The Nova Folder"

md %config_name%
cd %config_name%

md %names%

cd ..



cd ..

    cd "Nova Profiles"
    echo %names% > %config_name%.txt
    echo Config File Saved in %cd%\Nova Profiles

    echo Your Folders have been created in %cd%\The Nova Folder

pause