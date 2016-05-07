using UnityEngine;
using System.Collections;

public class soundController : MonoBehaviour {

	public AudioClip myClip;
	public AudioSource musicPlayer;

	// Use this for initialization
	void Start () {
		musicPlayer.clip = myClip;
		musicPlayer.Play ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
