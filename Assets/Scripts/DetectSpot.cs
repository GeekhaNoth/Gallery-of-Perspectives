using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectSpot : MonoBehaviour
{
    private bool onSpot = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            if (onSpot)
            {
                completioncheck.lastlevel = SceneManager.GetActiveScene().buildIndex;
                SaveCurrentLevel();
                SceneManager.LoadScene(0);
            }
            else Debug.Log("Faux");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        onSpot = true;
    }

    private void OnTriggerExit(Collider other)
    {
        onSpot = false;
    }
    
    public static void SaveCurrentLevel()
    {
        PlayerPrefs.SetInt("Current", completioncheck.lastlevel);
    }

    public static void LoadCurrentLevel()
    {
        completioncheck.lastlevel = PlayerPrefs.GetInt("Current");
    }
}