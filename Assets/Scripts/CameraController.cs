using Unity.Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 100f;
    public float zoomSpeed = 5f;
    public float maxZoom = 20f;
    public float minZoom = 10f;
    public CinemachineOrbitalFollow player;
    public GameObject center;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(center.transform.position);
        //transform.LookAt(Vector2.zero);
        
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");
        player.HorizontalAxis.Value += Horizontal * speed * Time.deltaTime;
        player.VerticalAxis.Value += Vertical * speed * Time.deltaTime;
        
        float Zoom = Input.GetAxis("Mouse ScrollWheel");
        player.Radius = Mathf.Clamp(player.Radius - Zoom * zoomSpeed, minZoom, maxZoom);
        
        player.VerticalAxis.Value = Mathf.Clamp(player.VerticalAxis.Value, 0f, 89f);
    }
}