using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour {
	//Rigidbody r;
	//Vector3 initial;
	public GameObject target;
	Rigidbody rb;
	public float damping = 1;
	Vector3 targetDir;
	Vector3 initRelPos;

	void Start() {
		rb = GetComponent<Rigidbody> ();
		initRelPos = transform.position-target.transform.position;
	}

	// Update is called once per frame
	void LateUpdate () {
		//r.AddForce((transform.TransformDirection(Vector3.forward*vertical) + Physics.gravity *0.01f), ForceMode.VelocityChange);
		//transform.rotation
		targetDir = target.transform.position - transform.position;
		Vector3 forward = transform.forward;
		Vector3 localTarget = transform.InverseTransformPoint (target.transform.position);
		float angle = Mathf.Atan2(localTarget.x, localTarget.z) * Mathf.Rad2Deg;
		Vector3 eulerAngleVelocity = new Vector3(0, angle, 0);
		Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime );
		rb.MoveRotation(rb.rotation * deltaRotation);
		//rb.MovePosition (target.transform.position+initRelPos);
	}
}