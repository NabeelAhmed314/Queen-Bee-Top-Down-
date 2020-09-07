using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject stringerPrefab;
    public float stringerForce = 20f;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }    
    }
    void Shoot()
    {
        GameObject stringer =  Instantiate(stringerPrefab, firePoint.position, firePoint.rotation); 
        Rigidbody2D rb =  stringer.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * stringerForce, ForceMode2D.Impulse);
    }
}
