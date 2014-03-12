using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour 
{
	public float speed = 60.0F;
    
	public float jumpSpeed = 8.0F;
    
	public float gravity = 20.0F;
    
	private Vector3 moveDirection = Vector3.zero;
	
	CharacterController controller;
	
	void Start()
	{
		controller = GetComponent<CharacterController>();
	}
	
    void Update() 
	{
        if (controller.isGrounded) 
		{
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        
			moveDirection = transform.TransformDirection(moveDirection);
            
			moveDirection *= speed;
            
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
                moveDirection.y = jumpSpeed;
				
				Debug.Log("jumped player 2");
			}
        }
		
        moveDirection.y -= gravity * Time.deltaTime;
        
		controller.Move(moveDirection * Time.deltaTime);
		
		Debug.Log("player 2 -->" + Time.deltaTime);
    }
}
