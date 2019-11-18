using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
public class JobControllerFib : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            LaunchJob();
        }
    }
    protected void LaunchJob()
    {
        int num = 1000;
        NativeArray<int> result = new NativeArray<int>(num, Allocator.TempJob);
        FibonacciJob fibJob = new FibonacciJob(num, ref result);
        JobHandle handle = fibJob.Schedule();
        handle.Complete();
        for (int i = 0; i < num; ++i)
        {
            Debug.Log(result[i]);
        }
        result.Dispose();
    }
}