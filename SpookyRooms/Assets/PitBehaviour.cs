using UnityEngine;

public class PitBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (CompareTag("Candy"))
        {
            Ghost.Kill(1f);
        }
    }
}
