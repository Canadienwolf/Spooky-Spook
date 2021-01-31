using UnityEngine;

public class PitBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Candy"))
        {
            print("Kill");
            Ghost.Kill(1f);
        }
    }
}
