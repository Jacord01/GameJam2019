using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManagerComp : MonoBehaviour {
    public List<GameObject> flyEnemies_ = new List<GameObject>();
    public List<GameObject> slimeEnemies_ = new List<GameObject>();
    public List<GameObject> robotEnemies_ = new List<GameObject>();

    public Text scoreDisplay;
    int score_;


    // Use this for initialization
    void Start () {

        score_ = 0;

        string scoreText = score_.ToString();
        scoreDisplay.text = scoreText;

    }
	
	// Update is called once per frame
	void Update () {
        string scoreText = score_.ToString();
        scoreDisplay.text = scoreText;
    }

    //Score
    public int GetScore()
    {
        return score_;
    }

    public void SetScore(int amount)
    {
        score_ = amount;
    }

    public void ReduceScore(int amount)
    {
        score_ -= amount;
    }

    public void IncreaseScore(int amount)
    {
        score_ += amount;
    }
}
