using UnityEngine;
using System.Collections;

public class NonGravity : MonoBehaviour {

	public bool ForceAdd=false;
	public Vector3 ForceVel;
	public Vector3 ForceRot;

	public AudioClip Sound;
	public Vector3 ForceVelDoing;
	public Vector3 ForceRotDoing;
	private bool OneDoing = false;


	void Start () {
		if(ForceAdd){
			gameObject.GetComponent<Rigidbody>().isKinematic = false;
			gameObject.GetComponent<Rigidbody>().velocity = ForceVel;
			gameObject.GetComponent<Rigidbody>().angularVelocity = ForceRot;
			ForceAdd=false;
		}
	}


	public void OnTouchDown(){
		Doing();
	}

	public void OnMouseDown(){
		Doing();
	}

	void Doing(){
		if(!OneDoing){
			OneDoing=true;
			gameObject.GetComponent<Rigidbody>().isKinematic = false;
			gameObject.GetComponent<Rigidbody>().velocity =
			gameObject.GetComponent<Rigidbody>().velocity + ForceVelDoing;
			gameObject.GetComponent<Rigidbody>().angularVelocity = 
			gameObject.GetComponent<Rigidbody>().angularVelocity + ForceRotDoing;
			if(Sound){gameObject.GetComponent<AudioSource>().PlayOneShot(Sound);}
		}
	}
}
