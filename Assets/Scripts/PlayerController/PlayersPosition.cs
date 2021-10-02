using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersPosition : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]private PlayerController    playerController;

    

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
       FixedPositionPlayer();
    }

    void FixedPositionPlayer()
    {
        // Segurar o eixo X no player e no Y ficar solto

        transform.position = new Vector2(playerController.transform.position.x, transform.position.y);
    }



}
