using UnityEngine;
using System.Collections;

public class JumpingScript : MonoBehaviour
{
    public float jumpingHeight;
    public float jumpingTimer;
    public float timerValue;

    private Animator animator;
    private Rigidbody2D rb;

    public bool pressedOnce;

    void Start ()
    {
        jumpingTimer = 0.0f;
        timerValue = 2.0f;
        jumpingHeight = 5.5f;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        if ( Input.GetAxis("Vertical") > 0 )
        {
            Jump();
        }

    }


    void Jump()
    {
        if(jumpingTimer<timerValue)
        {
            //alreadyJumped = true;
            jumpingTimer++;
            animator.SetBool("IsJumping", true);
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsShooting", false);
            rb.AddForce(new Vector2(0, jumpingHeight), ForceMode2D.Impulse);
            //transform.position=new Vector3(transform.position.x, transform.position.y+jumpingHeight, 0);
            //transform.position=Vector3.MoveTowards(transform.position,)
            //Debug.Log("you jumped");
        }

    }
    

    void OnCollisionEnter2D(Collision2D col)
    {

        if ( col.gameObject.tag=="Ground" || col.gameObject.tag=="Platform" || col.gameObject.tag=="Enemy"
            && col.gameObject.transform.position.y > transform.position.y )

        {
            jumpingTimer = 0;
        }

    }

}
