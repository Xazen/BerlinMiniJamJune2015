using UnityEngine;
using System.Collections;

public class GameOverController : MonoBehaviour {

	[SerializeField]
	float blockInputTime = 2.0f;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		blockInputTime -= Time.deltaTime;

		if (Input.anyKeyDown && blockInputTime <= 0){
			Application.LoadLevel("Menu");
		}
	}
}
