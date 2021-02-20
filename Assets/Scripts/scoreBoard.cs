using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreBoard : MonoBehaviour {

    private float points = 0.0f;
    public Text scoreText;
    private int dificultyLevel = 1;
    private int maxDificultyLevel = 10;
    private int scoreToNextLevel = 10;
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        if (points >= scoreToNextLevel)
            levelUp();

        points += Time.deltaTime;
        scoreText.text = ((int)points).ToString();
	}
    void levelUp()
    {
        if (dificultyLevel == maxDificultyLevel)
            return;

        scoreToNextLevel *= 2;
        dificultyLevel++;
        GetComponent<playerMoves>().setSpeed(dificultyLevel);

    }
}
