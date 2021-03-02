using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossbowShooting : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera fpsCam;
    public Rigidbody projectile;
    public Transform barrelEnd;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        } 
    }

    void Shoot()
    {
        Rigidbody projectileInstance;
        projectileInstance = Instantiate(projectile, barrelEnd.position, barrelEnd.rotation) as Rigidbody;
        projectileInstance.AddForce(barrelEnd.up * 1000);
    }   
}
