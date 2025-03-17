using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class PaintingData : MonoBehaviour
{
    
    [SerializeField] private CinemachineCamera _camera;
    public Vector3 _paintingPos;
    public Quaternion _paintingRot;
    public SceneAsset sceneToLoad;
    //public Texture Texture1;
    //public Texture Texture2;
    public int level;
    public UniversalRendererData postProcess;
    public Material postProcessingShader;

    public int Complete = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        LoadComplete();
        if (Complete == 1)
        {
            
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
        if (Input.GetMouseButtonDown(0))
        {
            //FullScreenPassRendererFeature feature = postProcess.GetComponent<FullScreenPassRendererFeature>();
            //feature.passMaterial = postProcessingShader;
            //feature.SetActive(true);
            foreach (var feature in postProcess.rendererFeatures)
            {
                if (feature is FullScreenPassRendererFeature fullScreenFeature)
                {
                    fullScreenFeature.passMaterial = postProcessingShader;
                    feature.SetActive(true);
                    Debug.Log("Post Process Material Updated!");
                }
            }
        }
    }

    public void SaveComplete()
    {
        PlayerPrefs.SetInt("Complete" + level.ToString(), Complete);
    }

    public void LoadComplete()
    {
        Complete = PlayerPrefs.GetInt("Complete" + level.ToString(), 0);
    }
}
