using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector3 = System.Numerics.Vector3;

public class SpawnSystem : MonoBehaviour
{
    //---------------------------------Public--------------------------------------------
    
    public GameObject[] Rooms;
    
    
    //---------------------------------Private--------------------------------------------
    
    private int index;
    private GameObject roomToSpawm;
    
    
    // Start is called before the first frame update
    void Start()
    {
        index = Random.Range(0, Rooms.Length);
        roomToSpawm = Rooms[index];
        Instantiate(roomToSpawm, new UnityEngine.Vector3(0,0,0),quaternion.identity);
        
    }
}
