using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarController : MonoBehaviour
{

    [SerializeField]
    float movementSpeed;




    [SerializeField]
    float MinX = -2.1f, MaxX = 2.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveBar();
    }

    void MoveBar()
    {
        float xMovement = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * xMovement * Time.deltaTime * movementSpeed);

        if (transform.position.x < MinX)
            transform.position = new Vector2(MinX, transform.position.y);
        else if (transform.position.x > MaxX)
            transform.position = new Vector2(MaxX, transform.position.y);


    }
}
