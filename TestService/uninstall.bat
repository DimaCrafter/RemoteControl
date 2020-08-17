@echo off
sc delete "RemoteControl Server"
taskkill /f /t /im "RCServer.exe"
logoff
