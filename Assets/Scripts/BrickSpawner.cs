using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{

    [SerializeField]
    int rows = 4, cols = 5;

    [SerializeField]
    float xDistanceBetweenBricks = 1, yDistanceBetweenBricks = -0.6f;

    [SerializeField]
    GameObject brickPrefab;


    // Start is called before the first frame update
    void Start()
    {
        GameManager.gameManager.SetSpawnedBricks(rows * cols);
        SpawnBricks();
    }


    void SpawnBricks()
    {
        for(int y = 0; y < rows; y++)
        {
            for(int x = 0; x < cols; x++)
            {
                Vector2 NewBrickPosition = new Vector2(transform.position.x + (x * xDistanceBetweenBricks), transform.position.y + (y * yDistanceBetweenBricks));
                GameObject.Instantiate(brickPrefab, NewBrickPosition, Quaternion.identity, transform);
            }
        }
    }

}
