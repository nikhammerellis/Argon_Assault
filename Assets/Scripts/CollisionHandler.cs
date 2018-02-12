using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // ok as long as this is the only script that loads scenes 

public class CollisionHandler : MonoBehaviour {

    [Tooltip("In seconds")][SerializeField] float levelLoadDelay = 1f;
    [Tooltip("FX prefab on player")][SerializeField] GameObject deathFX;

    int collisionCount = 0; //bug workaround, below triggers on game start for no apparent reason 
    void OnTriggerEnter(Collider other)
    {
        collisionCount++;//everything but StartDeathSequence is a workaround for a bug where OnTriggerEnter fires once when the game starts 
        if (collisionCount > 1) {
            StartDeathSequence();
            deathFX.SetActive(true);
            Invoke("ReloadScene", levelLoadDelay);
        }
    }

    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");//more than one script could be listening for this, FYI
    }

    private void ReloadScene() //string referenced
    {
        SceneManager.LoadScene(1);
    }
}
