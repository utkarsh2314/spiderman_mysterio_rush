using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionscript : MonoBehaviour
{
    public Animator transition;
    private void OnTriggerEnter2D(Collider2D collider2D){
    if(collider2D.gameObject.CompareTag("player")){
            transition.SetTrigger("blast");
        }
    }
}
