using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockPickup : MonoBehaviour
{

    [Header("Components")]
    [SerializeField]private PlayerController    playerController;
    [SerializeField]private Transform           transformSpawnPos;
    [SerializeField]private GameObject[]        gameObjectsRocks;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        transformSpawnPos = FindObjectOfType<PlayerController>().transformSpawnPosition;
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Instantiate(gameObjectsRocks[0], 
            transformSpawnPos.transform.position, Quaternion.identity);
            playerController.AddNewRock();
            Destroy(gameObject, 0);
        }
    }
}
