using UnityEngine;
using System.Collections;

public class UnitController : MonoBehaviour {

	[SerializeField]
	int health = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		ProcessHealth();
	}


	void ProcessHealth(){
		if(health < 1)
		{
			ProcessDeath();
		}
	}

	void ProcessDeath(){
		// TODO tbd
	}
	
	void OnCollisionEnter(Collision col){
		Debug.Log("test");
	}
}
