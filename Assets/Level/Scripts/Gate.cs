using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour {
	public AudioSource gate;
	Vector3 tempPos;
	public  Material[] material;
	Renderer rend;
		// Use this for initialization
	/*void Start () {
		rend = GetComponent<Renderer> ();
		rend.enabled = true;
		rend.sharedMaterial = material [0];
	}*/
	//Color color = new Color (1f, 0.4549f, 0f, 1f);
    private void OnCollisionEnter(Collision col)
	{
		if (col.rigidbody.GetComponent<Renderer>().material.color == this.GetComponent<Renderer>().material.color) {
			gate.Play ();
			tempPos = transform.position;
			tempPos.y += 8f;
			transform.position = tempPos;
		}
	}


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
