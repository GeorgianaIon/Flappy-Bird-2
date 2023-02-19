using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript logic;
    // Start is called before the first frame update
    void Start()
    {
        //as soon as a new pipe spawns, it will look for the logic script and get the component
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
		//check the the collision that just happen was with a game object on the bird's layer
		if(collision.gameObject.layer == 3) {
       logic.addScore(1);	
			}
    }
}
