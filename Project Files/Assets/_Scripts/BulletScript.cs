using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour
{

    public GameObject playerNav,player;
    public GameObject enemy;

    public PlayerHealth healthScript;
    public EnemyHealth enemyHealthScript;

    public float speed=0.1f;

	void Awake ()
    {

        player = GameObject.Find("Player");
        playerNav = GameObject.Find("playerNav");

        if (transform.rotation.y < 0)
        {
            speed = -speed;
        }
    
	}


	void Update ()
    {

        transform.position = new Vector3(transform.position.x +speed, transform.position.y, 0);

        if (transform.position.x>20 || transform.position.x<-30)
        {
            Destroy(gameObject);
        }

    }


    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Enemy" )
        {

            enemyHealthScript = col.gameObject.GetComponent<EnemyHealth>();
            enemyHealthScript.DecreaseHealth();
           
        }

        if ( col.collider != null && col.gameObject.tag != "Player" )
        {

            Destroy(gameObject);

        }

    }


}