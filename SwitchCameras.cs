using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCameras : MonoBehaviour
{
    public GameObject tpsCam;
    public GameObject fpsCam;
    public GameObject gun;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Backspace))
        {
            tpsCam.SetActive(false);
            fpsCam.SetActive(true);
           // gun.SetActive(true);
        }
        if (Input.GetKey(KeyCode.Delete))
        {
            tpsCam.SetActive(true);
            fpsCam.SetActive(false);
            gun.SetActive(false);
        }
    }
}
