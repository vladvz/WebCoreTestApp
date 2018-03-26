# WebCoreTestApp
When EF migrations fails due to "access denied" issue use conn. string with absolute path to db:
"WebCoreConnectionString": "server=(localdb)\\ProjectsV13;Database=WebCore;Integrated Security=true;MultipleActiveResultSets=true;AttachDbFileName=C:\\Applications\\Localdb\\WebCore.mdf"
