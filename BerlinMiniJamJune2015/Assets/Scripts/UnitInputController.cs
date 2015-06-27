using UnityEngine;
using System.Collections;

public class UnitInputController : MonoBehaviour {

	public string RotateLeftKey = "A";
	public string RotateRightKey = "D";
	public float RotateSpeed = 50.0f;
	public float ForwardSpeed = 2.0f;

	private UnitController unitController;

	private KeyCode rotateLeftKeyCode;
	private KeyCode rotateRightKeyCode;

	public delegate void KeyPressed();
	public KeyPressed rotateRight;
	public KeyPressed rotateLeft;
	public KeyPressed placeBomb;

	// Use this for initialization
	void Start () 
	{
		unitController = GetComponent<UnitController> ();

		rotateRightKeyCode = (KeyCode) System.Enum.Parse(typeof(KeyCode), RotateRightKey);
		rotateLeftKeyCode = (KeyCode) System.Enum.Parse(typeof(KeyCode), RotateLeftKey);

		rotateRight += RotateRight;
		rotateLeft += RotateLeft;

		placeBomb += PlaceBomb;
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

		if (Input.GetKey (rotateLeftKeyCode) && Input.GetKey (rotateRightKeyCode) && placeBomb != null) 
		{
			PlaceBomb();
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

	public void PlaceBomb()
	{
		Debug.Log("placebomg");
		unitController.ProcessDropBombTrapBooooya ();
	}
}
