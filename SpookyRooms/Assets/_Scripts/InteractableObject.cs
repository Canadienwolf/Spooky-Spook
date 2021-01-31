using System;
using System.Collections;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public GameObject pickupText;

    public bool pickedUp = false;
    private GameObject handToFollow;
    private bool stopMe;

    private void Start()
    {
        handToFollow = GameObject.FindGameObjectWithTag("Hand");
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pickupText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pickupText.gameObject.SetActive(false);
        }
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && pickupText.activeSelf)
        {
            pickedUp = !pickedUp;
            stopMe = true;
            //StartCoroutine(waitingTime(0f));
        }
        
        if (pickedUp)
        {
            gameObject.transform.position = handToFollow.transform.position;
        } 
    }
    
    IEnumerator waitingTime(float time)
    {
        if (!pickedUp)
        {
            pickedUp = true;
            yield return new WaitForSeconds(time);
            stopMe = false;

        }

        else if(pickedUp)
        {
            pickedUp = false;
            yield return new WaitForSeconds(time);
            stopMe = false;
        }
        
        yield return null;
    }
}
