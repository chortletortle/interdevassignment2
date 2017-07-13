using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControl : MonoBehaviour {

	CharacterController cc;

	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		//float horizontal = Input.GetAxis ("Horizontal"); // A+D on keyboard
		float vertical = Input.GetAxis ("Vertical");// W+S on keyboard
		transform.Translate(new Vector3(0f, 0f, vertical) * .5f /*+ Physics.gravity *0.01f this causes collision issues*/);
		if (Input.GetKey(KeyCode.A)){
			cc.transform.Rotate(0f, -1f, 0f); //rotate left on the Y axis
		}
		if (Input.GetKey(KeyCode.D)){
			cc.transform.Rotate(0f, 1f, 0f); //rotate left on the Y axis
		}

	
		//apply our input to our character controller
		//cc.Move( new Vector3(0f, 0f, vertical) * .5f + Physics.gravity *0.01f);
	}
}
