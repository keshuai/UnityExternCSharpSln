namespace GameApp.Editor;
using UnityEngine;

public class TestMenuItem
{
    [UnityEditor.MenuItem("Test/LogEnvironment.CurrentDirectory")]
    private static void Test()
    {
        Debug.Log("MenuItem 中文啊");
        Debug.Log($"Environment.CurrentDirectory: {Environment.CurrentDirectory}");
    }
}