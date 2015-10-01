To start with the TestingWhiz automated testing tool you have to follow the steps:

1. Install TestingWhiz Community Edition - \\bec-hyperv03\Software\Software\Development\testingWhizSetup Community 4.4.1.exe

2. Grab BodgeIt tool from developers. 
   It is used for environment preparation such as database.
   Sample location: C:\GitRepositories\BEF\Applications\Bec.TargetFramework\MainLine\Tools\BodgeIt\bin\Debug

3. Register the directory in the global PATH variable by using:
   setx PATH "%PATH%;C:\GitRepositories\BEF\Applications\Bec.TargetFramework\MainLine\Tools\BodgeIt\bin\Debug"

4. Use scripts making sure all of them are under source control so everyone can track the changes!

5. After opening the test script check the environment details before starting the test!

   In Methods section you will find PrepareEnvironment method which defines two entry points:
   - BodgeIt command - "bodgeit.exe -CleanData -Dev"
     Cleans up the data and adds T1 user to start with.
     Possible values for environment specific tests are:
	 * -Local - http://localhost:9000/ and localhost DB
	 * -Dev - http://dev-as-01.bec.local:9000/ and dev DB
	 * -Sys - http://sys-as-01.bec.local:9000/ and sys DB
	 * -Uat - http://uat-as-01.bec.local:9000/ and uat DB
   - Base Application URL - "https://dev-ws-01/"
     Recommended values: 
	 * https://localhost:44300/
	 * https://dev-ws-01/
	 * https://sys-ws-01/
	 * https://uat-ws-01/