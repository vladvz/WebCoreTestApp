Web site publishing
===================
1. Add pre-publishing scripts into .cproj file.
2. Start Visual Studio in Adminstrator mode.
3. Make sure that these apps are installed globally:
npm install bower -g
npm install gulp -g
npm install ng -g

4. dotnet publish -c Release (less errors comparing to Visual Studio publishing)

Test/run in Production mode
===========================
Requires SSL - http://shawn.me/testsslaspnetcore or
1. config.json - add "DisableSSL" : "false"
2. Update Startup.cs: if (_env.IsProduction() && _config["DisableSSL"] != "true")
3. If run from published dir then execute this command first: set DisableSSL=true