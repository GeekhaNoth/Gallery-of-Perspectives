using System;
using System.Linq;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int _isIntroDone = 0;
    private int _isLastLevelDone = 0;
    //private int _isRestart = 0;
    private PaintingData _painting;
    private Vector3 Position;
    private Quaternion Rotation;
    private PaintingData _paintingData;
    [SerializeField] private paintingselection _paintingSelection;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _manager;

    [SerializeField] private GameObject[] _allLevel;
    public int _levelCompletion;
    public int _currentLevel = -1;

    public GameObject lastlevel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _levelCompletion = 0;
        LoadIntro();
        
        if (_isIntroDone == 1) //&& _isRestart == 1)
        { 
            LoadData();
            LoadCurrentLevel();
            if (_isLastLevelDone == 1)
            {
                if (_currentLevel != -1) lastlevel = _allLevel[_currentLevel];
                PaintingData _painting = lastlevel.GetComponent<PaintingData>();
                _painting.Complete = 1;
                _painting.SaveComplete();
            }

            _player.transform.position = Position;
            _player.transform.rotation = Rotation;
        }
        else
        {
            //Intro
            _isIntroDone = 1;
            SaveIntro();
        }
        
        foreach (GameObject paint in _allLevel)
        {
            PaintingData _painting = paint.GetComponent<PaintingData>();
            _painting.LoadComplete();
            Debug.Log(_painting.Complete);
            if (_painting.Complete == 1)
            {
                _levelCompletion++;
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
        GameObject choose = _paintingSelection.paintingChoose;
        PaintingData _paintingData = choose.GetComponent<PaintingData>();
        _currentLevel = _paintingData.level;
        SaveCurrentLevel();
        Position = _paintingData._paintingPos;
        Rotation = _paintingData._paintingRot;
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
        float posX = PlayerPrefs.GetFloat("PosX", 0);
        float posY = PlayerPrefs.GetFloat("PosY", 0);
        float posZ = PlayerPrefs.GetFloat("PosZ", -5);
        Position = new Vector3(posX, posY, posZ);
        float rotX = PlayerPrefs.GetFloat("RotX", 0);
        float rotY = PlayerPrefs.GetFloat("RotY", 0);
        float rotZ = PlayerPrefs.GetFloat("RotZ", 0);
        float rotW = PlayerPrefs.GetFloat("RotW", 0);
        Rotation = new Quaternion(rotX, rotY, rotZ, rotW);
        //_isRestart = PlayerPrefs.GetInt("Restart");
    }

    private void SaveIntro()
    {
        PlayerPrefs.SetInt("IntroDone", _isIntroDone);
    }

    private void LoadIntro()
    {
        _isIntroDone = PlayerPrefs.GetInt("IntroDone", 0);
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
    /*private void SaveCompletion()
    {
        PlayerPrefs.SetInt("Completion", _levelCompletion.Sum());
    }

    private void LoadCompletion()
    {
        int value = PlayerPrefs.GetInt("Completion", 0);
        for (int i = 0; i < value; i++)
        {
            _levelCompletion[i] = 1;
        }
    }*/

    private void SaveCurrentLevel()
    {
        PlayerPrefs.SetInt("CurrentLevel", _currentLevel);
    }

    private void LoadCurrentLevel()
    {
        _currentLevel = PlayerPrefs.GetInt("CurrentLevel", -1);
        _isLastLevelDone = PlayerPrefs.GetInt("OnSpot", 0);
    }
}
