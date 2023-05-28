using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateRockObstacle : MonoBehaviour
{
    public GameObject rockObstacleGO;
    public bool fire;

    private float timeMin = 2f, timeMax = 4.0f, spawnTime, timer;

    private void Start()
    {
        RandomTimer();
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnTime)
        {
            timer = 0f;
            RandomTimer();
            ActivateRock();
        }
    }

    void RandomTimer()
    {
        spawnTime = Random.Range(timeMin, timeMax);
    }

    void ActivateRock()
    {
        Invoke("SetRock", 0f);
    }

    private void SetRock()
    {
        //activates inactive Rock from hierarchy
        rockObstacleGO = RockObjPool.SharedInstance.GetPooledObject();
        if (rockObstacleGO != null)
        {
            rockObstacleGO.SetActive(true);
        }
    }
}
