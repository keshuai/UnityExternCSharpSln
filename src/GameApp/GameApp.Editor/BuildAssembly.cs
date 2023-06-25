using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace GameApp.Editor;

public class BuildAssembly
{
    [UnityEditor.MenuItem("Build/Runtime")]
    private static void BuildRuntime()
    {
        if (!Execute(GetPath("src/GameApp/GameApp/publish_to_unity.bat"), out var error))
        {
            Debug.Log($"Build Runtime failure: {error}");
        }
        else
        {
            Debug.Log($"Build Runtime success");
            AssetDatabase.Refresh();
        }
    }
    
    [UnityEditor.MenuItem("Build/Editor")]
    private static void BuildEditor()
    {
        if (!Execute(GetPath("src/GameApp/GameApp.Editor/publish_to_unity.bat"), out var error))
        {
            Debug.Log($"Build Editor failure: {error}");
        }
        else
        {
            Debug.Log($"Build Runtime success");
            AssetDatabase.Refresh();
        }
    }

    private static string GetPath(string path)
    {
        var dir = Path.GetDirectoryName(Application.dataPath);
        return Path.Combine(dir, path);
    }

    private static bool Execute(string command, out string error)
    {
        var process = new Process()
        {
            StartInfo = new ProcessStartInfo()
            {
                FileName = "cmd.exe",
                Arguments = $"/c {command}",
                WorkingDirectory = Path.GetDirectoryName(command),
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
            }
        };

        process.Start();
        process.WaitForExit();

        // 获取输出和错误信息
        //string output = process.StandardOutput.ReadToEnd();
        error = process.StandardError.ReadToEnd();
        return string.IsNullOrEmpty(error);
    }
}