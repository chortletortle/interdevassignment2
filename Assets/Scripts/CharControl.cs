using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharControl : MonoBehaviour {
	public AudioSource fx;
	public AudioSource fx2;
	public AudioSource fx3;
	public AudioSource fx4;
	public AudioSource fx5;
	public AudioSource fx6;
	public AudioSource fx7;
	public AudioSource fx8;
	CharacterController cc;
	public float speed = 1F;
	public float rotationSpeed = 15.0F;
	public Text screenMessage;
	public Text title;
	bool startText = true;
	public GameObject fridge;
	public GameObject oven;
	public GameObject cup;
	public GameObject bed;
	public GameObject vent;

	int textCount=0;
	bool control = true;

	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (startText == true && (Input.GetAxis ("Vertical") != 0 || Input.GetAxis ("Horizontal") != 0)) {
			screenMessage.text = "WAIT!!! \n FOOD!!!! \n KITCHEN!!!";
			textCount++;
			title.text = "";
			startText = false;
			fx3.PlayOneShot (fx3.clip);
			fx4.PlayOneShot (fx4.clip);
		}

		if (Vector3.Distance (transform.position, fridge.transform.position) < 10f && textCount == 1) { 
			screenMessage.fontSize = 25;
			screenMessage.text = "fate reminds you \nthat cats don't have fingers.\n you feel hot \n but without your bikini on! \n why?";
			textCount++;
			fx2.PlayOneShot (fx2.clip);
		} 

		if ( Vector3.Distance(transform.position, oven.transform.position) < 8.5f && textCount == 2) { 
			screenMessage.fontSize = 20;
			screenMessage.text = "this must be Steve Buscemi \n because its \n TOO HOT! \n something behind you \n fills you with warmth";
			textCount++;
			fx5.PlayOneShot (fx5.clip);
		}

		if ( Vector3.Distance(transform.position, cup.transform.position) < 2f && textCount == 3) { 
			screenMessage.fontSize = 20;
			screenMessage.text = "the food guy \n wrote you \n a kind letter \n and a fat check \n go sit on his face";
			textCount++;
			fx6.PlayOneShot (fx6.clip);
		}

		if ( Vector3.Distance(transform.position, bed.transform.position) < 9f && textCount == 4) { 
			screenMessage.fontSize = 25;
			screenMessage.text = "HEY! \n wtf!!! \n food guy aint here \n you hear a woosh noise \n and instinctively yawn";
			textCount++;
			fx.PlayOneShot (fx.clip);
			fx8.PlayOneShot (fx8.clip);
		} 

		if ( Vector3.Distance(transform.position, vent.transform.position) < 4f && textCount == 5) { 
			textCount++;
			screenMessage.fontSize = 25;
			screenMessage.text = "the wafting temperature \n hits the spot \n on your fuzzy balls \n\n hit space to snooze";
			fx4.PlayOneShot (fx3.clip);
		}

		if ( Input.GetKeyDown(KeyCode.Space)  && textCount == 6) { 
			screenMessage.fontSize = 60;
			screenMessage.text = "z   \n z  \n  z \n   z";
			title.text = "you win";
			//trigger fade screen + credits?
			// or just add credits to the side lmao
			control = false;
			fx.Stop ();
			fx7.PlayOneShot (fx7.clip);
		}

		if (control) {
			//float horizontal = Input.GetAxis ("Horizontal"); // A+D on keyboard
			float vertical = Input.GetAxis ("Vertical") * speed;// W+S on keyboard
			float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

			transform.Rotate(0, rotation, 0);
			//cc.transform.Rotate(0, rotation, 0);
			cc.Move(transform.TransformDirection(Vector3.forward*vertical));
			//apply our input to our character controller
			//cc.Move( new Vector3(0f, 0f, vertical) * .5f + Physics.gravity *0.01f);
		}
	}
}