using UnityEngine;

public class debug : MonoBehaviour
{
    
    //ce script permet de modifier durant le runtime l'état de complétion de chaque niveau indépendemment car impossible à faire avec la valeur de base car static
    
    
    
    public string[] allLevelEditor = { "1", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" };
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        completioncheck.allLevel = allLevelEditor;
    }
}
