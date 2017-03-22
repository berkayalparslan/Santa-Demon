using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public Text gameOver;
    public Text healthBar;

    public ShootingScript shootingScript;
    public PlayerHealth healthScript;

    public float hp;
    public float hitValue;
    private float minValue;
    
	void Awake ()
    {
        shootingScript = GetComponent<ShootingScript>();
        healthScript = GetComponent<PlayerHealth>();

        healthBar.text = hp.ToString();

        minValue = 0.0f;
        hp = 100.0f;
        hitValue = 5.0f;

    }


	void Update ()
    {
        healthBar.text = hp.ToString();
    }


    void OnCollisionEnter2D(Collision2D col)
    {

        if ( col.gameObject.CompareTag("Enemy") )
        {

            EnemyHealth enemyHealthScript = col.gameObject.GetComponent<EnemyHealth>();

            healthScript.DecreaseHealth(col.gameObject.tag);
            enemyHealthScript.DecreaseHealth();
        }

    }


    public void DecreaseHealth(string tag)
    {

        float ammoHitConst=2.0f;

        if( tag=="Ammo" )
        {
            hp -= hitValue*ammoHitConst;
        }

        else
        {
            hp -= hitValue;
        }

        if( hp<=minValue )
        {
            Kill();
        }

    }


    void Kill()
    {

        gameOver.gameObject.SetActive(true);
        Destroy(gameObject);

        GameObject.Find("GameSettings").GetComponent<GameSettings>().gameOver = true;
        GameObject.Find("GameSettings").SendMessage("Pause");
        
    }




}
