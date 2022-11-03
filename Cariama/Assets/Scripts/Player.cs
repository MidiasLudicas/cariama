using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb2d;
    public float jumpVelocity;
    public GameObject cam;
    BoxCollider2D col;
    SpriteRenderer sprite;
    int jump;
    int x;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        x = 2;
        jump = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Run
        transform.Translate(speed * Time.deltaTime, 0f, 0f);

        //Windows
        //if (Application.platform == RuntimePlatform.WindowsEditor)
        //{
            //Jump
            if (Input.GetKeyDown(KeyCode.Space) && jump < 2)
            {
                rb2d.velocity = Vector2.up * jumpVelocity;
                jump += x;
            }
            //Duck
            if (Input.GetKey(KeyCode.Z))
            {
                //col.size = new Vector2(1, .75f);
                transform.localScale = new Vector2(1, .5f);
            }
            else if (Input.GetKeyUp(KeyCode.Z))
            {
                //col.size = new Vector2(1, 1.5f);
                transform.localScale = new Vector2(1, 1);
            }
        //}
        //if (Application.platform == RuntimePlatform.Android)
        //{

        //}
        //Camera
        cam.transform.position = new Vector3(transform.position.x + 5, transform.position.y, -10);
        if (cam.transform.position.x <= 5)
        {
            cam.transform.position = new Vector3(5, cam.transform.position.y, -10);
        }
        else if (cam.transform.position.x >= 89)
        {
            cam.transform.position = new Vector3(89, cam.transform.position.y, -10);
        }
        if(cam.transform.position.y <= 0)
        {
            cam.transform.position = new Vector3(cam.transform.position.x, 0, -10);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "coin")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "jump")
        {
            Destroy(collision.gameObject);
            x /= 2;
        }
        if(collision.gameObject.tag == "obstacle")
        {
            SceneManager.LoadScene(0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "platform")
        {
            jump = 0;
        }
    }
}
