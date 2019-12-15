using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class move2 : MonoBehaviour
{

	public float rotationPeriod = 0.3f;     // Time taken to move next to
    public float sideLength = 1f;           // The side length of cube
	public float moveSpeed = 5f;
    bool isRotate = false;                  // The cube is rotating or not
    float directionX = 0;                   // Rotation direction flag
    float directionZ = 0;                   // Rotation direction flag

	Rigidbody rb;
    Vector3 startPos;                       // Position of cube before rotation
    float rotationTime = 0;                 // Time lapse during rotation
	float radius;                           // Orbital radius of center of gravity
	Quaternion fromRotation;                // Quaternion of Cube before rotation
	Quaternion toRotation;                  // Quaternion of Cube after rotation
    // Use this for initialization
    void Start()
    {

		// Calculate rotational orbit radius of center of gravity
        radius = sideLength * Mathf.Sqrt(2f) / 2f;
    }

    // Update is called once per frame
    void Update()
    {

        float x = 0;
        float y = 0;
	    
		// Pick up the key input.
		//x = Input.GetAxisRaw("Horizontal");
		x = CrossPlatformInputManager.GetAxis("Horizontal")*moveSpeed*Time.deltaTime;
        if (x == 0)
        {
            //y = Input.GetAxisRaw("Vertical");
			y = CrossPlatformInputManager.GetAxis("Vertical")*moveSpeed*Time.deltaTime;
        }


		// If there is a key input and the Cube is not rotating, rotate the Cube.
        if ((x != 0 || y != 0) && !isRotate)
        {
			directionX = -y;                                                             // Rotation direction set (either x or y must be 0)
			directionZ = -x;                                                             // Rotation direction set (either x or y must be 0)
			startPos = transform.position;                                              // Maintain coordinates before rotation
			fromRotation = transform.rotation;                                          // Keep quaternion before rotation
			transform.Rotate(directionZ * 90, 0, directionX * 90, Space.World);     // Rotate 90 degrees in the direction of rotation
			toRotation = transform.rotation;                                            // Retain quaternion after rotation
			transform.rotation = fromRotation;                                          // Return Cube Rotation before rotation. (Is not it a shallow copy of transform or ...?)
			rotationTime = 0;                                                           // Set the elapsed time during rotation to 0.
			isRotate = true;                                                            // Set a rotating flag.
        }


    }
    void FixedUpdate()
    {

        if (isRotate)
        {

			rotationTime += Time.fixedDeltaTime;                                    // Increase elapsed time
			float ratio = Mathf.Lerp(0, 1, rotationTime / rotationPeriod);          // Percentage of current elapsed time relative to time of rotation

            // move
			float thetaRad = Mathf.Lerp(0, Mathf.PI / 2f, ratio);                   // Rotation angle in radians.
			float distanceX = -directionX * radius * (Mathf.Cos(45f * Mathf.Deg2Rad) - Mathf.Cos(45f * Mathf.Deg2Rad + thetaRad));      // Distance traveled on X axis. The sign of - is for aligning the direction of movement with the key。
			float distanceY = radius * (Mathf.Sin(45f * Mathf.Deg2Rad + thetaRad) - Mathf.Sin(45f * Mathf.Deg2Rad));                        // Y axis movement distance
			float distanceZ = directionZ * radius * (Mathf.Cos(45f * Mathf.Deg2Rad) - Mathf.Cos(45f * Mathf.Deg2Rad + thetaRad));           // Z axis travel distance
			transform.position = new Vector3(startPos.x + distanceX, startPos.y + distanceY, startPos.z + distanceZ);                       // Set the current position

            // rotation
			transform.rotation = Quaternion.Lerp(fromRotation, toRotation, ratio);      // Set current rotation angle in Quaternion.Lerp (what a useful function)

			// Initialize each parameter at the end of movement / rotation. Lower the isRotate flag.
            if (ratio == 1)
            {
                isRotate = false;
                directionX = 0;
                directionZ = 0;
                rotationTime = 0;
            }
        }
    }
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Wall") {
			this.GetComponent<Rigidbody>().freezeRotation = true;
		}
	}
}