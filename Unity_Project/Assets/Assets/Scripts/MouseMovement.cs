using UnityEngine;

public class MouseMovement : MonoBehaviour
{

    public float mouseSensetivity = 2000f;

    float xRotation = 0f;
    float yRotation = 0f;

    public float topCap = -90f;
    public float bottomCap = 90f;


    void Start()
    {
        //Bu kod, fare imlecini merkeze kilitleyip gizler.
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //Buradaki kod satırları, farenin inputlarını alır
        float mouseX = Input.GetAxis("Mouse X") * mouseSensetivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensetivity * Time.deltaTime;

        //Farenin X eksenindeki hareket
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, topCap, bottomCap);

        yRotation += mouseX;

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
