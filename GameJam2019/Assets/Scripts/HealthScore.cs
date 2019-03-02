﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScore : MonoBehaviour {

    public bool dash_, shield_, lifeSteal_;
    float timeLeft_;
    int health_;
    int score_;
    int currentPower_;
    public Slider healthBar;
    public Text scoreDisplay;

    // Use this for initialization
    void Start()
    {
        health_ = 100;
        score_ = 0;

        dash_ = false;
        shield_ = false;
        lifeSteal_ = false;

        healthBar.value = health_;
        string scoreText = score_.ToString();
        scoreDisplay.text = scoreText;

        int rnd = Random.Range(1,4);
        currentPower_ = rnd;
        SetPowerTrue(currentPower_);

        //Cooldown
        timeLeft_ = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

        //Update health & Score on Hud
        healthBar.value = health_;
        string scoreText = score_.ToString();
        scoreDisplay.text = scoreText;

        //Powers

            timeLeft_ -= Time.deltaTime;
            if (timeLeft_ < 0)
            {
                currentPower_ = (currentPower_ + 1) % 4;
            if (currentPower_ == 0)
                currentPower_ = 1;
            SetPowerTrue(currentPower_);
                timeLeft_ = 20.0f;
            }       
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

    //Powers
    public bool GetPower(int power)
    {
        if(power == 1)
            return dash_;
        else if(power == 2)
            return shield_;
        else
            return lifeSteal_;
    }

    public void SetPower(int power, bool status)
    {
        if (power == 1)
            dash_ = status;

        else if (power == 2)
             shield_ = status;
        else
            lifeSteal_ = status;
        Debug.Log("Current Power: " + currentPower_);
    }

    public void SetPowerTrue(int power)
    {
        currentPower_ = power;
        dash_ = false;
        shield_ = false;
        lifeSteal_ = false;

        if (power == 1) 
            dash_ = true;

        else if (power == 2)
            shield_ = true;
        else
            lifeSteal_ = true;
        Debug.Log("Current Power: " + currentPower_);
    }

}
