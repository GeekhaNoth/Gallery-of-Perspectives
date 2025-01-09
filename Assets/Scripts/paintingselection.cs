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
    private float timer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        completioncheck.Load();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.CompareTag("Painting"))
                {
                    if (Vector3.Distance(transform.position, hit.point) < 3f)
                    {
                        paintingChooseActive = true;
                        paintingChoose = hit.collider.gameObject;
                        playercam.gameObject.SetActive(false);
                        paintingChoose.transform.GetChild(0).gameObject.SetActive(true);
                        StartCoroutine(Timer());
                        
                    }
                }
            }
        }

        if (paintingChooseActive && Input.GetKeyDown("e"))
        {
            completioncheck.Save();
            SceneManager.LoadScene(int.Parse(paintingChoose.transform.GetChild(1).name));
            
        }
        
        if (paintingChooseActive && Input.GetKeyDown("escape"))
        {
            launch.gameObject.SetActive(false);
            timer = 0f;
            paintingChooseActive = false;
            paintingChoose.transform.GetChild(0).gameObject.SetActive(false);
            playercam.gameObject.SetActive(true);
        }

        if (paintingChooseActive == false && Input.GetKeyDown("escape"))
        {
            //Afficher Menu
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(2f);
        launch.gameObject.SetActive(true);
    }
}
