using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public LogicScript logicScript;

    //public AudioClip audio;

    public AudioSource audioSource;

    BirdMovement birdMovement;
    GameObject pak;

    void Start()
    {
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        pak = GameObject.FindWithTag("Player");

        audioSource = pak.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            
            logicScript.addscore(5);
            Destroy(gameObject);
            audioSource.Play();
        }
    }
}
