To start with the TestingWhiz automated testing tool you have to follow the steps:

1. Install TestingWhiz Community Edition - \\bec-hyperv03\Software\Software\Development\testingWhizSetup Community 4.4.1.exe

2. Grab BodgeIt tool from developers. 
   It is used for environment preparation such as database.
   Sample location: C:\GitRepositories\BEF\Applications\Bec.TargetFramework\MainLine\Tools\BodgeIt\bin\Dev

3. Register that path in the global PATH variable.
   For windows, open command line (ctrl+r, then type cmd) and then type: 
   setx PATH "%PATH%;C:\GitRepositories\BEF\Applications\Bec.TargetFramework\MainLine\Tools\BodgeIt\bin\Dev"

4. Use scripts making sure all of them are under source control so everyone can track the changes!