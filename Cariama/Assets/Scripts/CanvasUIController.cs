using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasUIController : MonoBehaviour
{
    [Header("Pontua??o")]
    public Image PointsIcon;
    public Text PointsText;

    [Header("Vidas")]
    public Text LifeText;

    [Header("Config")]
    public GameObject ConfigPanel;

    [Header("Canvas Final")]
    public GameObject canvasFinal;

    public void Start()
    {
        Config();
    }

    public void Config()
    {
        ConfigPanel.SetActive(!ConfigPanel.activeSelf);

        if (ConfigPanel.activeSelf == true)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
