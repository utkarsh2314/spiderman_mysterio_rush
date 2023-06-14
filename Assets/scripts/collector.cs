using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collector : MonoBehaviour
{
    public static int coinpoints=0;
    public static int enemypoints=0;
    [SerializeField] private AudioSource coinCollect;
    [SerializeField] private AudioSource obstableaudio;
    [SerializeField] private AudioSource enemydeath;
    public displayscore displayscore;
    public gameover gameover;

    private void OnTriggerEnter2D(Collider2D collider2D){
        if(collider2D.gameObject.CompareTag("coin")){
            coinCollect.Play();
            Destroy(collider2D.gameObject);
            coinpoints++;
            displayscore.Setupcoin(coinpoints);
        }
        if(collider2D.gameObject.CompareTag("enemy")){
            enemydeath.Play();
            Destroy(collider2D.gameObject);
            enemypoints++;
            displayscore.Setupenemy(enemypoints);
        }
        if(collider2D.gameObject.CompareTag("obstacle")){
            obstableaudio.Play();
            Destroy(gameObject);
            gameover.Setup();
        }
    }
}
