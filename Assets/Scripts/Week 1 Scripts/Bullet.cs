using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void Update()
    {
        Destroy(gameObject, 5f);
    }

    private void FixedUpdate()
    {
        Vector2 dir = GetComponent<Rigidbody2D>().velocity;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            Debug.Log("Bullet Destroyed");
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Bullet hit Enemy");
            PlaneCont.score++;
        }
    }
}