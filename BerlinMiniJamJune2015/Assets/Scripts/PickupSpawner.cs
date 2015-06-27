using UnityEngine;
using System.Collections;

public class PickupSpawner : MonoBehaviour {

	[SerializeField]
	private int numberOfPickups = 3;
	[SerializeField]
	private int spawnOffset = 3;

	private GameObject ground;
	[SerializeField]
	GameObject pickup;


	// Use this for initialization
	void Start () 
	{
		ground = GameObject.FindGameObjectWithTag ("Ground");
		SpawnItems ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	private void SpawnItems()
	{
		for (int i = 0; i < numberOfPickups; i++) 
		{
			SpawnItem();
		}
	}

	public void SpawnItem()
	{
		Vector3 groundSize = ground.GetComponent<Collider>().bounds.size;

		float x = Random.Range(-Mathf.Abs(groundSize.x/2-spawnOffset), Mathf.Abs(groundSize.x/2-spawnOffset));
		float z = Random.Range(-Mathf.Abs(groundSize.z/2-spawnOffset), Mathf.Abs(groundSize.x/2-spawnOffset));
		Instantiate(pickup, new Vector3(transform.position.x+x, transform.position.y + 2.5f, transform.position.z+z) , Quaternion.identity);
	}
}
