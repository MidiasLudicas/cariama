using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInimigoController : MonoBehaviour
{
    [SerializeField]
    GameObject prefabInimigo;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CriarInimigo", 1f, 3f);

        InvokeRepeating("DestruirInimigo", 5f, 5f);
    }

    public void CriarInimigo()
    {
        Instantiate(prefabInimigo, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
