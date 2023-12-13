@echo off
set /P message=Enter commit message (between ""): 

git config user.name "GONELLA"
git config user.email "a.gonella.2253@vallauri.edu"

git add -A
git commit -m %message%
git push 

git config --unset user.name 
git config --unset user.email 
git config --global --unset credential.helper

cmdkey /delete:git:https://github.com

pause