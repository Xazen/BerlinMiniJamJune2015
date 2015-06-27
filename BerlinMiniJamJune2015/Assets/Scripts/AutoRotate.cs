using UnityEngine;
using System.Collections;

public class AutoRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround (transform.parent.position, Vector3.up, 50 * Time.deltaTime);
	}
}
