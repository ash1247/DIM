using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateInitial : MonoBehaviour {
	public AudioSource gate;
	Vector3 tempPos;
	public  Material[] material;
	Renderer rend;
	float moveSpeed = 45f;
	// Use this for initialization
	void Start () {
		gate.Play ();
        tempPos = transform.position;//*moveSpeed*Time.deltaTime;
		tempPos.y -= 8f;
        transform.position = tempPos;
	}
	//Color color = new Color (1f, 0.4549f, 0f, 1f);


	/*private void IsTriggerEnter(Collider other)
	{

		if (other.name == "Player") {
			tempPos = transform.position;
			tempPos.y += 8f;
			transform.position = tempPos;
		} else {
			other.isTrigger = false;
		}
	}*/
}
