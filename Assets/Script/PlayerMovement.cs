using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;

	float horizontalMove=0f;
	public float runSpeed=40f;
	bool Jump =false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		horizontalMove= Input.GetAxisRaw("Horizontal")*runSpeed;
		animator.SetFloat("Speed",Mathf.Abs(horizontalMove));
		if(Input.GetButtonDown("Jump")){
			Jump = true;
			animator.SetBool("IsJump",true);
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.CompareTag("DeadZone")){
			Debug.Log("Mampozz");
		}
		
	}
	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.tag == "Enemy"){
			Debug.Log("hit enemy");
		}
	}
	

	void FixedUpdate(){
		controller.Move(horizontalMove*Time.fixedDeltaTime,false,Jump);
		Jump=false;
	}

	public void OnLanding(){
		animator.SetBool("IsJump",false);
	}
}
