using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour
{
    public GameObject bullets;
    public GameObject ammo;
    public GameObject gun;

    public Animator animator;

    public Vector2 direction;

    public float timer=0.5f;


    void Awake ()
    {

        animator = GetComponent<Animator>();

        bullets = GameObject.Find("Bullets");
        gun = GameObject.Find("gunPoint");

	}


    void Update ()
    {
        UpdateGunPosition();

        if (Input.GetAxisRaw("Horizontal")!=0)
        {
            animator.SetBool("IsWalking", true);
            animator.SetBool("IsShooting", false);
        }

        if (Input.GetButton("Fire1"))
        {
            Shoot();
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

    void UpdateGunPosition()
    {
        gun.transform.position = new Vector3(transform.position.x+ 1.35f * direction.x, transform.position.y + 0.35f, 0.0f);
    }


    void ApplyShootingAnim()
    {
        animator.SetBool("IsShooting", true);
        animator.SetBool("IsWalking", false);
        //animator.SetBool("IsJumping", false);
    }


    public bool IsShooting()
    {

        if(animator.GetBool("IsShooting"))
        {
            return true;
        }

        else
        {
            return false;
        }
    }


    public void Shoot()
    {

        ApplyShootingAnim();

        if(timer<0)
        {

            Instantiate(ammo, gun.transform.position, transform.rotation,bullets.transform);

            if(GetDirection()=="RIGHT")
            {
                ammo.GetComponent<Rigidbody2D>().velocity = Vector2.right;
            }

            else if(GetDirection()=="LEFT")
            {
                ammo.GetComponent<Rigidbody2D>().velocity = Vector2.left;
            }

            timer = 0.5f;

        }

        else
        {
            timer--;
        }

    }

}
