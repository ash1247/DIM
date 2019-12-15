using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAwayText : MonoBehaviour {
    float duration = 8f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > duration)
        {
            Destroy(gameObject);
        }
	}
}
