using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PathCreator : MonoBehaviour
{
    public Transform pathParent;
    public List<Vector2> pathPoints = new List<Vector2>();
    public PathsCollection collection;

    public void GeneratePath()
    {
        pathPoints = new List<Vector2>();

        foreach (Transform _child in pathParent)
        {
            pathPoints.Add(_child.position);
        }
    }

    public void AddPath()
    {
        Path _path = new Path(pathPoints);
        collection.paths.Add(_path);
        pathPoints = new List<Vector2>();
    }
}
