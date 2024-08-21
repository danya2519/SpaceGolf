using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rocket : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool didFly = false;
    [SerializeField] private LineRenderer line;
    [SerializeField] private GameObject testFly;
    [SerializeField] private Sprite[] skins;
    private float vectorToMove;

    private void Start()
    {
        StartCoroutine(wait());
        SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        GetComponent<Animator>().enabled = false;
        if (!ES3.KeyExists("skin"))
        {
            ES3.Save<string>("skin", "roc");
        }
        if(ES3.Load<string>("skin") == "roc")
        {
            spriteRenderer.sprite = skins[0];
            print(spriteRenderer.sprite.name);
        }
        else if(ES3.Load<string>("skin") == "imp")
        {
            spriteRenderer.sprite = skins[1];
        }
        else if (ES3.Load<string>("skin") == "bul")
        {
            spriteRenderer.sprite = skins[2];
        }
        else
        {
            spriteRenderer.sprite = skins[3];
        }
    }

    public void Move(bool isUp)
    {
        if(isUp && transform.position.y + 0.2 < 2.80f || !isUp && transform.position.y - 0.2 > -2.80f)
        {
            if (isUp)
            {
                vectorToMove = 5f;
            }
            else
            {
                vectorToMove = -5f;
            }
            transform.position = new Vector3(transform.position.x, transform.position.y + vectorToMove * Time.deltaTime, transform.position.z);
        }
        else
        {
            vectorToMove = 0;
        }
    }

    public void Stop()
    {
        vectorToMove = 0;
    }

    public void fly()
    {
        if (!didFly)
        {
            GetComponent<Rigidbody2D>().simulated = true;
            line.gameObject.SetActive(false);
            Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
            GetComponent<Rigidbody2D>().AddForce((Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position) * speed, ForceMode2D.Impulse);
            didFly = true;
        }
    }

    private void Update()
    {
        if (!didFly && transform.position.y + 0.2 < 2.80f && transform.position.y - 0.2 > -2.80f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + vectorToMove * Time.deltaTime, transform.position.z);
        }
    }

    public void restart()
    {
        if(!(ES3.Load<int>("coins") - 15 <= 0))
        {
            ES3.Save<int>("coins", ES3.Load<int>("coins") - 15);
        }
        

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.5f);
        if(Input.GetMouseButton(0) && !didFly)
        {
            GameObject newObject = Instantiate(testFly, transform.position, transform.rotation);
            newObject.GetComponent<Rigidbody2D>().AddForce((Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position) * speed, ForceMode2D.Impulse);
            Destroy(newObject, 3);
        }

        StartCoroutine(wait());
    }
}
