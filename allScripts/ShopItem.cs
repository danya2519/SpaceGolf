using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    
    void Start()
    {
        if(!ES3.KeyExists(gameObject.name + "unlock"))
        {
            ES3.Save<bool>(gameObject.name + "unlock", false);
        }
        else if (ES3.Load<bool>(gameObject.name + "unlock"))
        {
            foreach (Transform t in transform)
            {
                t.gameObject.SetActive(false);
            }
        }
    }

    public void Click()
    {
        if(ES3.Load<bool>(gameObject.name + "unlock"))
        {
            if (ES3.Load<string>("skin") != gameObject.name)
            {
                ES3.Save<string>("skin", gameObject.name);
            }
            else
            {
                ES3.Save<string>("skin", "roc");
            }
        }
        else if(ES3.Load<int>("coins") >= int.Parse(GetComponentInChildren<TextMeshProUGUI>().text))
        {
            ES3.Save<int>("coins", ES3.Load<int>("coins") - int.Parse(GetComponentInChildren<TextMeshProUGUI>().text));
            ES3.Save<bool>(gameObject.name + "unlock", true);
            foreach (Transform t in transform)
            {
                t.gameObject.SetActive(false);
            }
        }
    }

}
