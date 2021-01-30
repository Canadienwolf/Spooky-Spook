using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SendToScene : MonoBehaviour
{
    public void NextScene(int _idx)
    {
        SceneManager.LoadScene(_idx, LoadSceneMode.Single);
    }
}
