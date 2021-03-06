using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    //---------------------------------Public--------------------------------------------
    
    public GameObject[] Rooms;
    public GameObject instructionText;
    
    
    //---------------------------------Private--------------------------------------------
    
    private int index;
    private GameObject roomToSpawm;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //index = Random.Range(0, Rooms.Length);
        //roomToSpawm = Rooms[index];
        //Instantiate(roomToSpawm, new UnityEngine.Vector3(0,0,0),quaternion.identity);
        StartCoroutine(instructionTimer(5f));
    }

    IEnumerator instructionTimer(float time)
    {
        yield return new WaitForSeconds(time);
        instructionText.SetActive(false);
    }
}
