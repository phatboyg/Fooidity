#r @"src/packages/FAKE/tools/FakeLib.dll"
open Fake
open Fake.AssemblyInfoFile

let buildMode = "Release" //"Debug"
let testDlls = !! (sprintf "./**/bin/%s/*.Tests.dll" buildMode)
let solution = !! ("./src/*.sln")
let nunit = findToolFolderInSubPath "nunit-console.exe" "src/packages/nunit.runners"

let PRODUCT = "Fooidity"

//props
let output = "build_output"
let artifacts = "build_artifacts"

Target "Build" (fun _ ->
  CreateCSharpAssemblyInfo "./src/SolutionVersion.cs"
        [Attribute.Title PRODUCT
         Attribute.Description "An implementation switching library"
         Attribute.Guid "A539B42C-CB9F-4a23-8E57-AF4E7CEE5BAD"
         Attribute.Product PRODUCT
         Attribute.Version "0.1.0.0"
         Attribute.FileVersion "0.1.0.0"]

  MSBuild null "Build" ["Configuration", buildMode] solution
    |> Log "AppBuild-Output"
)

Target "Test-Unit" (fun _ ->
  testDlls
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
  [output; artifacts]
    |> List.iter FileHelper.CleanDir
)

"Build"
  ==> "Test-Unit"
  ==> "Go"

// start build
RunTargetOrDefault "Go"
