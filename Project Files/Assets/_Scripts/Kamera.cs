using UnityEngine;
using System.Collections;

public class Kamera : MonoBehaviour
{

    public GameObject playerNav;
    public AIController AC;

    private Vector3 pos;


    void Start ()
    {
        pos = playerNav.transform.position;
	}


    void Update ()
    {

        pos = playerNav.transform.position;

        if ( pos.x> -13.5f && pos.x < 3.5f && pos.y < 5.0f )
        {
            transform.position = new Vector3(pos.x, pos.y + 6.5f, transform.position.z);
        }

        else if (pos.x > -13.5f && pos.x < 3.5f && pos.y > 5.0f )
        {
            transform.position = new Vector3(pos.x, transform.position.y, transform.position.z);
        }

    }

}
