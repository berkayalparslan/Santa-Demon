using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class Character
{

    public bool
        inFloor1,

        inFloor2,
        inFloor2Left,
        inFloor2Right,

        inFloor3,
        inFloor3Left,
        inFloor3Right
        ;


    public Character()
    {
        inFloor1 = false;

        inFloor2 = false;
        inFloor2Left = false;
        inFloor2Right = false;

        inFloor3 = false;
        inFloor3Left = false;
        inFloor3Right = false;

    }


    public bool InSameFloor(Character obj1, Character obj2)
    {

        if (obj1.inFloor1 && obj2.inFloor1
            || obj1.inFloor2 && obj2.inFloor2
            || obj1.inFloor3 && obj2.inFloor3
            )
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}

[System.Serializable]
public class spawnPoints
{

    private Vector2
        floor1_min,
        floor1_max,

        floor2Left_min,
        floor2Left_max,

        floor2Right_min,
        floor2Right_max,

        floor3Left_min,
        floor3Left_max,

        floor3Right_min,
        floor3Right_max
        ;

    private float x, y;
    private int timer;
    public int Timer
    {
        get
        {
            return timer;
        }
    }

    public spawnPoints()
    {
        floor1_min = new Vector2(-30, 0);
        floor1_max = new Vector2(20, 5);

        floor2Left_min = new Vector2(-30,5);
        floor2Left_max = new Vector2(-10, 10);

        floor2Right_min = new Vector2(7, 5);
        floor2Right_max = new Vector2(15, 10);

        floor3Left_min = new Vector2(-30, 10);
        floor3Left_max = new Vector2(-10, 15);

        floor3Right_min = new Vector2(-5, 10);
        floor3Right_max = new Vector2(5, 15);

    }

    public Vector2 InitializeEnemies(int num)
    {
        if(num==0)
        {
            return Floor1();
        }

        else if (num==1)
        {
            return Floor2Left();
        }

        else if(num==2)
        {
            return Floor2Right();
        }

        else if (num==3)
        {
            return Floor3Left();
        }

        else if (num==4)
        {
            return Floor3Right();
        }

        else
        {
            return Vector2.zero;
        }

    }

    public Vector2 GenerateSpawnPoints()
    {
        int number = Random.Range(1, 5);

        if (number == 1)
        {
            return Floor1();
        }

        else if (number == 2)
        {
            return Floor2Left();
        }

        else if (number == 3)
        {
            return Floor2Right();
        }

        else if (number == 4)
        {
            return Floor3Left();
        }

        else if (number == 5)
        {
            return Floor3Right();
        }

        else
        {
            return Vector2.zero;
        }
    }


    public Vector2 Floor1()
    {

        x= Random.Range(floor1_min.x, floor1_max.x);
        y = (floor1_max.y + floor1_min.y) / 2;

        return new Vector2(x, y);
    }


    public Vector2 Floor2Left()
    {

        x = Random.Range(floor2Left_min.x, floor2Left_max.x);
        y = (floor2Left_min.y + floor2Left_max.y) / 2;

        return new Vector2(x, y);
    }


    public Vector2 Floor2Right()
    {

        x = Random.Range(floor2Right_min.x, floor2Right_max.x);
        y = (floor2Right_min.y + floor2Right_max.y) / 2;

        return new Vector2(x, y);
    }


    public Vector2 Floor3Left()
    {

        x = Random.Range(floor3Left_min.x, floor3Left_max.x);
        y = (floor3Left_min.y + floor3Left_max.y) / 2;

        return new Vector2(x, y);
    }


    public Vector2 Floor3Right()
    {

        x = Random.Range(floor3Right_min.x, floor3Right_max.x);
        y = (floor3Right_min.y + floor3Right_max.y) / 2;

        return new Vector2(x, y);
    }

    
    public bool CheckTimer()
    {
        if(timer<3)
        {
            timer++;
            return true;
        }
        else
        {
            timer = 0;
            return false;
        }
        
    }
    

}

public class AIController : MonoBehaviour
{
    
    public Character ai, player;

    public GameObject playerNav;
    public GameObject EnemyParentObj;
    public GameObject Enemy;

    public GameObject
        aiNavL1, aiNavR1, aiNavM1,
        aiNavL2, aiNavR2, aiNavR2_1,
        aiNavL3, aiNavR3, aiNavR3_1;

    public Text scoreText;
    public spawnPoints spawn;

    //public GameObject[] Enemies;

    public int numberOfEnemy;
    public int minNumber, maxNumber;


	void Start ()
    {
        aiNavL1 = GameObject.Find("AI_NAV_L1");
        aiNavR1 = GameObject.Find("AI_NAV_R1");
        aiNavM1 = GameObject.Find("AI_NAV_M1");
        aiNavL2 = GameObject.Find("AI_NAV_L2");
        aiNavR2 = GameObject.Find("AI_NAV_R2");
        aiNavR2_1 = GameObject.Find("AI_NAV_R2_1");
        aiNavL3 = GameObject.Find("AI_NAV_L3");
        aiNavR3 = GameObject.Find("AI_NAV_R3");
        aiNavR3_1 = GameObject.Find("AI_NAV_R3_1");


        spawn = new spawnPoints();

        scoreText.text = "0";

        numberOfEnemy = 0;

        minNumber = 0;
        maxNumber = 2;

        while (numberOfEnemy < maxNumber)
        {
            SetupEnemies(numberOfEnemy);
        }

    }


    void Update ()
    {
        GetCharacterLocation(playerNav, player);
        AddNewEnemy();
    }


    void AddNewEnemy()
    {

        if ( numberOfEnemy < maxNumber && spawn.CheckTimer() )
        {

            Instantiate(Enemy, spawn.GenerateSpawnPoints(), new Quaternion(0, 0, 0, 0), EnemyParentObj.transform);
            numberOfEnemy++;
        }

    }


    void SetupEnemies(int num)
    {
        Instantiate(Enemy, spawn.InitializeEnemies(num), new Quaternion(0, 0, 0, 0), EnemyParentObj.transform);
        numberOfEnemy++;
    }


    public Vector2 GetPosition(GameObject obj,Character ai)
    {
        Vector2 pos;
        pos = obj.transform.position;
        return pos;
    }

   
    public void IncreaseScore()
    {
        int score;
        score = int.Parse(scoreText.text);
        score++;
        scoreText.text = score.ToString();
    }


    public void GetCharacterLocation(GameObject obj, Character character)
    {
        
        character.inFloor1 = obj.transform.position.y >= 0 && obj.transform.position.y <= 5;
        character.inFloor2 = obj.transform.position.y >= 5 && obj.transform.position.y <= 10;
        character.inFloor3 = obj.transform.position.y >= 10 && obj.transform.position.y <= 15;

        character.inFloor2Left = character.inFloor2 && obj.transform.position.x <= aiNavL2.transform.position.x;
        character.inFloor2Right = character.inFloor2 && obj.transform.position.x >= aiNavR2.transform.position.x;

        character.inFloor3Left = character.inFloor3 && obj.transform.position.x <= aiNavL3.transform.position.x
            && obj.transform.position.x >= -30;

        character.inFloor3Right = character.inFloor3 && obj.transform.position.x >= aiNavR3_1.transform.position.x
            && obj.transform.position.x <= aiNavR3.transform.position.x;

    }
}
