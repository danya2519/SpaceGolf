using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int coins;

    private void Start()
    {
        transform.position = new Vector2(Random.Range(-4f, 5f), Random.Range(-4f, 4f));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            ES3.Save<int>("coins", ES3.Load<int>("coins") + coins);
            Destroy(gameObject);
        }
    }
}
