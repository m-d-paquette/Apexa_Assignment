@echo off

:: Navigate to the API directory
cd API

:: Build and run the .NET Core API
dotnet build
start dotnet run --launch-profile http

:: Navigate to the web directory
cd ../web

:: Install dependencies and start the ReactJS application
npm install
start npm start

:: Wait for user input before closing the script
pause