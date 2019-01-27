using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public void EnterGame()
    {
        SceneManager.LoadScene(SceneManager.GetSceneAt(SceneManager.GetActiveScene().buildIndex + 1).name);
    }
}
