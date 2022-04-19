using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    [SerializeField][Range(500,2000)]
    private float sensitivity = 800f;
    private float xRotation = 0f;
    Transform playerBody;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GameObject.FindGameObjectWithTag("PlayerBody").transform;
        Cursor.lockState = CursorLockMode.Locked;   
    }

    // Update is called once per frame
    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        float mouseX = Input.GetAxis("Mouse X");

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation,-90f,90f);
        transform.localRotation = Quaternion.Euler(xRotation,0f,0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
