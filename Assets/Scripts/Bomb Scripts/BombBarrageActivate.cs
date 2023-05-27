using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBarrageActivate : MonoBehaviour
{
    public GameObject bombGO;
    public GameObject crosshairGO;
    public Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        transform.position = playerTransform.position;
        bombGO.SetActive(true);
        crosshairGO.SetActive(true);
    }
}
