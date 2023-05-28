using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRockSelect : MonoBehaviour
{
    public GameObject[] rockArray;

    private int randomRock;

    private void Awake()
    {
        SetRocksToFalse();
    }

    private void OnEnable()
    {
        randomRock = Random.Range(0, rockArray.Length);
        rockArray[randomRock].SetActive(true);
    }

    private void OnDisable()
    {
        SetRocksToFalse();
    }

    private void SetRocksToFalse()
    {
        for (int i = 0; i < rockArray.Length; i++)
        {
            rockArray[i].SetActive(false);
        }
    }
}
