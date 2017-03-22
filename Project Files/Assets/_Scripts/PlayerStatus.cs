using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour
{
    public Animator animator;
    public GameObject playerNav;

    private float timer = 0.5f;
    public float speed = 0.5f;


    void Awake()
    {
        animator = GetComponent<Animator>();
    }


    void Start()
    {
        playerNav.transform.position = this.transform.position;
        
    }


    void Update ()
    {
        if (timer > .0f)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= .0f)
        {
            timer = 0.5f;
            UpdatePosition();
        }

    }


    void UpdatePosition()
    {
        playerNav.transform.position = transform.position;
    }

}
