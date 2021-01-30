using System;
using System.Collections;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public GameObject pickupText;

    public bool pickedUp;
    private GameObject handToFollow;
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            handToFollow = gameObject.;
            pickupText.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (pickedUp)
                {
                    pickedUp = false;
                }

                if (!pickedUp)
                {
                    pickedUp = true;
                }


            }

            /*
            if (Input.GetKeyDown(KeyCode.E) && pickedUp);
            {
                pickedUp = false;

                StartCoroutine(waitingTime(100f));
                print("Good vodoo");
            }
            */
        }
    }

    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            pickupText.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (pickedUp)
        {
            gameObject.transform.position = handToFollow.transform.position;
        } 
    }

    //might not be needed?
    IEnumerator waitingTime(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
