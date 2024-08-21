using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetManager : MonoBehaviour
{
    [SerializeField] private GameObject[] planets;
    [SerializeField] private int howMany;
    void Start()
    {
        howMany += Random.Range(1,-1);
        for (int i = 0; i < howMany; i++) 
        {
            Instantiate(planets[Random.Range(0,planets.Length)], transform.position, Quaternion.identity);
        }
    }

    public void restart()
    {
        ES3.Save<int>("coins", (int)(ES3.Load<int>("coins") * 0.9f));
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void time()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 2;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void Menu() 
    {
        SceneManager.LoadScene(0);
    }
}
