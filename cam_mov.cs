using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam_mov : MonoBehaviour
{
    public float mouse_sensitivity;
    private Transform parent;
    void Start()
    {
        parent = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
    }

   
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouse_sensitivity * Time.deltaTime;
        parent.Rotate(Vector3.up, mouseX);
    }

}
