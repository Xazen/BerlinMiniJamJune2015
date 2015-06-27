using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour 
{
	//Here is a private reference only this class can access
	private static SoundManager _instance;


	[SerializeField]
	private AudioClip bombDrop;

	[SerializeField]
	private AudioClip bombExplosion;

	[SerializeField]
	private AudioClip treasurePickupWin;

	[SerializeField]
	private AudioClip winSound;


	private AudioSource audioSource;

	//This is the public reference that other classes will use
	public static SoundManager instance
	{
		get
		{
			//If _instance hasn't been set yet, we grab it from the scene!
			//This will only happen the first time this reference is used.
			if(_instance == null){
				_instance = GameObject.FindObjectOfType<SoundManager>();
			}
			return _instance;
		}
	}

	void Start()
	{
		audioSource = gameObject.AddComponent<AudioSource>();
	}

	public void PlayBombDrop()
	{
		audioSource.PlayOneShot(bombDrop);
	}

	public void PlayBombExplosion()
	{
		audioSource.PlayOneShot(bombExplosion);
	}
	public void PlayTreasurePickupWin()
	{
		audioSource.PlayOneShot(treasurePickupWin);
	}
	public void PlayWinSound()
	{
		audioSource.PlayOneShot(winSound);
	}

}