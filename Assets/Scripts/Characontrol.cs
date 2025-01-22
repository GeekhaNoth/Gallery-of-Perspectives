using Unity.Cinemachine;
using UnityEngine;

public class Characontrol : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] public CinemachineCamera camera;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float camspeed = 50.0f;
    
    private float _cameraRotationX = 0.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float camhorizontal = Input.GetAxis("Mouse X") * camspeed * Time.deltaTime;
        float camvertical = Input.GetAxis("Mouse Y") * camspeed * Time.deltaTime;
        //player.transform.position += new Vector3(player.transform.right * Horizontal, 0, Vertical);
        //camera.transform.rotation *= Quaternion.Euler(camvertical, 0, 0);
        
        
        player.transform.position += player.transform.right * horizontal + player.transform.forward * vertical;
        
        
        player.transform.Rotate(0, camhorizontal, 0);
        
        _cameraRotationX -= camvertical;
        _cameraRotationX = Mathf.Clamp(_cameraRotationX, -90f, 90f);
        camera.transform.localRotation = Quaternion.Euler(_cameraRotationX, 0, 0);
    }
}
