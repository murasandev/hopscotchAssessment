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
        gameOver.SetGameOverBool();
        gameOver.SetWinBool();

        if (!gameOver.gameOverBool && !gameOver.winBool)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        else
        {
            transform.Translate(Vector3.zero);
        }
    }
}
