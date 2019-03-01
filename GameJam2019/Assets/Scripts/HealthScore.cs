using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScore : MonoBehaviour {

    public bool shield_;
    int health_;
    int score_;

    public Slider healthBar;
    public Text scoreDisplay;

    // Use this for initialization
    void Start()
    {
        health_ = 100;
        score_ = 0;
        shield_ = false;
        healthBar.value = health_;
        string scoreText = score_.ToString();
        scoreDisplay.text = scoreText;
    }

    // Update is called once per frame
    void Update()
    {

        //Update health on Hud
        healthBar.value = health_;
        string scoreText = score_.ToString();
        scoreDisplay.text = scoreText;
    }

    //Health
    public int GetHealth()
    {
        return health_;
    }

    public void SetHealth(int amount)
    {
        health_ = amount;
    }

    public void ReduceHealth(int amount)
    {
        health_ -= amount;
    }

    public void IncreaseHealth(int amount)
    {
        health_ += amount;
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
