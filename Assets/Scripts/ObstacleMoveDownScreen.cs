using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMoveDownScreen : MonoBehaviour
{
    public float speed = 15.0f;
    public GameOver gameOver;

    // Update is called once per frame
    void Update()
    {
        if (!gameOver.gameOverBool)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        else
        {
            transform.Translate(Vector3.zero);
        }
    }
}
