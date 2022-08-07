using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeScene : MonoBehaviour
{
    public int sceneNumber;

    public void Fade()
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void setScene(int number)
    {
        sceneNumber = number;
    }
}
