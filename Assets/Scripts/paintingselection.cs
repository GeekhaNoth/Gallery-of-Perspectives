using System.Collections;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class paintingselection : MonoBehaviour
{
    public GameObject paintingChoose;
    private bool _paintingChooseActive = false;
    [SerializeField] private CinemachineCamera playerCamera;
    [SerializeField] private GameObject text;
    [SerializeField] private GameObject player;
    private LevelManager _levelManager;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit) && hit.collider.CompareTag("Painting") && Vector3.Distance(player.transform.position, hit.point) < 3f)
            {
                _paintingChooseActive = true;
                paintingChoose = hit.collider.gameObject;
                playerCamera.gameObject.SetActive(false); //desactive la camera du joueur
                paintingChoose.transform.GetChild(0).gameObject.SetActive(true); //active la camera de l'écran de sélection du tableau choisi  pour faire un travelling
                StartCoroutine(Timer()); 
            }
        }

        if (_paintingChooseActive && Input.GetKeyDown("e")) //Permet de lancer le niveau si appuie sur e
        {
            
            SceneManager.LoadScene(1);
           // _levelManager.StartLevel(); //lance le niveau

        }
        
        if (_paintingChooseActive && Input.GetKeyDown("escape")) //enlève l'écran de séléction du-dit niveau si echap
        {
            text.gameObject.SetActive(false); //désactive un texte
            _paintingChooseActive = false;
            paintingChoose.transform.GetChild(0).gameObject.SetActive(false); //desactive la camera de l'écran de sélection du-dit niveau
            playerCamera.gameObject.SetActive(true); //active la camera du joueur
        }

        if (_paintingChooseActive == false && Input.GetKeyDown("escape")) //si echap dans le hub et sans écran de sélection affiche le menu
        {
            //Afficher Menu
        }
    }
    IEnumerator Timer() //permet d'activer un gameobject après un temps donné)
    {
        yield return new WaitForSeconds(2f);
        text.gameObject.SetActive(true); //active un texte
    }

    
}

