using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsCount : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    private void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        if (!ES3.KeyExists("coins"))
        {
            ES3.Save<int>("coins", 0);
        }
        textMeshPro.text = ES3.Load("coins").ToString();
    }
}
