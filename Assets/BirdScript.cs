using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    //a script cannot to the other componenets on the gameobject, you have to make a reference to it
    public Rigidbody2D myRigidbody;
    public float floapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public float deadZoneDown = -20;
    public float deadZoneUp = 20;
    public AudioSource jumpSFX;
    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        jumpSFX = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            //jump
            //up is (0,1) in world space
            myRigidbody.velocity = Vector2.up * floapStrength;
            jumpSFX.PlayOneShot(jumpSFX.clip);
        }
        //game over if the bird hits the groundlala
        if(transform.position.y < deadZoneDown || transform.position.y > deadZoneUp)
        {
            gameOver();
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if the bird hits the pipe
        gameOver();
    }

    private void gameOver()
    {
        if(isGameOver) return;
        isGameOver = true;
        
        logic.gameOver();
        birdIsAlive = false;
    }
}
