using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBarrageActivate : MonoBehaviour
{
    public GameObject bombGO;
    public GameObject crosshairGO;
    public Transform playerTransform;
    public float zBuffer = 3.0f;

    private void OnEnable()
    {
        //sets bomb barrage position in front of player
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, playerTransform.position.z - zBuffer);
        bombGO.SetActive(true);
        crosshairGO.SetActive(true);
    }
}
