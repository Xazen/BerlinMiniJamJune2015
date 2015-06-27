using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Menu ready controller. 
/// Pathetic code from Viktor.
/// </summary>
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

		if (Input.GetKeyDown(KeyCode.D) && !playerA){
			goPlayerA.GetComponent<Text>().color = Color.green;
			goPlayerA.GetComponent<Text>().text = "Yeah!";
			goPlayerA.GetComponent<Text>().transform.Rotate(new Vector3(0,0,180));
			playerA = true;	
		}
		if (Input.GetKeyDown(KeyCode.A) && !playerB){
			goPlayerB.GetComponent<Text>().color = Color.green;
			goPlayerB.GetComponent<Text>().text = "Let's go!";
			goPlayerB.GetComponent<Text>().transform.Rotate(new Vector3(0,0,180));
			playerB = true;
		}

		if (Input.GetKeyDown(KeyCode.W) && !playerC){
			goPlayerC.GetComponent<Text>().color = Color.green;
			goPlayerC.GetComponent<Text>().text = "What are you waiting for?";
			goPlayerC.GetComponent<Text>().transform.Rotate(new Vector3(0,0,180));
			playerC = true;
		}

		if (Input.GetKeyDown(KeyCode.S) && !playerD){
			goPlayerD.GetComponent<Text>().color = Color.green;
			goPlayerD.GetComponent<Text>().text = "Let's roll!";
			goPlayerD.GetComponent<Text>().transform.Rotate(new Vector3(0,0,180));
			playerD = true;
		}

		if(playerA && playerB && playerC && playerD)
		{
			Application.LoadLevel("MasterScene");
		}
	}
}
