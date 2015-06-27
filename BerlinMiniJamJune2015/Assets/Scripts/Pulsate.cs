using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pulsate : MonoBehaviour {
	
	private float timer;


	public int maxFontSize;
	public int minFontSize;

	private int beginFontsize;

	private Text thisText;

	private bool makeBigger;


	// Use this for initialization
	void Start () {
	
		thisText = GetComponent<Text> ();

		InvokeRepeating("PulsateText", 0, .2f);

		beginFontsize = thisText.fontSize;

		maxFontSize = (int)(beginFontsize * 1.1f);
		minFontSize = (int)(beginFontsize * .9f);

	}
	
	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;

		if (thisText.fontSize < maxFontSize && makeBigger) {
			thisText.fontSize += (int)timer;
		}

		if (thisText.fontSize > minFontSize && !makeBigger) {
			thisText.fontSize -= (int)timer;
		}	                      
	
	}

	public void PulsateText(){
		timer = .9f;
		if(makeBigger)
			makeBigger = false;
		else
			makeBigger = true;
	}
}
