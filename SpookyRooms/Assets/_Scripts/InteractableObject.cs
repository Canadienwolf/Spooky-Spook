using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public GameObject pickupText;
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                gameObject.SetActive(false);
            }
        }
    }
}
