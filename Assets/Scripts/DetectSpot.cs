using System;
using UnityEngine;

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
        
    }

    private void OnTriggerEnter(Collider other)
    {
        onSpot = true;
        Debug.Log("ouiiiii");
    }

    private void OnTriggerExit(Collider other)
    {
        onSpot = false;
    }
    
}