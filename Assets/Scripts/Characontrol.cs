using Unity.Cinemachine;
using UnityEngine;

public class Characontrol : MonoBehaviour
{
    public GameObject player;
    public CinemachineCamera camera;
    public float speed = 5.0f;
    public float camspeed = 50.0f;
    
    private float cameraRotationX = 0.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float Vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float camhorizontal = Input.GetAxis("Mouse X") * camspeed * Time.deltaTime;
        float camvertical = Input.GetAxis("Mouse Y") * camspeed * Time.deltaTime;
        //player.transform.position += new Vector3(player.transform.right * Horizontal, 0, Vertical);
        //camera.transform.rotation *= Quaternion.Euler(camvertical, 0, 0);
        
        
        player.transform.position += player.transform.right * Horizontal + player.transform.forward * Vertical;
        
        
        player.transform.Rotate(0, camhorizontal, 0);
        
        cameraRotationX -= camvertical;
        cameraRotationX = Mathf.Clamp(cameraRotationX, -90f, 90f);
        camera.transform.localRotation = Quaternion.Euler(cameraRotationX, 0, 0);
    }
}
