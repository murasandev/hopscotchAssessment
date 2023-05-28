using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public bool gameOverBool;
    private bool setGameOverBool;
    public bool winBool;

    public PlayerMovementController playerMovementControllerCS;
    public GameObject playerDeathPS;
    private bool playerDeathPSBool;
    public GameObject playerBodyGO;
    public GameObject playerFaceGO;
    public GameObject playerCrosshairGO;

    public GameObject blueMissileObjPool;
    public GameObject OrangeMissileObjPool;
    public GameObject BombBarragePool;

    public GameObject RockObstaclePool;

    public ParticleSystem starPS;
    private ParticleSystem.MainModule mainModule;

    public GameObject winScreen;
    private bool setWinBool;
    public GameObject gameOverScreen;
    public MoveDownScreen terrainCS;

    // Start is called before the first frame update
    void Start()
    {
        mainModule = starPS.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOverBool)
        {
            endGame();
        }
    }

    #region Used to stop rock obstacles moving, in ObstacleMoveDownScreen.cs
    public void SetGameOverBool()
    {
        if (setGameOverBool)
        {
            gameOverBool = true;
        }
    }

    public void SetWinBool()
    {
        if (setWinBool)
        {
            winBool = true;
        }
    }
    #endregion

    public void endGame()
    {
        //called in HealthBar.cs
        setGameOverBool = true;
        gameOverBool = true;

        playerMovementControllerCS.gameOver = true;
        if (!playerDeathPSBool)
        {
            playerDeathPS.SetActive(true);
            playerDeathPSBool = true;
        }
        playerBodyGO.SetActive(false);
        playerFaceGO.SetActive(false);
        playerCrosshairGO.SetActive(false);

        terrainCS.enabled = false;

        blueMissileObjPool.SetActive(false);
        OrangeMissileObjPool.SetActive(false);
        BombBarragePool.SetActive(false);

        RockObstaclePool.SetActive(false);
        mainModule.startSpeedMultiplier = 0f;

        gameOverScreen.SetActive(true);

        gameOverBool = false;
    }

    public void winGame()
    {
        setWinBool = true;
        winBool = true;

        playerMovementControllerCS.gameOver = true;

        terrainCS.enabled = false;

        blueMissileObjPool.SetActive(false);
        OrangeMissileObjPool.SetActive(false);
        BombBarragePool.SetActive(false);

        RockObstaclePool.SetActive(false);
        mainModule.startSpeedMultiplier = 0f;

        winScreen.SetActive(true);
    }
}
