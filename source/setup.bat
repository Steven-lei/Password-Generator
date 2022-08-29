@echo off
cd %~dp0
echo running path:%cd%
call initproject.bat /wait
call installexpress.bat /wait
call installejs /wait
call installcookie-parser.bat /wait
echo install finished
pause
