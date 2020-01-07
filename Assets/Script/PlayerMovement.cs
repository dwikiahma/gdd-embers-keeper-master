using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;

	float horizontalMove=0f;
	public float runSpeed=40f;
	bool Jump =false;
	public float powupTimer=0f;
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
		if(powupTimer>0.0f){
			powupTimer -= Time.deltaTime;
			Debug.Log(powupTimer);
		}

	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.CompareTag("DeadZone")){
			SceneManager.LoadScene("Dead");
		}
		if(col.gameObject.CompareTag("powup")){
			Destroy(col.gameObject);
			powupTimer=10.0f;
		}
		
	}
	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.tag == "Enemy"){
			SceneManager.LoadScene("Dead");
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
