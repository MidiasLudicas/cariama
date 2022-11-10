using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarroPrefabController : MonoBehaviour
{
    [SerializeField]
    float forca;
    Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.AddForce(Vector2.left * forca, ForceMode2D.Impulse);

        InvokeRepeating("DestruirInimigo", 5f, 5f);
    }

    public void DestruirInimigo()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
    /*
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "platform")
        {
            Destroy(gameObject);
        }
    }
    */
}
