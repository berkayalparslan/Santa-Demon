using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{

    public AIController ac;

    public float 
        hp,
        minValue,
        maxValue,
        hitValue;

    void Awake ()
    {

        ac = GameObject.Find("AI_CONTROLLER").GetComponent<AIController>();

        minValue = 0.0f;
        maxValue = 100.0f;

        hp = maxValue;
        hitValue = 35.0f;

	}


    public void DecreaseHealth()
    {
        hp -= hitValue;

        if (hp <= minValue)
        {
            Kill();
        }

    }


    void Kill()
    {
        Destroy(gameObject);

        ac.numberOfEnemy--;
        ac.IncreaseScore();
    }

}
