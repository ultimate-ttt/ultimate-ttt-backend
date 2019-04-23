#addin "nuget:?package=Cake.Sonar&version=1.1.18"
#tool "nuget:?package=MSBuild.SonarQube.Runner.Tool&version=4.3.1"

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////
var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////
var testOutputDir = Directory("./testoutput");
var publishOutputDir = Directory("./artifacts");
var sourceDir = Directory("./src");

var version = EnvironmentVariable<string>("Version", default(string));

var sonarLogin = EnvironmentVariable<string>("Sonar_Token", default(string));
var sonarPrKey = EnvironmentVariable<string>("Sonar_Pr_Key", default(string));
var sonarBranch = EnvironmentVariable<string>("Sonar_Branch", default(string));

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////
Task("Clean")
    .Does(() =>
    {
        CleanDirectory(testOutputDir);
        CleanDirectory(publishOutputDir);
        DotNetCoreClean(sourceDir);
    });

Task("Restore")
    .IsDependentOn("Clean")
    .Does(() =>
    {
        DotNetCoreRestore(sourceDir);
    });

Task("Build")
    .IsDependentOn("Restore")
    .Does(() =>
{
    var settings = new DotNetCoreBuildSettings
    {
        Configuration = configuration,
        NoRestore = true,
    };

    DotNetCoreBuild("./src/UltimateTicTacToe.sln", settings);
});

Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
{
    int i = 0;
    var testSettings = new DotNetCoreTestSettings
    {
        Configuration = configuration,
        ResultsDirectory = $"./{testOutputDir}",
        Logger = "trx",
        NoRestore = true,
        NoBuild = true,
        ArgumentCustomization = args => args
            .Append("/p:CollectCoverage=true")
            .Append("/p:Exclude=[xunit.*]*")
            .Append("/p:CoverletOutputFormat=opencover")
            .Append($"/p:CoverletOutput=\"../../{testOutputDir}/full_{i++}\" --blame")
    };

    foreach(var file in GetFiles("./src/**/*.Tests.csproj"))
    {
        DotNetCoreTest(file.FullPath, testSettings);
    }
});

Task("PublishApi")
    .IsDependentOn("Clean")
    .IsDependentOn("Restore")
    .IsDependentOn("Build")
    .IsDependentOn("Test")
    .Does(() =>
    {
      var settings = new DotNetCorePublishSettings
      {
        Framework = "netcoreapp2.1",
        Configuration = configuration,
        OutputDirectory = publishOutputDir,
      };

      DotNetCorePublish("./src/Api/Api.csproj", settings);
    });

Task("SonarBegin")
    .Does(() =>
{
    SonarBegin(new SonarBeginSettings
    {
        Url = "https://sonarcloud.io",
        Login = sonarLogin,
        Key = "ultimate-ttt-backend",
        Organization = "ultimate-ttt",
        VsTestReportsPath = "**/*.trx",
        OpenCoverReportsPath = "**/*.opencover.xml",
        Exclusions = "**/*.js,**/*.html,**/*.css",
        Verbose = false,
        Version = version,
        ArgumentCustomization = args => {
            var a = args;

            if(!string.IsNullOrEmpty(sonarPrKey))
            {
                a = a.Append($"/d:sonar.pullrequest.key=\"{sonarPrKey}\"");
                a = a.Append($"/d:sonar.pullrequest.branch=\"{sonarBranch}\"");
                a = a.Append($"/d:sonar.pullrequest.base=\"master\"");
                a = a.Append($"/d:sonar.pullrequest.provider=\"github\"");
                a = a.Append($"/d:sonar.pullrequest.github.repository=\"ultimate-ttt/ultimate-ttt-backend\"");
            }

            return a;
        }
    });
});

Task("SonarEnd")
    .Does(() =>
{
    SonarEnd(new SonarEndSettings
    {
        Login = sonarLogin,
    });
});

Task("Default")
  .IsDependentOn("Build")
  .IsDependentOn("Test");

Task("PR")
    .IsDependentOn("SonarBegin")
    .IsDependentOn("Build")
    .IsDependentOn("Test")
    .IsDependentOn("SonarEnd");

Task("Release")
    .IsDependentOn("SonarBegin")
    .IsDependentOn("Build")
    .IsDependentOn("Test")
    .IsDependentOn("PublishApi")
    .IsDependentOn("SonarEnd");


RunTarget(target);
