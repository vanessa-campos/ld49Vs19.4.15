using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasPlayerController : MonoBehaviour
{

    [Header("Components")]
    [SerializeField]private PlayerController playerController;
    [SerializeField]private Slider[]         sliderResistance;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        ResistenceController();
    }

    void ResistenceController()
    {
        sliderResistance[0].value = playerController.rocksResistances[0];
        sliderResistance[1].value = playerController.rocksResistances[1];

        for(int i = 0; i < playerController.rocksResistancesEnd.Length; i++)
        {
            if(playerController.rocksResistancesEnd[i] == true)
            {
                sliderResistance[i].interactable = false;
            }else if(playerController.rocksResistancesEnd[i] == false)
            {
                sliderResistance[i].interactable = true;
            }
        }
    }
}
