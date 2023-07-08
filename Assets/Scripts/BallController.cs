using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody2D body;

    [SerializeField]
    float ballSpeed = 10f;

    [SerializeField]
    AudioSource ballSound, deathSound;



    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        keepConstantVelocity();
    }





    private void OnCollisionEnter2D(Collision2D collision)
    {
        ballSound.Play();
    }




    void keepConstantVelocity()
    {
        body.velocity = ballSpeed * body.velocity.normalized;
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            GameManager.gameManager.GameOver();
            deathSound.Play();
        }

    }

}
