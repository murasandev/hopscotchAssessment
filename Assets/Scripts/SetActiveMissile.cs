using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveMissile : MonoBehaviour
{
    public GameObject missileGO;

    private void OnEnable()
    {
        missileGO.SetActive(true);
    }
}
