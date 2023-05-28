using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBlueMissile : MonoBehaviour
{
    public GameObject BlueMissileHolder;
    private float timeMin = 1.5f, timeMax = 3f, fireTime, timer;

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
        BlueMissileHolder = BlueMissileOP.SharedInstance.GetPooledObject();
        if (BlueMissileHolder != null)
        {
            BlueMissileHolder.SetActive(true);
        }
    }
}
