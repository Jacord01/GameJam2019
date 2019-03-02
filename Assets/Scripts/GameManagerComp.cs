using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManagerComp : MonoBehaviour {
    public List<GameObject> flyEnemies_ = new List<GameObject>();
    public List<GameObject> slimeEnemies_ = new List<GameObject>();
    public List<GameObject> robotEnemies_ = new List<GameObject>();

    public GameObject fly_;
    public GameObject slime_;
    public GameObject robot_;

    //SpawnZone
    float xm, xM, yf, yr, ys, zm, zM;
    enemies currentEnemies_;
    int min, max;
    bool fFin, sFin, rFin;

    //Cooldown
    float timeLeft_ = 0.0f;
    public Text scoreDisplay;
    int score_;
    int currentLevel_;

    struct enemies
    { 
        public int numFlyers_;
        public int numSlimes_;
        public int numRobots_;

        public enemies(int numFlyers, int numSlimes, int numRobots)
        {
            numFlyers_ = numFlyers;
            numSlimes_ = numSlimes;
            numRobots_ = numRobots;
        }
    };

    // Use this for initialization
    void Start () {

        score_ = 0;
        currentLevel_ = 3;

        string scoreText = score_.ToString();
        scoreDisplay.text = scoreText;

        //SpawnZone
        xm = -30.0f;
        xM = 50.0f;
        yf = -11.0f;
        yr = -11.8f;
        ys = -10.5f;
        zm = -40.0f;
        zM = 60.0f;

        min = 1;
        max = 4;

        fFin = false;
        sFin = false;
        rFin = false;

        Init();
    }
    void Init()
    {
        currentEnemies_ = AmountOfEnemiesInLvl(currentLevel_);
        Debug.Log(currentEnemies_.numFlyers_ + currentEnemies_.numSlimes_ + currentEnemies_.numRobots_);
    }

    // Update is called once per frame
    void Update () {
        string scoreText = score_.ToString();
        scoreDisplay.text = scoreText;

        timeLeft_ -= Time.deltaTime;

        bool spawned = false;
        if (timeLeft_ < 0)
        {
            Debug.Log("Spawn");
            int rnd = Random.Range(min, max);
            if ((rnd == 1 || sFin || rFin) && !spawned)
                if (flyEnemies_.Count < currentEnemies_.numFlyers_)
                {
                    flyEnemies_.Add(InstantiateEnemy(fly_, GenerateRandom(fly_)));
                    spawned = true;
                }
                else;

            if ((rnd == 2 || fFin || rFin) && !spawned)
                if (slimeEnemies_.Count < currentEnemies_.numSlimes_)
                {
                    slimeEnemies_.Add(InstantiateEnemy(slime_, GenerateRandom(slime_)));
                    spawned = true;
                }
                else;

            if ((rnd == 3 || fFin || sFin) && !spawned)
                if (robotEnemies_.Count < currentEnemies_.numRobots_)
                {
                    robotEnemies_.Add(InstantiateEnemy(robot_, GenerateRandom(robot_)));
                    spawned = true;
                }
                else;
            timeLeft_ = Random.Range(2, 8);
        }
    }

    enemies AmountOfEnemiesInLvl(int level)
    {
        int rnd = Random.Range(0, 2);
        int x = 1;
        if (rnd == 1)
            x = -1;
        else;

        int dif = level + x * level / 2;
        switch (level)
        {
            case 1:
                return new enemies(1, 1, 0);
            case 2:
                return new enemies(2, 2, 1);
            default:
                return new enemies(dif, dif, dif);
        }
    }

    Vector3 GenerateRandom(GameObject enemy )
    {
        float rndX = Random.Range(xm, xM);
        float rndZ = Random.Range(zm, zM);
        if(enemy == fly_)
            return new Vector3(rndX, yf, rndZ);
        else if(enemy == slime_)
            return new Vector3(rndX, ys, rndZ);
        else
            return new Vector3(rndX, yr, rndZ);
    }

    GameObject InstantiateEnemy (GameObject enemy, Vector3 pos)
    {
        Debug.Log("Spawn: " + enemy.name);
        return Instantiate(enemy, pos, Quaternion.identity);
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
