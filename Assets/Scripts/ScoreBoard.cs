using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {

    [SerializeField] int scorePerHit = 12;
    int score;
    Text scoreText;
	void Start ()
    {
        scoreText = GetComponent<Text>();
    }

    public void ScoreHit()
    {
        score += scorePerHit;
        scoreText.text = score.ToString();
    }

}
