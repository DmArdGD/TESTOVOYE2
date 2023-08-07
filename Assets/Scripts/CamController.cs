 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class CamController : MonoBehaviour
{
    float angleHorizontal;
    float angleVertical;
    public float cameraSpeed = 0.125f;

    
   

    [Header("Чувствительность мыши")]
    public float sensitivityMouse = 10f;

    public Transform Player;

    private void Start()
    {
       
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    private void Update()
    {
        if (Cursor.visible == false)
        {
            angleHorizontal += Input.GetAxis("Mouse X") * sensitivityMouse * Time.deltaTime;
            angleVertical += Input.GetAxis("Mouse Y") * sensitivityMouse * Time.deltaTime;
            angleVertical = Mathf.Clamp(angleVertical, -60, 60);
            Quaternion rotationY = Quaternion.AngleAxis(angleHorizontal, Vector3.up);
            Quaternion rotationX = Quaternion.AngleAxis(-angleVertical, Vector3.right);

            Player.rotation = (transform.rotation);
            transform.rotation = (rotationY * rotationX);
        }        
    }
}