using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void Cenas(string cena)
    {
        SceneManager.LoadScene(cena);
    }
    public void Run()
    {
        PlayerIntro.run = true;
    }
}
