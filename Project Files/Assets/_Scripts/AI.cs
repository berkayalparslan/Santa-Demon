using UnityEngine;
using System.Collections;


[System.Serializable]
public class AiNav:Component
{
    public bool triggered;
    public bool jumpTriggered;

    public AiNav()
    {
        triggered = false;
        jumpTriggered = false;
    }

    public void Trigger()
    {
        triggered = true;
    }

    public void Clear()
    {
        triggered = false;
    }

    public void TriggerJump()
    {
        jumpTriggered = true;
    }

    public void ClearJump()
    {
        jumpTriggered = false;
    }
}


public class AI : MonoBehaviour
{

    public GameObject playerNav;
    public GameObject candyPoint;
    public GameObject candy;
    public GameObject bullets;

    public AIController ac;

    public GameObject
        aiNavL1, aiNavR1, aiNavM1,
        aiNavL2, aiNavR2, aiNavR2_1,
        aiNavL3, aiNavR3, aiNavR3_1;

    public AiNav navL1, navR1, navM1, navL2, navR2, navR2_1, navL3, navR3, navR3_1;
    public Character ai, player;

    private Vector2 direction;
    

    public float shootTimer;

    public float jumpingHeight;
    public float jumpingTimer;
    public float jumpingDistance;

    public float movementSpeed;

    //public bool isWaiting;


    private void Start ()
    {

        ac = GameObject.Find("AI_CONTROLLER").GetComponent<AIController>();
        bullets = GameObject.Find("Bullets");
        candyPoint = new GameObject("candyPoint");
        candyPoint.transform.parent = gameObject.transform;

        playerNav = GameObject.Find("PlayerNav").gameObject;
        aiNavL1 = GameObject.Find("AI_NAV_L1");
        aiNavR1 = GameObject.Find("AI_NAV_R1");
        aiNavM1 = GameObject.Find("AI_NAV_M1");
        aiNavL2 = GameObject.Find("AI_NAV_L2");
        aiNavR2 = GameObject.Find("AI_NAV_R2");
        aiNavR2_1 = GameObject.Find("AI_NAV_R2_1");
        aiNavL3 = GameObject.Find("AI_NAV_L3");
        aiNavR3 = GameObject.Find("AI_NAV_R3");
        aiNavR3_1 = GameObject.Find("AI_NAV_R3_1");

        ai = new Character();
        player = new Character();

        navL1 = new AiNav();
        navR1 = new AiNav();
        navM1 = new AiNav();
        navL2 = new AiNav();
        navR2 = new AiNav();
        navR2_1 = new AiNav();
        navL3 = new AiNav();
        navR3 = new AiNav();
        navR3_1 = new AiNav();

        shootTimer = 3.0f;

        jumpingHeight = 10.0f;
        jumpingTimer = 0.0f;
        jumpingDistance = 5.0f;

        movementSpeed = 0.15f;
        
        //isWaiting = false;

}
    
    
    //public void Wait()
    //{
    //    isWaiting = true;
    //}


	private void Update ()
    {

        UpdateShootingPosition();
        ac.GetCharacterLocation(gameObject,ai);
        ac.GetCharacterLocation(playerNav, player);
        ac.GetPosition(gameObject,ai);

    }


    private void FixedUpdate()
    {

        FollowPlayerNav();

    }


	public void FollowPlayerNav()
	{ 
		
		if(Vector2.Distance( transform.position,playerNav.transform.position) <10.0f &&  ai.InSameFloor(ai,player) )
		{
			Shoot();
		}

		if (player.inFloor1)
		{

			if (ai.inFloor1)
			{
				MoveToTarget(playerNav);
			}

			else if (ai.inFloor2)
			{

                if (ai.inFloor2Left)
                {
                    MoveToTarget(aiNavL2);
                    navL2.Trigger();
                }

                else if (ai.inFloor2Right)
                {

                    MoveToTarget(aiNavR2);
                    navR2.Trigger();

                }

            }

            else if (ai.inFloor3)
            {

                if (ai.inFloor3Left)
                {

                    MoveToTarget(aiNavL3);
                    navL3.Trigger();

                }

                else if (ai.inFloor3Right)
                {

                    MoveToTarget(aiNavR3_1);
                    navR3_1.Trigger();
                }

            }

            else
            {
                Debug.Log("where is AI LOL");
                

            }

        }

        else if (player.inFloor2)
        {

            if (player.inFloor2Left)
            {

                if (ai.inFloor1)
                {

                    MoveToTarget(aiNavL1);
                    navL1.TriggerJump();

                }
                else if (ai.inFloor2)
                {

                    if (ai.inFloor2Left)
                    {
                        MoveToTarget(playerNav);
                    }

                    else if (ai.inFloor2Right)
                    {
                        MoveToTarget(aiNavR2);
                        navR2.Trigger();
                    }

                }

                else if (ai.inFloor3)
                {

                    if (ai.inFloor3Left)
                    {
                        MoveToTarget(aiNavL3);
                        navL3.Trigger();
                    }

                    else if (ai.inFloor3Right)
                    {
                        MoveToTarget(aiNavR2_1);
                        navR3.Trigger();
                    }

                }
            }

            else if (player.inFloor2Right)
            {

                if (ai.inFloor1)
                {
                    MoveToTarget(aiNavR1);
                    navR1.TriggerJump();
                }

                else if (ai.inFloor2)
                {

                    if (ai.inFloor2Left)
                    {
                        MoveToTarget(aiNavL2);
                        navL2.Trigger();
                    }

                    else if (ai.inFloor2Right)
                    {
                        MoveToTarget(playerNav);
                    }

                }

                else if (ai.inFloor3)
                {

                    if (ai.inFloor3Left)
                    {
                        MoveToTarget(aiNavL3);
                        navL3.TriggerJump();
                    }

                    else if (ai.inFloor3Right)
                    {
                        MoveToTarget(aiNavR3);
                        navR3.Trigger();
                    }
                }
                else
                {
                    Debug.Log("where is AI LOL x2");
                    
                }
            }
        }

        else if (player.inFloor3)
        {

            if (player.inFloor3Left)
            {

                if (ai.inFloor1)
                {
                    MoveToTarget(aiNavR1);
                    navR1.TriggerJump();
                }

                else if (ai.inFloor2)
                {

                    if (ai.inFloor2Left)
                    {
                        MoveToTarget(aiNavL2);
                        navL2.Trigger();
                    }

                    else if (ai.inFloor2Right)
                    {
                        MoveToTarget(aiNavR2);
                        navR2.TriggerJump();
                    }

                }

                else if (ai.inFloor3)
                {

                    if (ai.inFloor3Left)
                    {
                        MoveToTarget(playerNav);
                    }

                    else if (ai.inFloor3Right)
                    {
                        MoveToTarget(aiNavR3_1);
                        navR3_1.TriggerJump();
                    }
                }
            }

            else if (player.inFloor3Right)
            {
                if (ai.inFloor1)
                {
                    MoveToTarget(aiNavR1);
                    navR1.TriggerJump();
                }

                else if (ai.inFloor2)
                {

                    if (ai.inFloor2Left)
                    {
                        MoveToTarget(aiNavL2);
                        navL2.Trigger();
                    }

                    else if (ai.inFloor2Right)
                    {
                        MoveToTarget(aiNavR2);
                        navR2.TriggerJump();
                    }
                }

                else if (ai.inFloor3)
                {

                    if (ai.inFloor3Left)
                    {
                        MoveToTarget(aiNavL3);
                        navL3.TriggerJump();
                    }

                    else if (ai.inFloor3Right)
                    {
                        MoveToTarget(playerNav);
                    }
                }

                else
                {
                    Debug.Log("where is AI LOL x3");
                    
                }

            }

        }

        else
        {
            Idle();

        }

	}

    void Idle()
    {

        if (ai.inFloor1)
        {
            MoveToTarget(aiNavM1);
        }

        else if (ai.inFloor2)
        {

            if(ai.inFloor2Left)
            {
                MoveToTarget(aiNavL2);
            }

            else if (ai.inFloor2Right)
            {
                MoveToTarget(aiNavR2);
            }
            
        }
        else if (ai.inFloor3)
        {

            if(ai.inFloor3Left)
            {
                MoveToTarget(aiNavL3);
            }

            else if (ai.inFloor3Right)
            {
                MoveToTarget(aiNavR3_1);
            }
            
        }

    }

    void Shoot()
    {
        
        if (shootTimer < 0.0f)
        {
            Instantiate(candy, candyPoint.transform.position, transform.rotation, bullets.transform);

            if (GetDirection() == "RIGHT")
            {
                candy.GetComponent<Rigidbody2D>().velocity = Vector2.right;
            }

            else if (GetDirection() == "LEFT")
            {
                candy.GetComponent<Rigidbody2D>().velocity = Vector2.left;
            }
            shootTimer = 3.0f;
        }

        else
        {
            shootTimer -= Time.deltaTime;
        }

    }


    string GetDirection()
    {

        if (transform.rotation.y >= 0)
        {
            direction = Vector2.right;
            return "RIGHT";
        }

        else
        {
            direction = Vector2.left;
            return "LEFT";
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {

       if(navL2.triggered && col.gameObject == aiNavL2)
        {
            MoveToTarget(aiNavL1);
        }

       if(navR2.triggered && col.gameObject == aiNavR2)
        {
            MoveToTarget(aiNavR1);
        }

       if(navR3_1.triggered && col.gameObject == aiNavR3_1)
        {
            MoveToTarget(aiNavL1);
        }

       if(navL1.jumpTriggered && col.gameObject == aiNavL1)
        {
            // JUMP FIX FOR FLOOR LEFT 2 , added 1.25f
            Jump(col.gameObject,aiNavL2,jumpingHeight*1.25f);
        }

       if(navL3.triggered && col.gameObject== aiNavL3)
        {
            MoveToTarget(aiNavL1);
        }

       if(navR3.triggered && col.gameObject == aiNavR3)
        {
            MoveToTarget(aiNavR2_1,movementSpeed*3.0f);
        }

        if (navR1.jumpTriggered && col.gameObject == aiNavR1)
        {
            Jump(col.gameObject, aiNavR2, jumpingHeight*1.25f);
        }
        //JUMP FIX FOR FLOOR RIGHT 2
        else if (navR1.jumpTriggered && col.gameObject == aiNavR2)
        {
            MoveToTarget(aiNavR2_1, movementSpeed * 5);
        }

        //adding navR1.jumpTriggered==false line (JUMP FIX) FOR FLOOR RIGHT 2
        if (navR2.jumpTriggered && col.gameObject == aiNavR2 && !(navR1.jumpTriggered))
        {
            Jump(col.gameObject,aiNavR3,jumpingHeight*1.175f);
        }

       if(navR3_1.jumpTriggered && col.gameObject==aiNavR3_1)
        {
            Jump(col.gameObject,aiNavL3);
        }

       if(navL3.jumpTriggered && col.gameObject ==aiNavL3)
        {
            Jump(col.gameObject,aiNavR3,jumpingHeight*0.25f);
        }

    }

    void OnTriggerStay2D(Collider2D col)
    {

        if (navL2.triggered && col.gameObject == aiNavL2)
        {
            MoveToTarget(aiNavL1);
        }

        if (navR2.triggered && col.gameObject == aiNavR2)
        {
            MoveToTarget(aiNavR1);
        }

        if (navR3_1.triggered && col.gameObject == aiNavR3_1)
        {
            MoveToTarget(aiNavL1);
        }

        if (navL1.jumpTriggered && col.gameObject == aiNavL1)
        {
            // JUMP FIX FOR FLOOR LEFT 2 , added 1.25f
            Jump(col.gameObject, aiNavL2, jumpingHeight);
        }

        if (navL3.triggered && col.gameObject == aiNavL3)
        {
            MoveToTarget(aiNavL1, movementSpeed);
        }

        if (navR3.triggered && col.gameObject == aiNavR3)
        {
            MoveToTarget(aiNavR2_1, movementSpeed * 3.0f);
        }

        if (navR1.jumpTriggered && col.gameObject == aiNavR1)
        {
            Jump(col.gameObject, aiNavR2,jumpingHeight);
        }
        //JUMP FIX FOR FLOOR RIGHT 2
        else if (navR1.jumpTriggered && col.gameObject == aiNavR2)
        {
            MoveToTarget(aiNavR2_1,movementSpeed);
        }
        //adding navR1.jumpTriggered==false line (JUMP FIX) FOR FLOOR RIGHT 2
        if (navR2.jumpTriggered && col.gameObject == aiNavR2  && !(navR1.jumpTriggered) )
        {
            Jump(col.gameObject, aiNavR3);
        }

        if (navR3_1.jumpTriggered && col.gameObject == aiNavR3_1)
        {
            Jump(col.gameObject, aiNavL3, jumpingHeight * 0.25f);
        }

        if (navL3.jumpTriggered && col.gameObject == aiNavL3)
        {
            Jump(col.gameObject, aiNavR3_1,jumpingHeight*0.25f);
        }

    }
    void OnTriggerExit2D(Collider2D col)
    {

        if (navL2.triggered && col.gameObject == aiNavL2)
        {
            navL2.Clear();
        }

        if (navR2.triggered && col.gameObject == aiNavR2)
        {
            navR2.Clear();
        }

        if (navR3_1.triggered && col.gameObject == aiNavR3_1)
        {
            navR3_1.Clear();
        }

        if (navL1.jumpTriggered && col.gameObject == aiNavL1)
        {
            navL1.ClearJump();
        }

        if (navL3.triggered && col.gameObject == aiNavL3)
        {
            navL3.Clear();
        }

        if (navR3.triggered && col.gameObject == aiNavR3)
        {
            navR3.Clear();
        }

        if (navR1.jumpTriggered && col.gameObject == aiNavR1)
        {
            navR1.ClearJump();
        }
        //JUMP FIX
        else if (navR1.jumpTriggered && col.gameObject == aiNavR2)
        {
            navR1.ClearJump();
        }
        //adding navR1.jumpTriggered==false line (JUMP FIX)
        if (navR2.jumpTriggered && col.gameObject == aiNavR2 && !navR1.jumpTriggered)
        {
            navR2.ClearJump();
        }

        if (navR3_1.jumpTriggered && col.gameObject == aiNavR3_1)
        {
            navR3_1.ClearJump();
        }

        if (navL3.jumpTriggered && col.gameObject == aiNavL3)
        {
            navL3.ClearJump();
        }

    }


    void OnCollisionEnter2D(Collision2D col)
    {

        if(col.gameObject.tag == "Ground" || col.gameObject.tag == "Platform" || col.gameObject.tag == "Player")
        {
            jumpingTimer = 0.0f;
        }
       
    }

    
    void Jump(GameObject nav, GameObject target)
    {

        if (target.tag == "AINAV" && jumpingTimer < 2.0f)
        {
            jumpingTimer++;

            float distanceToNav = Vector2.Distance(target.transform.position, nav.transform.position);
            Vector2 jumpingVector = new Vector2(distanceToNav * direction.x, jumpingHeight);

            SetMovementDirection(target.transform.position.x > nav.transform.position.x);
            GetComponent<Rigidbody2D>().AddForce(jumpingVector, ForceMode2D.Impulse);
        }

    }

    void Jump(GameObject nav, GameObject target, float height)
    {

        if (target.tag == "AINAV" && jumpingTimer < 2.0f)
        {
            jumpingTimer++;

            float distanceToNav = Vector2.Distance(target.transform.position, nav.transform.position);
            Vector2 jumpingVector = new Vector2(distanceToNav * direction.x, height);

            SetMovementDirection(target.transform.position.x > nav.transform.position.x);
            GetComponent<Rigidbody2D>().AddForce(jumpingVector, ForceMode2D.Impulse);
        }

    }


    void MoveToTarget(GameObject target)
    {
        SetMovementDirection(target.transform.position.x > transform.position.x);
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, movementSpeed);
    }


    void MoveToTarget(GameObject target,float speed)
    {
        SetMovementDirection(target.transform.position.x > transform.position.x);
        transform.position = Vector2.MoveTowards(transform.position,target.transform.position, speed);
    }


    void SetMovementDirection(bool GoingRight)
    {
        if(GoingRight)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            direction = Vector2.right;
        }

        else
        {
            transform.rotation = new Quaternion(0, -180, 0, 0);
            direction = Vector2.left;
        }

    }


    void UpdateShootingPosition()
    {
        candyPoint.transform.position = new Vector3(transform.position.x + 0.2f * direction.x, transform.position.y + 0.8f, 0.0f);
    }


}
