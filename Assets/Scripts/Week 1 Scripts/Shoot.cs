using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public AudioSource blaster;

    public float bulletForce = 100f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shooting();
            blaster.GetComponent<AudioSource>().Play();
        }
    }

    void Shooting()
    {
        Debug.Log("Shooting");
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }
}
