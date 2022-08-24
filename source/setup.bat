@echo off
cd %~dp0
echo running path:%cd%
echo install epress
npm install express
echo install ejs
npm install ejs
echo install cookie-parser
npm install cookie-parser
echo init project
npm init
pause
