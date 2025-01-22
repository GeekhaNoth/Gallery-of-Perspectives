using Unity.Cinemachine;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PaintingData : MonoBehaviour
{
    
    [SerializeField] private CinemachineCamera _camera;
    public Vector3 _paintingPos;
    public Quaternion _paintingRot;
    public SceneAsset sceneToLoad;
    public Texture Texture1;
    public Texture Texture2;
    public int level;

    public int Complete = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        if (PlayerPrefs.HasKey("Complete" + level.ToString()))
        {
            Complete = PlayerPrefs.GetInt("Complete" + level.ToString());
            //if (Complete == 1)
            //{
            //gameObject.GetComponent(Texture);
            //}
        }
        _paintingPos = _camera.transform.position;
        _paintingRot = _camera.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SaveComplete()
    {
        PlayerPrefs.SetInt("Complete" + level.ToString(), Complete);
    }

    private void LoadComplete()
    {
        Complete = PlayerPrefs.GetInt("Complete" + level.ToString());
    }
}
