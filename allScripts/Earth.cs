using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Earth : MonoBehaviour
{
    private void Start()
    {
        transform.position = new Vector2(transform.position.x, Random.Range(-4f, 4f));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            ES3.Save<int>("coins", ES3.Load<int>("coins") + 10);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
