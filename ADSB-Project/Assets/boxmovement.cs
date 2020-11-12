using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxmovement : MonoBehaviour
{

	public float jumpHeight = 1000.0f;
	public float playerspeed = 10.0f;
	public Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(playerspeed*Input.GetAxis("Horizontal")*Time.deltaTime, Input.GetAxis("Jump"), playerspeed*Input.GetAxis("Vertical")*Time.deltaTime);
		if (move != Vector3.zero)
        {
            transform.position = transform.position + move;
			
        }
    }

		 
}
