using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed=3;
    public bool moveRight=false;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(moveRight){
            transform.Translate(2*Time.deltaTime*speed,0,0);
            transform.localScale= new Vector2(2,2);
        }else{
            transform.Translate(-2*Time.deltaTime*speed,0,0);
            transform.localScale= new Vector2(-2,2);
        }
        animator.SetFloat("Speed",speed);
    }
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.CompareTag("Turnback")){
            if(moveRight){
                moveRight=false;
            }else{
                moveRight=true;
            }
        }
    }
}
