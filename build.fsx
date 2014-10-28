#r @"src/packages/FAKE/tools/FakeLib.dll"
open Fake
open Fake.AssemblyInfoFile
open Fake.FileSystem

let buildMode = "Release";
let VERSION = "0.1.0.0"

type BuildInfo = {
  product: string;
  description: string;
  mode: string;
  testDlls: FileIncludes;
  integrationDlls: FileIncludes;
  solutions: FileIncludes;
  output: string;
  artifacts: string;

}
let props = {
  product="Fooidity";
  description="An implementation switching library"
  mode=buildMode;
  output="build_output";
  artifacts="build_artifacts";
  testDlls= !! (sprintf "./**/bin/%s/*.Tests.dll" buildMode);
  integrationDlls= !! (sprintf "./**/bin/%s/*.IntegrationTests.dll" buildMode);
  solutions= !! ("./src/*.sln");
}

let nunit = findToolFolderInSubPath "nunit-console.exe" "src/packages/nunit.runners"


Target "Build" (fun _ ->
  CreateCSharpAssemblyInfo "./src/SolutionVersion.cs"
        [Attribute.Title props.product
         Attribute.Description props.description
         Attribute.Guid "A539B42C-CB9F-4a23-8E57-AF4E7CEE5BAD"
         Attribute.Product props.product
         Attribute.Version VERSION
         Attribute.FileVersion VERSION]

  MSBuild null "Build" ["Configuration", props.mode] props.solutions
    |> Log "AppBuild-Output"
)

Target "Test-Unit" (fun _ ->
  props.testDlls
    |> NUnit (fun p ->
      {p with
        DisableShadowCopy = true;
        ToolPath = nunit;
        Framework = "net-4.5";
        OutputFile = "TestResults.xml"})
)

Target "Go" (fun _ ->
  trace "go"
)

Target "Clean" (fun _ ->
  [props.output; props.artifacts]
    |> List.iter FileHelper.CleanDir
)

Target "NuGet" (fun _ ->
  NuGet (fun p ->
        {p with
            Authors = ["Chris Patterson"]
            Project = props.product
            Description = props.description
            OutputPath = props.output
            Summary = props.description
            WorkingDir = ""
            Version = VERSION
            AccessKey = ""
            Publish = false })
            "Fooidity.nuspec"
)

"Build"
  ==> "Test-Unit"
  ==> "Go"

// start build
RunTargetOrDefault "Go"
