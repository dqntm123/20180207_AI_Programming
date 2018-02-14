using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public GameObject mainScore;
    public GameObject goalScore;
    public int score = 0;
    public int countE;
    void Start ()
    {
        
	}
	
	
	void Update ()
    {
       
	}
    public void ToTalScore()
    {
        score += 5;
        mainScore.GetComponent<TextMesh>().text = "Score : " + score;
    }
}
