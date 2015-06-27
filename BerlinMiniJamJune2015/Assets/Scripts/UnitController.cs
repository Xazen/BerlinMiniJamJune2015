using UnityEngine;
using System.Collections;

public class UnitController : MonoBehaviour {

	[SerializeField]
	bool redPlayer;

	[SerializeField]
	int health = 0;
	
	[SerializeField]
	float bombCoolDown = 1.0f; 

	[SerializeField]
	GameObject bomb;
	
	[SerializeField]
	GameObject spawnPoint;

	[SerializeField]
	int requiredPickupsToWin = 2;

	float currentBombCoolDown = 0.0f;
	int currentPickups = 0;
	
	bool isDead = false;
	
	void Start()
	{
		transform.position = spawnPoint.transform.position;
	}

	void Update () {

		currentBombCoolDown -= Time.deltaTime;

		ProcessHealth();

		if (Input.GetKeyDown("space")){
			ProcessDropBombTrapBooooya();
		}
	}


	void ProcessHealth(){
		if(health < 0 && !isDead)
		{
			ProcessDeath();
		}
	}

	void ProcessDeath(){
		// TODO tbd
		isDead = true;
		transform.position = spawnPoint.transform.position;
		Debug.Log("Player reborn");
		health = 0;
		isDead = false;
	}

	void ProcessHit()
	{
		GameObject.Find("BigBang").GetComponent<ParticleSystem>().Play();
		// TODO tbd sounds

		health --;

		Debug.Log("Unit Hit");
	}

	public void ProcessDropBombTrapBooooya()
	{
		Debug.Log("processdro");
		if (currentBombCoolDown <= 0) 
		{
			Debug.Log("placing");
			currentBombCoolDown = bombCoolDown;
			Instantiate(bomb, new Vector3(transform.position.x, transform.position.y * 10, transform.position.z) , Quaternion.identity); 
		}
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Bomb")
		{
			ProcessHit();
			col.gameObject.SetActive(false);
		}

		if (col.gameObject.tag == "Pickup") 
		{
			Destroy(col.gameObject);
			currentPickups ++;
			if (currentPickups == requiredPickupsToWin)
			{
				if (redPlayer)
				{
					Application.LoadLevel(3);
				} 
				else 
				{
					Application.LoadLevel(2);
				}
			}
		}
	}
}
