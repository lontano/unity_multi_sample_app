using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

  [MenuItem("Tools/Build/Build Android")]
  public static void BuildAll()  
  {
    BuildAndroid();
    BuildWindows();
  }

    [MenuItem("Tools/Build/Build Android")]
  public static void BuildAndroid()
  {
    BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
    buildPlayerOptions.scenes = new[] { "Assets/Scenes/SampleSCene.unity" };
    buildPlayerOptions.locationPathName = "Build/unity_multi_sample.apk";
    buildPlayerOptions.target = BuildTarget.Android;
    buildPlayerOptions.options = BuildOptions.None;

    BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
    BuildSummary summary = report.summary;

    if (summary.result == BuildResult.Succeeded)
    {
      Debug.Log(message: "Build succeded: " + summary.totalSize + " bytes");
    }
    if (summary.result == BuildResult.Failed)
    {
      Debug.Log(message: "Build failed");
    }
  }

  [MenuItem("Tools/Build/Build Windows")]
  public static void BuildWindows()
  {
    BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
    buildPlayerOptions.scenes = new[] { "Assets/Scenes/SampleSCene.unity" };
    buildPlayerOptions.locationPathName = "Build/unity_multi_sample.exe";
    buildPlayerOptions.target = BuildTarget.StandaloneWindows;
    buildPlayerOptions.options = BuildOptions.None;

    BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
    BuildSummary summary = report.summary;

    if (summary.result == BuildResult.Succeeded)
    {
      Debug.Log(message: "Build succeded: " + summary.totalSize + " bytes");
    }
    if (summary.result == BuildResult.Failed)
    {
      Debug.Log(message: "Build failed");
    }
  }
}
