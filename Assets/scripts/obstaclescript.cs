using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaclescript : MonoBehaviour
{
    [SerializeField] private AudioSource obstableaudio;
    private void OnTriggerEnter2D(Collider2D collider2D){
    if(collider2D.gameObject.CompareTag("player")){
        obstableaudio.Play();
        }
    }
}
