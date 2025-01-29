using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectSpot : MonoBehaviour
{
    private bool _onSpot = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            if (_onSpot) //vérifie si le joueur est au bon endroit pour valider le niveau
            {
                PlayerPrefs.SetInt("OnSpot", 1);
                
            }
            else PlayerPrefs.SetInt("OnSpot", 0);
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _onSpot = true;
    }

    private void OnTriggerExit(Collider other)
    {
        _onSpot = false;
    }
}