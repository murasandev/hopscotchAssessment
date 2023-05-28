using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBlueMissile : MonoBehaviour
{
    public GameObject BlueMissileGO;
    private float timeMin = 3f, timeMax = 7f, fireTime, timer;

    private void Awake()
    {
        RandomTimer();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= fireTime)
        {
            timer = 0f;
            RandomTimer();
            FireMissile();
        }
    }
    void RandomTimer()
    {
        fireTime = Random.Range(timeMin, timeMax);
    }

    void FireMissile()
    {
        //activates inactive Bomb from hierarchy
        BlueMissileGO = BlueMissileOP.SharedInstance.GetPooledObject();
        if (BlueMissileGO != null)
        {
            BlueMissileGO.SetActive(true);
        }
    }
}
