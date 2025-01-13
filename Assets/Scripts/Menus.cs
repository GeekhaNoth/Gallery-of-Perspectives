using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    public Animation anim;
    public GameObject mainMenu;
    public GameObject settingsMenu;

    private void Start()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    void StartGame()
    {
        anim.Play("Fade");
        StartAnim();
    }

    void LoadGame()
    {

    }

    void Settings()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            mainMenu.SetActive(true);
            settingsMenu.SetActive(false);
        }
    }

    void Return()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
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
