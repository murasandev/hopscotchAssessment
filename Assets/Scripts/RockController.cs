using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
    public Transform playerGO;

    private float minX = -1f, maxX = 3.3f, xPos;
    private float offScreenOffset = 25.0f;
    private float disableDistance = 10.0f;

    private void OnEnable()
    {
        RandomX();
        transform.position = new Vector3(xPos, transform.position.y, playerGO.transform.position.z - offScreenOffset);
    }
    // Update is called once per frame
    void Update()
    {
        DisableRock();
    }
    void RandomX()
    {
        //get random x pos when enabling rock obstacle
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
