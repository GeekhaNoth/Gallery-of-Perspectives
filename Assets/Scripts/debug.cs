using UnityEngine;

public class debug : MonoBehaviour
{
    public string[] allLevelEditor = { "1", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" };
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        completioncheck.allLevel = allLevelEditor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
