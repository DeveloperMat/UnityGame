using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{

    private Animator animator;
    public float fuerzaSalto;
    public GameManager gameManager;

    private Rigidbody2D rigidBody2D;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space)){    
            animator.SetBool("estaSaltando",true);
            rigidBody2D.AddForce(new Vector2(0,fuerzaSalto));
        }

    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Suelo"){
            animator.SetBool("estaSaltando",false);
        }
       
        if (collision.gameObject.tag == "Obstaculo")
        {
            gameManager.gameOver = true;
        }
    }
}
