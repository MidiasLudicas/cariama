using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasMenuController : MonoBehaviour
{
    [Header("Canvas")]
    public GameObject canvasMenu;
    //public GameObject canvasUi;
    public GameObject startBut;
    public Text counter;

    [Header("StartGame")]
    //public GameObject Player;
    Player playerScript;
    //PlayerMovement playerScript;
    
    public void Start()
    {
        Time.timeScale = 1;
        
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && startBut.activeSelf)
        {
            StartCoroutine(EnableCanvasUi());
        }
    }

    public void StartGame()
    {
        StartCoroutine(EnableCanvasUi());
    }

    IEnumerator EnableCanvasUi()
    {
        startBut.SetActive(false);
        counter.gameObject.SetActive(true);
        counter.text = "READY!";

        yield return new WaitForSeconds(2);

        counter.text = "3";

        yield return new WaitForSeconds(1);

        counter.text = "2";

        yield return new WaitForSeconds(1);

        counter.text = "1";

        yield return new WaitForSeconds(1);

        counter.gameObject.SetActive(false);

        canvasMenu.SetActive(false);

       
        Player.canMove = true;
        
        //canvasUi.SetActive(true);
    }
}
