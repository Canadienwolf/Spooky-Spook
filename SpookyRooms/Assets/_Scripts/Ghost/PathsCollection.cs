using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class PathsCollection : ScriptableObject
{
    public List<Path> paths = new List<Path>();
}

[System.Serializable]
public struct Path
{
    public List<Vector2> path;

    public Path(List<Vector2> _path)
    {
        path = _path;
    }
}
