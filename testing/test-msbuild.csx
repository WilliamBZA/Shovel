Require<Scrape>();

// Demonstrate MSBuild wrapper

"Build"
	.DependsOn("Dependency")
	.MsBuild(msb =>
		{
			msb.ArbitraryArgs("/nologo", "/detailedsummary");
			msb.Project = @"test-msbuild\test-msbuild.csproj";
			msb.Targets("Clean", "Compile");
		});

	// .MsBuild(new MsBuildProperties()
	// 	{
	// 		ArbitraryArgs = new [] {"arg1", "arg2"},
	// 		Project = "the-project-name.csproj",
	// 		Targets = new[]{"Clean", "Compile"}});

"Dependency"
	.Do(() =>
		{
			Console.WriteLine("Do some stuff here...");
		});

	// .Action(() =>
	// 	MsBuild.Run(msb =>
	// 	{
	// 		msb.Project = "test-msbuild.csproj";
	// 		msb.Targets = new[] {"Clean", "Compile"};
	// 	}));

	// .Action(() =>
	// 	MsBuild
	// 		.Project(@"test-msbuild\test-msbuild.csproj")
	// 		.Targets("Clean", "Compile")
	// 		.Build());

"Build".Run();