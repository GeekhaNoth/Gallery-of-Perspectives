using Unity.Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed = 100f;
    [SerializeField] private float zoomSpeed = 5f;
    [SerializeField] private float maxZoom = 20f;
    [SerializeField] private float minZoom = 10f;
    [SerializeField] private CinemachineOrbitalFollow player;
    
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
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        player.HorizontalAxis.Value += horizontal * speed * Time.deltaTime;
        player.VerticalAxis.Value += vertical * speed * Time.deltaTime;
        
        float zoom = Input.GetAxis("Mouse ScrollWheel");
        player.Radius = Mathf.Clamp(player.Radius - zoom * zoomSpeed, minZoom, maxZoom);
        
        player.VerticalAxis.Value = Mathf.Clamp(player.VerticalAxis.Value, 0f, 89f);
    }
}