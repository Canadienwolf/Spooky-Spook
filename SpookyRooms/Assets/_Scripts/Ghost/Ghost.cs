using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Ghost
{
    public static event Action<float> onGhostDied;
    public static event Action onStartedHunt;
    public static event Action onStartedChilling;

    public static void Kill(float _changesSceneTime)
    {
        onGhostDied?.Invoke(_changesSceneTime);
    }

    public static void Hunt()
    {
        onStartedHunt?.Invoke();
    }

    public static void Chill()
    {
        onStartedChilling?.Invoke();
    }
}
