using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveBombParent : MonoBehaviour
{
    private float deactivationTime = .5f;

    public void StartDeactivation()
    {
        Invoke("Deactivate", deactivationTime);
    }

    private void Deactivate()
    {
        this.gameObject.SetActive(false);
    }
}
