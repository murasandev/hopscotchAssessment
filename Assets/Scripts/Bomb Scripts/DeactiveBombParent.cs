using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveBombParent : MonoBehaviour
{
    private float deactivationTime = .5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartDeactivation()
    {
        Invoke("Deactivate", deactivationTime);
    }

    private void Deactivate()
    {
        this.gameObject.SetActive(false);
    }
}
