#load nuget:?package=Cake.Recipe&version=3.1.1

var standardNotificationMessage = "Version {0} of {1} has just been released, it will be available here https://www.nuget.org/packages/{1}, once package indexing is complete.";

Environment.SetVariableNames();

BuildParameters.SetParameters(
  context: Context,
  buildSystem: BuildSystem,
  sourceDirectoryPath: "./src",
  title: "Spectre.Console.Registrars.Microsoft-Di",
  masterBranchName: "main",
  repositoryOwner: "nils-org",
  twitterMessage: standardNotificationMessage,
  preferredBuildProviderType: BuildProviderType.GitHubActions,
  shouldRunDotNetCorePack: true,
  shouldUseDeterministicBuilds: true
  );

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(context: Context);

Build.RunDotNetCore();
