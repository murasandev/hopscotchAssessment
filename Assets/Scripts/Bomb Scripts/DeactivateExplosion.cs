using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateExplosion : MonoBehaviour
{
    public DeactiveBombParent DeactiveBombParentCS;
    private float timeToActive = 3.0f;
    private float timer;
    public bool deactivateBool;

    private void OnEnable()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeToActive)
        {
            DeactiveBombParentCS.StartDeactivation();
            this.gameObject.SetActive(false);
        }
    }
}
