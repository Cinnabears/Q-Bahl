using UnityEngine;
using System.Collections;

public class wakeHand : MonoBehaviour {


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			GameObject.Find ("MainBadDood").gameObject.GetComponent<MasterHandScript> ().setIdleState ();
			Debug.Log("hereeeee");
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
