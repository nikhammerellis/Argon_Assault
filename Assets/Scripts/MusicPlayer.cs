using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    private void Awake()
    {
        int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length; //literally the number of object type MusicPlayer found

        if (numMusicPlayers > 1) {
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
        }
    }
}
