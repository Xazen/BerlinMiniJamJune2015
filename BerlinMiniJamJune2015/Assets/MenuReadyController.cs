﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuReadyController : MonoBehaviour {

	bool playerA = false;
	bool playerB = false;
	bool playerC = false;
	bool playerD = false;

	[SerializeField]
	GameObject goPlayerA;
	[SerializeField]
	GameObject goPlayerB;
	[SerializeField]
	GameObject goPlayerC;
	[SerializeField]
	GameObject goPlayerD;
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.W) && !playerA){
			goPlayerA.GetComponent<Text>().color = Color.green;
			goPlayerA.GetComponent<Text>().text = "Yeah!";
			playerA = true;	
		}
		if (Input.GetKeyDown(KeyCode.A) && !playerB){
			goPlayerB.GetComponent<Text>().color = Color.green;
			goPlayerB.GetComponent<Text>().text = "Let's go!";
			playerB = true;
		}

		if (Input.GetKeyDown(KeyCode.S) && !playerC){
			goPlayerC.GetComponent<Text>().color = Color.green;
			goPlayerC.GetComponent<Text>().text = "What are you waiting for?";
			playerC = true;
		}

		if (Input.GetKeyDown(KeyCode.D) && !playerD){
			goPlayerD.GetComponent<Text>().color = Color.green;
			goPlayerD.GetComponent<Text>().text = "Let's roll!";
			playerD = true;
		}

		if(playerA && playerB && playerC && playerD)
		{
			Application.LoadLevel("MasterScene");
		}
	}
}
