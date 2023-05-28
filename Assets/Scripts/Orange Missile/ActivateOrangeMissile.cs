using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOrangeMissile : MonoBehaviour
{
    public GameObject OrangeMissileGO;
    private float timeMin = 3f, timeMax = 5.0f, fireTime, timer;

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
        OrangeMissileGO = OrangeMissileOP.SharedInstance.GetPooledObject();
        if (OrangeMissileGO != null)
        {
            OrangeMissileGO.SetActive(true);
        }
    }
}
