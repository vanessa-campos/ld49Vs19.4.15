using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Components")]
    [SerializeField]private Rigidbody2D     rb2;
    [SerializeField]public  GameObject[]    rocksGameObject;
    [SerializeField]private GameObject[]    rocksPickup;
    [SerializeField]public  Transform       transformSpawnPosition;
    [Header("Atributtes Movimentation")]
    [SerializeField]private float           axisHorizontal;
    [SerializeField]private float           speedVelocity;
    [Header("Atributtes Resistance")]
    [SerializeField]public  float[]         rocksResistances;    
    [SerializeField]private float[]         speedReduceRocksResistances;        
    [SerializeField]private float[]         speedAddRocksResistances;
    [SerializeField]public  bool []         rocksResistancesEnd;
    [SerializeField]private bool []         applyOneTime;           


    void Start()
    {
        
    }

    void Update()
    {
        Movimentation();
        UpdateCheckResistance();
        UpdateResistance();

    }

    void Movimentation()
    {
        // Movimentação na horizontal 
        axisHorizontal = Input.GetAxis("Horizontal");
        rb2.velocity = new Vector2(axisHorizontal * speedVelocity, rb2.velocity.y);
    }

    public void AddNewRock()
    {
        for(int i = 0; i < rocksResistancesEnd.Length; i++)
        {
            rocksResistancesEnd[i] = false;
        }
    }

    void UpdateCheckResistance()
    {
        //Controlador de resistencias que acabaram

        for(int i = 0; i < rocksResistancesEnd.Length; i++)
        {
            if(rocksResistances[i] <= 0)
            {
                rocksResistancesEnd[i] = true;
                if(applyOneTime[i])
                {
                    Destroy(rocksGameObject[i].gameObject, 0);
                    Vector2 spawnRockPickup = new Vector2(transform.position.x + 5, transform.position.y);
                    Instantiate(rocksPickup[i], spawnRockPickup, Quaternion.identity);
                    applyOneTime[i] = false;
                }
            }else if(rocksResistances[i] >= 0 || !rocksResistancesEnd[i])
            {
                rocksResistancesEnd[i] = false;
            }
        }
    }


    void UpdateResistance()
    {

        //Controlador da resistencia da pedras

        if(axisHorizontal != 0)
        {
            if(rocksResistances[0] > 0)
            {
                rocksResistances[0] -= speedReduceRocksResistances[0] * Time.deltaTime;
            } else 
            {
                if(rocksResistances[1] > 0)
                {
                    rocksResistances[1] -= speedReduceRocksResistances[1] * Time.deltaTime;
                }
            }
        }else 
        {
            if(rocksResistances[0] < 50 && rocksResistances[1] >= 50 && !rocksResistancesEnd[0])
            {
                rocksResistances[0] += speedAddRocksResistances[0] * Time.deltaTime;
                
            }
            
            if(rocksResistances[1] < 50 && !rocksResistancesEnd[1])
            {
                rocksResistances[1] += speedAddRocksResistances[1] * Time.deltaTime;
                
            }  
        }
    }


}

