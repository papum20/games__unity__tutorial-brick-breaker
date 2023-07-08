using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{

    [SerializeField]
    Color OneLifeColor, TwoLifeColor, ThreeLifeColor;

    [SerializeField]
    int hitPoints;

    SpriteRenderer sprite;

    AudioSource brickHitSound;

    [SerializeField]
    ParticleSystem brickHitParticles;



    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent <SpriteRenderer> ();
        ChangeColorOnLife();
        brickHitSound = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            hitPoints--;
            ChangeColorOnLife();
            brickHitSound.Play();
            brickHitParticles.Play();

            Vector3 collisionPoint = new Vector3(collision.contacts[0].point.x, collision.contacts[0].point.y);
            Vector3 ballDir = collision.gameObject.transform.position - collisionPoint;
            brickHitParticles.transform.rotation = Quaternion.LookRotation(ballDir.normalized, Vector3.back);
            brickHitParticles.transform.position = collisionPoint;


            if (hitPoints < 1)
            {
                Destroy(gameObject);
                GameManager.gameManager.BrickDestroyed();
            }
        }

    }


    void ChangeColorOnLife()
    {
        switch (hitPoints)
        {
            case 1:
                sprite.color = OneLifeColor;
                break;
            case 2:
                sprite.color = TwoLifeColor;
                break;
            case 3:
                sprite.color = ThreeLifeColor;
                break;
            default:
                sprite.color = OneLifeColor;
                break;
        }

        ParticleSystem.MainModule particleModule = brickHitParticles.main;
        particleModule.startColor = sprite.color;

    }


}
