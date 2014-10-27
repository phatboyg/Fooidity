#r @"packages/FAKE/tools/FakeLib.dll"
open Fake

let buildMode = "Release" //"Debug"
let testDlls = !! (sprintf "./**/bin/%s/*.Tests.dll" buildMode)
let solution = !! ("./src/*.sln")

Target "Build" (fun _ ->
  MSBuild null "Build" ["Configuration", buildMode] solution
    |> Log "AppBuild-Output"
)

Target "Test-Unit" (fun _ ->
  testDlls
    |> NUnit (fun p ->
      {p with
        DisableShadowCopy = true;
        ToolPath = "packages/NUnit.Runners/tools";
        Framework = "net-4.5";
        OutputFile = "TestResults.xml"})
)

Target "Go" (fun _ ->
  trace "go"
)

"Build"
  ==> "Test-Unit"
  ==> "Go"

// start build
RunTargetOrDefault "Go"
