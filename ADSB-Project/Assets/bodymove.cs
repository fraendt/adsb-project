using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bodymove : MonoBehaviour
{

	public float jumpHeight = 0.00000000010f;
	public float playerspeed = 10.0f;
	public Rigidbody body;
	
	private bool grounded = true;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(playerspeed*Input.GetAxis("Horizontal")*Time.deltaTime, Input.GetAxis("Jump"), playerspeed*Input.GetAxis("Vertical")*Time.deltaTime);
		if (move != Vector3.zero)
        {
            //transform.position = transform.position + move;
			//transform.Translate(move, Space.World);
			
			//camera forward and right vectors:
			var camera = Camera.main;
			
			var forward = camera.transform.forward;
			var right = camera.transform.right;
	 
			//project forward and right vectors on the horizontal plane (y = 0)
			forward.y = 0f;
			right.y = 0f;
			forward.Normalize();
			right.Normalize();
	 
			//this is the direction in the world space we want to move:
			var desiredMoveDirection = forward * Input.GetAxis("Vertical") + right * Input.GetAxis("Horizontal");
			desiredMoveDirection = desiredMoveDirection * playerspeed;
			
			var jump = Input.GetAxis("Jump");
			if (grounded && jump != 0)
			{
				
				desiredMoveDirection = desiredMoveDirection + new Vector3(0, jump * jumpHeight,0);
				Debug.Log(Input.GetAxis("Jump") * jumpHeight);
				grounded = false;
			}
			
			//now we can apply the movement:
			transform.Translate(desiredMoveDirection * Time.deltaTime);
			//transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(move), 0.15F);
			
        }
		
    }
	
	void OnCollisionEnter(Collision collision)
	{
		Debug.Log("Entered");
		if (collision.gameObject.CompareTag("Ground"))
		{
			grounded = true;
		}
	}

		 
}
