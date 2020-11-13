using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bodymove : MonoBehaviour
{

	public float jumpHeight = 10.0f;
	public float playerspeed = 10.0f;
	public Rigidbody body;
	//public float custom_gravity = 12.0f;
	
	private bool grounded = true;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
		//Physics.gravity.x = custom_gravity;
		//body.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    // Update is called once per frame
    void Update()
    {
		//body.addForce(new Vector3(0,-15,0));
        Vector3 move = new Vector3(playerspeed*Input.GetAxis("Horizontal")*Time.deltaTime, Input.GetAxis("Jump"), playerspeed*Input.GetAxis("Vertical")*Time.deltaTime);
		if (move != Vector3.zero)
        {
			var camera = Camera.main;
			
			var forward = camera.transform.forward;
			var right = camera.transform.right;
	 
			forward.y = 0f;
			right.y = 0f;
			forward.Normalize();
			right.Normalize();
	 
			var desiredMoveDirection = forward * Input.GetAxis("Vertical") + right * Input.GetAxis("Horizontal");
			desiredMoveDirection = desiredMoveDirection * playerspeed;
			
			var jump_key = Input.GetAxis("Jump");
			if (grounded && jump_key != 0)
			{
				
				// desiredMoveDirection = desiredMoveDirection + new Vector3(0, jump * jumpHeight,0);
				//Vector3 jump = new Vector3(0,(transform.up * jumpHeight) / Time.fixedDeltaTime,0);
				//body.AddForce(jump);
				body.velocity += new Vector3(0,10,0);
				grounded = false;
			}
			
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
