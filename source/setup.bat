@echo off
cd %~dp0
echo running path:%cd%
echo install epress
npm install express
echo install ejs
npm install ejs
echo init project
npm init -y
pause
