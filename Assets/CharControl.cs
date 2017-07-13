using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControl : MonoBehaviour {

	CharacterController cc;
	public float speed = .5F;
	public float rotationSpeed = 15.0F;

	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		//float horizontal = Input.GetAxis ("Horizontal"); // A+D on keyboard
		float vertical = Input.GetAxis ("Vertical") * speed;// W+S on keyboard
		float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

		transform.Rotate(0, rotation, 0);
		//cc.transform.Rotate(0, rotation, 0);
		cc.Move(transform.TransformDirection(Vector3.forward*vertical) + Physics.gravity *0.01f);


	
		//apply our input to our character controller
		//cc.Move( new Vector3(0f, 0f, vertical) * .5f + Physics.gravity *0.01f);
	}
}