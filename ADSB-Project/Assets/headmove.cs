using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headmove : MonoBehaviour
{
	public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
	
	public Transform player; 
	private Vector3 offset = new Vector3(0,2,0);
	
	public float sensitivity = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X") * sensitivity;
        pitch -= speedV * Input.GetAxis("Mouse Y") * sensitivity;

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
		
		transform.position = player.position + offset;
    }
}
