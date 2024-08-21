using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<Animator>().enabled = true;
            collision.transform.GetComponent<Animator>().SetTrigger("Destroy");
        }
    }
}
