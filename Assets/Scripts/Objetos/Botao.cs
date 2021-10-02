using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botao : MonoBehaviour
{
    public bool ativo=false;
    public Animator anim;

    void Start()
    {
       
    }

    void OnTriggerEnter2D(Collider2D col)
    {
       if(col.gameObject.tag=="pedra")
       {
           ativo=true;
           anim.SetTrigger("Pre");
       } 
    }

    void OnTriggerExit2D(Collider2D col)
    {
       if(col.gameObject.tag=="pedra")
       {
           ativo=false;
           anim.SetTrigger("Normal");
       } 
    }
}
