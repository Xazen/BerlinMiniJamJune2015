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
	private GameObject particleBang;

	[SerializeField]
	int requiredPickupsToWin = 2;

	float currentBombCoolDown = 0.0f;
	int currentPickups = 0;
	
	bool isDead = false;
	
	void Start()
	{
		transform.position = spawnPoint.transform.position;
		if (!redPlayer) 
		{
			gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);
		}
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

		health = 0;
		isDead = false;
	}

	void ProcessHit()
	{
		Instantiate(particleBang, new Vector3(transform.position.x, transform.position.y, transform.position.z) , Quaternion.identity); 
//		particleBang.GetComponent<ParticleSystem>().Play();
		health --;
	}

	public void ProcessDropBombTrapBooooya()
	{
		if (currentBombCoolDown <= 0) 
		{
			currentBombCoolDown = bombCoolDown;
			Instantiate(bomb, new Vector3(transform.position.x, transform.position.y * 10, transform.position.z) , Quaternion.identity); 
			SoundManager.instance.PlayBombDrop();
		}
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Bomb")
		{
			ProcessHit();
			col.gameObject.SetActive(false);
			SoundManager.instance.PlayBombExplosion();
		}

		if (col.gameObject.tag == "Pickup") 
		{
			SoundManager.instance.PlayTreasurePickupWin();
			Destroy(col.gameObject);
			currentPickups ++;
			if (currentPickups == requiredPickupsToWin)
			{
				SoundManager.instance.PlayWinSound();
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
