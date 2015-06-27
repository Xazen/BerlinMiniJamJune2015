using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

	[SerializeField]
	public float rotateSpeed = 100.0f;

	private PickupSpawner pickupSpawner;

	// Use this for initialization
	void Start () 
	{
		pickupSpawner = (PickupSpawner) GameObject.FindGameObjectWithTag ("PickupSpawner").GetComponent<PickupSpawner>();
		gameObject.transform.FindChild ("Sprite").GetComponent<SpriteRenderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		gameObject.transform.Rotate (0, rotateSpeed * Time.deltaTime, 0);
	}

	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == "Wall") 
		{
			pickupSpawner.SpawnItem();
			StartCoroutine(DestroyPickup());
		} 
		else if (collision.gameObject.tag == "Ground")
		{
			gameObject.transform.FindChild ("Sprite").GetComponent<SpriteRenderer>().enabled = true;
		}
	}

	IEnumerator DestroyPickup()
	{
		yield return new WaitForSeconds (0.1f);
		Destroy (gameObject);
	}
}
