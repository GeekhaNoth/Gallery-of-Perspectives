using System.Collections;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class paintingselection : MonoBehaviour
{
    private GameObject paintingChoose;
    private bool paintingChooseActive = false;
    public CinemachineCamera playercam;
    public GameObject launch;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        completioncheck.Load(); //Vérifie la complétion des niveaux
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.CompareTag("Painting"))  //Vérifie si l'objet clické est un tableau
                {
                    if (Vector3.Distance(transform.position, hit.point) < 3f) //Si le joueur est proche du tableau, contenu du if : accède à l'écran de sélection du niveau choisi
                    {
                        paintingChooseActive = true;
                        paintingChoose = hit.collider.gameObject;
                        playercam.gameObject.SetActive(false); //desactive la camera du joueur
                        paintingChoose.transform.GetChild(0).gameObject.SetActive(true); //active la camera de l'écran de sélection du tableau choisi  pour faire un travelling
                        StartCoroutine(Timer()); 
                        
                    }
                }
            }
        }

        if (paintingChooseActive && Input.GetKeyDown("e")) //Permet de lancer le niveau si appuie sur e
        {
            completioncheck.Save(); //sauvegarde la completion des niveaux
            SceneManager.LoadScene(int.Parse(paintingChoose.transform.GetChild(1).name)); //lance le niveau
            
        }
        
        if (paintingChooseActive && Input.GetKeyDown("escape")) //enlève l'écran de séléction du-dit niveau si echap
        {
            launch.gameObject.SetActive(false); //désactive un texte
            paintingChooseActive = false;
            paintingChoose.transform.GetChild(0).gameObject.SetActive(false); //desactive la camera de l'écran de sélection du-dit niveau
            playercam.gameObject.SetActive(true); //active la camera du joueur
        }

        if (paintingChooseActive == false && Input.GetKeyDown("escape")) //si echap dans le hub et sans écran de sélection affiche le menu
        {
            //Afficher Menu
        }
    }
    IEnumerator Timer() //permet d'activer un gameobject après un temps donné)
    {
        yield return new WaitForSeconds(2f);
        launch.gameObject.SetActive(true); //active un texte
    }

    
}

