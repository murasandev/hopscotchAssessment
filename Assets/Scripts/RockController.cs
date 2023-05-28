using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
    public Transform playerGO;

    private float minX = -3.0f, maxX = 7.0f, xPos;
    private float offScreenOffset = 25.0f;
    private float disableDistance = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        transform.position = new Vector3(xPos, transform.position.y, playerGO.transform.position.z - offScreenOffset);
    }
    // Update is called once per frame
    void Update()
    {
        DisableRock();
    }
    void RandomX()
    {
        xPos = Random.Range(minX, maxX);
    }
    void DisableRock()
    {
        if (transform.position.z >= disableDistance)
        {
            this.gameObject.SetActive(false);
        }
    }
}
