using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charger : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, 90*Time.deltaTime, 0);
	}

    /*private void OnTriggerEnter(Collider other)
	{
        if (other.name == "Player") 
		{
            Destroy (gameObject,5);
		}
	}*/
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
