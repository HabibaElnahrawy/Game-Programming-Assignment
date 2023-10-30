using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsCamMov : MonoBehaviour
{
    [SerializeField] private float xMouseSensitivity = 200f;
    [SerializeField] private float yMouseSensitivity = 200f;
    [SerializeField] private GameObject weapon;
    [SerializeField] private GameObject player;


    private float _xRotation;

    void Start()
    {
        _xRotation = transform.rotation.x;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * xMouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * yMouseSensitivity * Time.deltaTime;

        _xRotation -= mouseY;

        _xRotation = Mathf.Clamp(_xRotation, -75f, 75f);

        player.transform.Rotate(Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        weapon.transform.localRotation = Quaternion.Euler(0f, -90f, -_xRotation);



    }
}
