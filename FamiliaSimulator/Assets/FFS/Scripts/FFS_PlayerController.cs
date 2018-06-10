using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FFS_PlayerController : MonoBehaviour {

    public float speed = 1f;

    private Rigidbody2D rbody;
    private Transform ptransform;
    

	// Use this for initialization
	void Start () {
        ptransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        int horizontal;
        int vertical;

        if(Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            horizontal = -1;
        }
        else if(!Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            horizontal = 1;
        }
        else
        {
            horizontal = 0;
        }

        if (Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow))
        {
            vertical = -1;
        }
        else if (!Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            vertical = 1;
        }
        else
        {
            vertical = 0;
        }

        ptransform.position += new Vector3(horizontal * speed * Time.deltaTime, vertical * speed * Time.deltaTime);
	}
}
