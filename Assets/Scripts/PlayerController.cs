using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    [Header("Components")]
    [SerializeField]private Rigidbody2D     rb2;
    [SerializeField]private GameObject[]    rocksGameObject;
    [Header("Atributtes Movimentation")]
    [SerializeField]private float           axisHorizontal;
    [SerializeField]private float           speedVelocity;
    [Header("Atributtes Resistance")]
    [SerializeField]public  float[]         rocksResistances;    
    [SerializeField]private float[]         speedReduceRocksResistances;        
    [SerializeField]private float[]         speedAddRocksResistances;
    [SerializeField]public  bool []         rocksResistancesEnd;

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

    void UpdateCheckResistance()
    {
        for(int i = 0; i < rocksResistancesEnd.Length; i++)
        {
            if(rocksResistances[i] <= 0)
            {
                rocksResistancesEnd[i] = true;
            }else if(rocksResistances[i] >= 0)
            {
                rocksResistancesEnd[i] = false;
            }
        }
    }

    void UpdateResistance()
    {
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
                }else 
                {
                    if(rocksResistances[2] > 0)
                    {
                        rocksResistances[2] -= speedReduceRocksResistances[2] * Time.deltaTime;
                    }
                }
            }
        }else 
        {
            if(rocksResistances[0] < 50 && rocksResistances[1] >= 50 && rocksResistances[2] >= 50 )
            {
                rocksResistances[0] += speedAddRocksResistances[0] * Time.deltaTime;
                
            }
            
            if(rocksResistances[1] < 50 && rocksResistances[2] >= 50)
            {
                rocksResistances[1] += speedAddRocksResistances[1] * Time.deltaTime;
                
            }
                
            if(rocksResistances[2] < 50)
            {
                rocksResistances[2] += speedAddRocksResistances[2] * Time.deltaTime;
                
            }
                    
                
            }
        }
    }

