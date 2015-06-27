using UnityEngine;
using System.Collections;

public class UnitMovementController : MonoBehaviour {

	public string RotateLeftKey = "A";
	public string RotateRightKey = "D";
	public float RotateSpeed = 50.0f;
	public float ForwardSpeed = 2.0f;

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
		MoveForward ();

		// Rotate left
		if (Input.GetKey(rotateLeftKeyCode) && rotateLeft != null) 
		{
			rotateLeft();
		}

		// Rotate right
		if (Input.GetKey(rotateRightKeyCode) && rotateRight != null) 
		{
			rotateRight();
		}
	}

	/// <summary>
	/// Moves forward.
	/// </summary>
	public void MoveForward()
	{
		gameObject.transform.Translate (Vector3.forward * Time.deltaTime * ForwardSpeed);
	}

	/// <summary>
	/// Rotates the left.
	/// </summary>
	public void RotateLeft()
	{
		gameObject.transform.Rotate (0, -RotateSpeed * Time.deltaTime, 0);
	}

	/// <summary>
	/// Rotates the right.
	/// </summary>
	public void RotateRight()
	{
		gameObject.transform.Rotate (0, RotateSpeed * Time.deltaTime, 0);
	}
}
