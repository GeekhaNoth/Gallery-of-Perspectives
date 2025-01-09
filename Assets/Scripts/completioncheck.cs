using System;
using UnityEngine;

public class completioncheck : MonoBehaviour
{
    public static string[] allLevel = {"1","0","0","0","0","0","0","0","0","0","0"}; //y a 10 zéros
    public static int lastlevel = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
            allLevel[lastlevel] = "1";
            DetectSpot.LoadCurrentLevel();
            Save();
            Load();
        for (int i = 1; i < allLevel.Length; i++)
        {
            if (allLevel[i] == "1")
            {
                //Indique la peinture du niveau comme validé
                Debug.Log("Niveau " + i + " validé");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (string.Join("", allLevel) == "11111111111")
        {
            Debug.Log("Jeu terminé");
        }
    }

    public static void Save()
    {
        var stringe = String.Join(",", allLevel);
        PlayerPrefs.SetString("Sauver", stringe);
    }

    public static void Load()
    {
        var stringe = PlayerPrefs.GetString("Sauver");
        allLevel = stringe.Split(',');
    }

    
}
