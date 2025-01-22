using System;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int _isIntroDone = 0;
    //private int _isRestart = 0;
    private PaintingData _painting;
    private Vector3 Position;
    private Quaternion Rotation;
    private PaintingData _paintingData;
    [SerializeField] private paintingselection _paintingSelection;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _manager;

    [SerializeField] private GameObject[] _allLevel;
    public int[] _levelCompletion;
    public int _currentLevel = 0;

    public GameObject lastlevel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (PlayerPrefs.HasKey("IntroDone")) LoadIntro();
        
        if (_isIntroDone == 1) //&& _isRestart == 1)
        { 
            LoadData();
            LoadCurrentLevel();
            lastlevel = _allLevel[_currentLevel];
            PaintingData _painting = lastlevel.GetComponent<PaintingData>();
            _painting.Complete = 1;
            _player.transform.position = Position;
            _player.transform.rotation = Rotation;
        }
        else
        {
            //Intro
            Debug.Log("a");
            _isIntroDone = 1;
            SaveIntro();
        }

        _allLevel = GameObject.FindGameObjectsWithTag("Painting");
        foreach (GameObject paint in _allLevel)
        {
            for (int i = 0; i < _allLevel.Length; i++)
            {
                //check la texture de chaque game object
                //if (gameObject.component = texture 2)
                //_levelCompletion[i] = 1;
            }
        }
        //if (Convert.ToInt32(_levelCompletion) == 1111111)
        //{
            //Fin du jeu
       // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartLevel()
    {
        _currentLevel = _paintingData.level;
        SaveCurrentLevel();
        PaintingData _painting = _paintingSelection.paintingChoose.GetComponent<PaintingData>();
        Position = _painting._paintingPos;
        Rotation = _painting._paintingRot;
        SaveData();
        //SaveRestart();
        SceneManager.LoadScene(_paintingData.sceneToLoad.name);
    }
    
    private void SaveData()
    {
      
        PlayerPrefs.SetFloat("PosX", Position.x);
        PlayerPrefs.SetFloat("PosY", Position.y);
        PlayerPrefs.SetFloat("PosZ", Position.z);
        
        PlayerPrefs.SetFloat("RotX", Rotation.x);
        PlayerPrefs.SetFloat("RotY", Rotation.y);
        PlayerPrefs.SetFloat("RotZ", Rotation.z);
        PlayerPrefs.SetFloat("RotW", Rotation.w);
        PlayerPrefs.Save();
    }
    
    private void LoadData()
    {
        float posX = PlayerPrefs.GetFloat("PosX");
        float posY = PlayerPrefs.GetFloat("PosY");
        float posZ = PlayerPrefs.GetFloat("PosZ");
        Position = new Vector3(posX, posY, posZ);
        float rotX = PlayerPrefs.GetFloat("RotX");
        float rotY = PlayerPrefs.GetFloat("RotY");
        float rotZ = PlayerPrefs.GetFloat("RotZ");
        float rotW = PlayerPrefs.GetFloat("RotW");
        Rotation = new Quaternion(rotX, rotY, rotZ, rotW);
        //_isRestart = PlayerPrefs.GetInt("Restart");
    }

    private void SaveIntro()
    {
        PlayerPrefs.SetInt("IntroDone", _isIntroDone);
    }

    private void LoadIntro()
    {
        _isIntroDone = PlayerPrefs.GetInt("IntroDone");
    }

    //public void SaveRestart()
    //{
      //  _isRestart = 1;
       // PlayerPrefs.SetInt("Restart", _isRestart);
    //}

    //public void LoadRestart()
    //{
     //   _isRestart = PlayerPrefs.GetInt("Restart");
    //}
    private void SaveCompletion()
    {
        PlayerPrefs.SetInt("Completion", Convert.ToInt32(_levelCompletion));
    }

    private void LoadCompletion()
    {
        int value = PlayerPrefs.GetInt("Completion");
        string valutstring = value.ToString();
        int[] array = new int[valutstring.Length];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = int.Parse(valutstring[i].ToString());
        }
        _levelCompletion = array;
    }

    private void SaveCurrentLevel()
    {
        PlayerPrefs.SetInt("CurrentLevel", _currentLevel);
    }

    private void LoadCurrentLevel()
    {
        _currentLevel = PlayerPrefs.GetInt("CurrentLevel", _currentLevel);
    }
}
