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
        Configuration = "Debug",
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

Task("PR")
    .IsDependentOn("Test");

Task("Default")
    .IsDependentOn("Build");

RunTarget(target);
