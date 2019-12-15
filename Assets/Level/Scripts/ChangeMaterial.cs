using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour {
	public AudioSource power;
	public AudioSource power2;
	public  Material[] material;
	Renderer rend;
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		rend.enabled = true;
		rend.sharedMaterial = material [0];
	}

	private void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Box") {
			power.Play ();
			rend.sharedMaterial = material [1];
           
		}else if(col.gameObject.tag == "Box 2") {
			power2.Play ();
			rend.sharedMaterial = material [2];

         
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
