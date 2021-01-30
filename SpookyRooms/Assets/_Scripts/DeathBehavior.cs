using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBehavior : MonoBehaviour
{
    public int deathSceneIndex = 2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(deathSceneIndex, LoadSceneMode.Single);
        }
    }
}
