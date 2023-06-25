using System.Diagnostics;
using Debug = UnityEngine.Debug;

namespace GameApp;

public class A : UnityEngine.MonoBehaviour
{
    private void Start()
    {
        Debug.Log("A Start");
        this.Loop();
    }

    async void Loop()
    {
        for (int i = 0; i < 10; i++)
        {
            await Task.Delay(1000);
            Debug.Log(i);
        }

        Debug.Log(new StackTrace());
        throw new Exception("Loop end");
    }
}