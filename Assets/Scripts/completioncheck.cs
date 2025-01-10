using System;
using UnityEngine;

public class completioncheck : MonoBehaviour
{
    public static string[] allLevel = {"1","0","0","0","0","0","0","0","0","0","0"}; //y a 10 zéros, chaque index correspond à un niveau
    public static int lastlevel = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
            DetectSpot.LoadCurrentLevel(); //récupère le niveau effectué lorsque retour au hub
            allLevel[lastlevel] = "1"; //indique le niveau correspondant comme validé
            Save(); //save si chaque niveau est validé ou non
            Load(); //récupère la liste des niveau validé ou non
            
        for (int i = 1; i < allLevel.Length; i++) //check si chaque niveau est validé ou non
        {
            if (allLevel[i] == "1") //si niveau validé alors...
            {
                //Indique la peinture du niveau comme validé
                Debug.Log("Niveau " + i + " validé");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (string.Join("", allLevel) == "11111111111") //check si tout les niveaux ont été validés
        {
            Debug.Log("Jeu terminé");
        }
    }

    public static void Save() //save la complétion des niveaux
    {
        var stringe = String.Join(",", allLevel);
        PlayerPrefs.SetString("Sauver", stringe);
    }

    public static void Load() //récupère la complétion des niveaux
    {
        var stringe = PlayerPrefs.GetString("Sauver");
        allLevel = stringe.Split(',');
    }

    
}
