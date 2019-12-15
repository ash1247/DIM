using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
public class move3 : MonoBehaviour {
	public static move3 instance = null;
	public AudioSource gameplay;
	//public AudioSource movement;
	public float moveSpeed = 40f;

	float directionX = 0;                   // Rotation direction flag
	float directionZ = 0;                   // Rotation direction flag


	// Use this for initialization
	void Start()
	{
		if (instance == null) {
			instance = this;
		} else if (instance != null) {
			Destroy(gameObject);
		}
		gameplay.Play ();
		if (SceneManager.GetActiveScene ().buildIndex == 5) 
		{
			CustomPlayerPrefs.LevelUpdate (0);

		}
	}

	// Update is called once per frame
	void Update()
	{
		directionX = CrossPlatformInputManager.GetAxis ("Horizontal") * moveSpeed * Time.deltaTime;
		directionZ = CrossPlatformInputManager.GetAxis ("Vertical") * moveSpeed * Time.deltaTime;

		transform.position = new Vector3 (transform.position.x + directionZ, transform.position.y, transform.position.z + directionX);
	}
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Wall") {
			this.GetComponent<Rigidbody>().freezeRotation = true;
		//	movement.Play ();
		}
	}
	public void LoadNextLevel(int x)
	{
		SceneManager.LoadScene (x);
	}
}
