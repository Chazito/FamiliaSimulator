using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FFS_PlayerController2 : MonoBehaviour {

	private Animator anim;

	private bool playerMoving;
	private Vector2 lastMove;
	private FFS_PlayerStats stats;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		stats = GetComponent<FFS_PlayerStats>();
	}
	
	// Update is called once per frame
	void Update () 
	{

		playerMoving = false;

		if(Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
		{
			transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * stats.speed.GetValue() * Time.deltaTime,0f,0f));
			playerMoving = true;
			lastMove = new Vector2 (Input.GetAxisRaw ("Horizontal"), 0f);
		}
		if(Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
		{
			transform.Translate(new Vector3(0f,Input.GetAxisRaw("Vertical") * stats.speed.GetValue() * Time.deltaTime,0f));
			playerMoving = true;
			lastMove = new Vector2 (0f, Input.GetAxisRaw ("Vertical"));
		}
		anim.SetFloat ("MoveX", Input.GetAxisRaw ("Horizontal"));
		anim.SetFloat ("MoveY", Input.GetAxisRaw ("Vertical"));
		anim.SetBool ("PlayerMoving", playerMoving);
		anim.SetFloat ("LastMoveX", lastMove.x);
		anim.SetFloat ("LastMoveY", lastMove.y);
	}
}
