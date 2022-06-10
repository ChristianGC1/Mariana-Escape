using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlaneCont : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject explosionEffect;
    public GameManager gameManager;
    public static float speed = 10;
    public float acceleration;
    public float speedMult;
    public float rotationControl;
    public static int score = 0;
    public static int scoreHigh;

    float MovY, MovX = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 10;
        score = 0;
    }

    void Update()
    {
        MovY = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.W))
        {
            //Add more speed
            if (speed < 75)
            {
                speed+= Time.deltaTime * speedMult;
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            //Lower speed
            if (speed > 10)
            {
                speed -= Time.deltaTime * speedMult;
            }
        }

        if (score > scoreHigh)
        {
            scoreHigh = score;
        }
    }

    private void FixedUpdate()
    {
        Vector2 Vel = transform.right * (MovX * acceleration);
        rb.AddForce(Vel);


        float Dir = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.right));

        if (acceleration > 0)
        {

            if (Dir > 0)
            {
                rb.rotation -= MovY * rotationControl * (rb.velocity.magnitude / speed);
            }

            else
            {
                rb.rotation += MovY * rotationControl * (rb.velocity.magnitude / speed);
            }
        }

        float thrustforce = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.down)) * 2.0f;

        Vector2 relForce = Vector2.up * thrustforce;

        rb.AddForce(rb.GetRelativeVector(relForce));

        if (rb.velocity.magnitude > speed)
        {
            rb.velocity = rb.velocity.normalized * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "TestWall")
        {
            GetComponent<SimpleFlashColored>().Flash(Color.red);
            GameObject explosionEffectIns = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            rb.velocity = Vector2.zero;
            this.enabled = false;
            SceneManager.LoadScene(1);
            
        }

        if (other.tag == "DeathWall")
        {
            GetComponent<SimpleFlashColored>().Flash(Color.red);
            GameObject explosionEffectIns = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            rb.velocity = Vector2.zero;
            AudioManager.PlaySound("DamageTwo");
            this.enabled = false;
            gameManager.GameOver();
        }

        if (other.tag == "Enemy")
        {
            GetComponent<SimpleFlashColored>().Flash(Color.red);
            GameObject explosionEffectIns = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            rb.velocity = Vector2.zero;
            AudioManager.PlaySound("DamageTwo");
            this.enabled = false;
            gameManager.GameOver();
        }
    }
}
