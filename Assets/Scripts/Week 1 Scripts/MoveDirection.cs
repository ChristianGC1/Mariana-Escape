using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDirection : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        Move();
    }

    void Move()
    {
        //Vector3 temp = transform.position;
        //temp.x -= speed * Time.deltaTime;
        //transform.position = temp;

        if (gameObject.CompareTag("CloudA"))
        {
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;
            transform.position = temp;
        }

        if (gameObject.CompareTag("CloudB"))
        {
            Vector3 temp = transform.position;
            temp.x += speed * Time.deltaTime;
            transform.position = temp;
        }
    }
}
