using System;
using UnityEngine;
using UnityEngine.Scripting;

public static class GarbageCollectionManager
{
    public static void DisableGC()
    {
        #if !UNITY_EDITOR
        GarbageCollector.GCMode = GarbageCollector.Mode.Disabled;
        #endif
    }

    public static void CollectGarbage()
    {
        #if !UNITY_EDITOR
        GarbageCollector.GCMode = GarbageCollector.Mode.Enabled;
        GC.Collect();
        GarbageCollector.GCMode = GarbageCollector.Mode.Disabled;
        #endif
    }
}
