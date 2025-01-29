using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    public Animation anim;
    public GameObject mainMenu;
    public GameObject settingsMenu;


    private void Update()
    {
        if (settingsMenu.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
                mainMenu.SetActive(true);
                settingsMenu.SetActive(false);
        }
    }

    private void Start()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    void StartGame()
    {
        anim.Play("Fade");
        StartCoroutine(StartAnim());
    }

    void LoadGame()
    {

    }

    void Settings()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);

        
    }

    void Return()
    {
        Start();
    }

    void Quit()
    {
        Application.Quit();
    }

    IEnumerator StartAnim()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }
}
