Task("Local-Test")
    .Does(() =>
{
    DotNetCoreRun("./demo/demo.csproj");
});
