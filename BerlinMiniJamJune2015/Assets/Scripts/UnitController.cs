using UnityEngine;
using System.Collections;

public class UnitController : MonoBehaviour {

	[SerializeField]
	int health = 0;

	[SerializeField]
	GameObject bomb;

	[SerializeField]
	GameObject spawnPoint;

	bool isDead = false;


	void Start()
	{
		transform.position = spawnPoint.transform.position;
	}

	void Update () {
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
		Debug.Log("Player dead");
	}

	void ProcessHit()
	{
		GameObject.Find("BigBang").GetComponent<ParticleSystem>().Play();
		// TODO tbd sounds

		health --;

		Debug.Log("Unit Hit");
	}

	void ProcessDropBombTrapBooooya()
	{
		Instantiate(bomb, new Vector3(transform.position.x, transform.position.y * 4, transform.position.z) , Quaternion.identity); 
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Bomb")
		{
			ProcessHit();
			Destroy(col.gameObject);
		}

	}
}
