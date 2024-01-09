using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class AsyncTask : MonoBehaviour
{
    void Start()
    {
        DoTasksAsync();
    }

    private async void DoTasksAsync()
    {
        using CancellationTokenSource cts = new CancellationTokenSource();
        {
            CancellationToken token = cts.Token;
            await Task1(token);
            await Task2(token);
        }
    }

    async private Task Task1(CancellationToken token)
    {
        await Task.Delay(1000);
        Debug.Log($"Task1 completed");
    }

    async private Task Task2(CancellationToken token)
    {
        await WaitFrame();
        Debug.Log($"Task2 completed");
    }

    private async Task WaitFrame()
    {
        for (int i = 0; i < 60; i++) 
        {
            await Task.Yield();
        }
    }
}
