using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerIntro : MonoBehaviour
{
    public float speed;
    private Animator anima;
    public static bool run;
    public Button startBtn;
    // Start is called before the first frame update
    void Start()
    {
        anima = GetComponent<Animator>();
        startBtn.interactable = false;
        run = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!run)
        {
            if (transform.position.x < 0)
                transform.Translate(speed * Time.deltaTime, 0f, 0f);
            else
            {
                anima.SetBool("Idle", true);
                startBtn.interactable = true;
            }
        }
        else
        {
            anima.SetBool("Idle", false);
            anima.SetBool("Run", true);
            transform.Translate(speed * Time.deltaTime, 0f, 0f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "obstacle")
        {
            SceneManager.LoadScene("Game");
        }
    }
}
