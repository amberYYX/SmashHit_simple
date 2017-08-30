using UnityEngine;
using System.Collections;

public class ForceExplosion : MonoBehaviour {

	public GameObject Explosion;
	public GameObject Effector;
	public AudioClip AudioList;
	private bool Stop=false;

	public void OnMouseDown(){
		OnTouchDown();
	}


	void OnTouchDown(){
		if(!Stop){
			Effector.SetActive(false);
			gameObject.GetComponent<Rigidbody>().isKinematic=false;
			Explosion.SetActive(true);
			if(gameObject.GetComponent<Animation>()){gameObject.GetComponent<Animation>().enabled=false;}
			gameObject.GetComponent<AudioSource>().PlayOneShot(AudioList);
			Stop=true;
		}
	}
}
