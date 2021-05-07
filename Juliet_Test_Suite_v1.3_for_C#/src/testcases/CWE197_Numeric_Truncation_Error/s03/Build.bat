
rem NOTE: this batch file is to be run in a Visual Studio command prompt

rem set omitbad/omitgood variables
set omitbad=false
set omitgood=false

rem Delete old files
rmdir /Q /S bin
rmdir /Q /S obj

rem Build Solution
if %omitbad%==true (msbuild -p:DefineConstants=OMITBAD) else (if %omitgood%==true (msbuild -p:DefineConstants=OMITGOOD) else (msbuild))