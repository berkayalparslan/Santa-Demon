using UnityEngine;
using System.Collections;

public class WalkingScript : MonoBehaviour
{

    private Animator animator;
    private ShootingScript shootingScript;

    public float speed;

    public bool IsGoingPositive;


	void Start ()
    {
        animator = GetComponent<Animator>();
        shootingScript = GetComponent<ShootingScript>();
        speed = 0.25f;
	}


	void Update ()
    {

        if (shootingScript.IsShooting() == false)
        {

            Walk();

        }   
            
    }


    void Walk()
    {

        animator.SetBool("IsWalking", true);
        animator.SetBool("IsJumping", false);
        animator.SetBool("IsShooting", false);
        
        if(Input.GetAxis("Horizontal")>0)
        {   
            animator.transform.rotation = new Quaternion(0, 0, 0, 0);
            animator.transform.position += (new Vector3(speed, 0, 0));

            IsGoingPositive = true;
        }

        else if (Input.GetAxis("Horizontal")<0)
        {
            animator.transform.rotation = new Quaternion(0, -90, 0, 0);
            animator.transform.position += (new Vector3(-speed, 0, 0));

            IsGoingPositive = false;

        }

    }


}
