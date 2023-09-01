using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGeneric : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ontriggerenter 2d layer player destroy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            // destroy the gameObject
            Destroy(gameObject);
        }
    }

}
