using UnityEngine;
using System.Collections;

public class UnitMovementController : MonoBehaviour {

	public string RotateLeftKey = "A";
	public string RotateRightKey = "D";
	public float RotateSpeed = 50.0f;

	private KeyCode rotateLeftKeyCode;
	private KeyCode rotateRightKeyCode;

	public delegate void KeyPressed();
	public KeyPressed rotateRight;
	public KeyPressed rotateLeft;

	// Use this for initialization
	void Start () 
	{
		rotateRightKeyCode = (KeyCode) System.Enum.Parse(typeof(KeyCode), RotateRightKey);
		rotateLeftKeyCode = (KeyCode) System.Enum.Parse(typeof(KeyCode), RotateLeftKey);

		rotateRight += RotateRight;
		rotateLeft += RotateLeft;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey(rotateLeftKeyCode) && rotateLeft != null) 
		{
			rotateLeft();
		}

		if (Input.GetKey(rotateRightKeyCode) && rotateRight != null) 
		{
			rotateRight();
		}
	}

	public void RotateLeft()
	{
		gameObject.transform.Rotate (0, -RotateSpeed * Time.deltaTime, 0);
	}

	public void RotateRight()
	{
		gameObject.transform.Rotate (0, RotateSpeed * Time.deltaTime, 0);
	}
}
