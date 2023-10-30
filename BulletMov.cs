using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMov : MonoBehaviour
{
    public GameObject Bullet;
    public Camera Fpscamera;
    public float range = 100f;
    public float damage = 10f;

    [Header("Gun Effets")]
    public ParticleSystem muzzleSpark;
    //public GameObject impactEffect;
    // Update is called once per frame
    void Update()
    {
       

        if (Input.GetMouseButtonDown(0))
            {
               
                shoot();
                //  GameObject b = Instantiate(Bullet, transform.position, transform.rotation);
            }
       

    }
   void shoot()
    {
        muzzleSpark.Play();
        RaycastHit hit;
        if (Physics.Raycast(Fpscamera.transform.position, Fpscamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
           // GameObject b = Instantiate(Bullet, Fpscamera.transform.position, transform.rotation);
          //  Destroy(Bullet, 5);
            TargetForShooting target = hit.transform.GetComponent<TargetForShooting>();
            if (target !=null)
            {
                target.TakeDamage(damage);
                //GameObject impact = Instantiate(impactEffect,hit.point,Quaternion.LookRotation(hit.normal));
                //Destroy(impact, 1f);
            }
        }
    }
}
