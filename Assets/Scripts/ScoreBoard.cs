using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {

    //[SerializeField] int scorePerHit = 12; //maybe on enemy?

    int score; //defaults to zero 
    Text scoreText;

	// Use this for initialization
	void Start () {
        scoreText = GetComponent<Text>();//grabs the text component and assigns it to the Text type variable scoreText
        scoreText.text = score.ToString();
	}

    public void ScoreHit(int scoreIncrease) //other components/scripts call this to affect the scores change. In this case its the Enemy script. 
    {
        score = score + scoreIncrease; //scoreIncrease is scorePerHit coming from the Enemy script calling this public method
        scoreText.text = score.ToString();
    }
}
