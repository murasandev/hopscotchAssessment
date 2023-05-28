using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBombBarrage : MonoBehaviour
{
    public GameObject bombGO;

    private float barrageDuration = 1.5f;
    private float barrageSpeed = .25f;
    private float barrageStartTime = 0f;

    private float timeMin = 5f, timeMax = 10.0f, fireTime, timer;

    private void Start()
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
            FireBomb();
        }
    }

    void RandomTimer()
    {
        fireTime = Random.Range(timeMin, timeMax);
    }

    void FireBomb()
    {
        InvokeRepeating("ShootBomb", barrageStartTime, barrageSpeed);
        Invoke("CancelInvoke", barrageDuration);
    }

    private void ShootBomb()
    {
        //activates inactive Bomb from hierarchy
        bombGO = ObjectPool.SharedInstance.GetPooledObject();
        if (bombGO != null)
        {
            bombGO.SetActive(true);
        }
    }
}
