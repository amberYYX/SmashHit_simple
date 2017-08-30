using UnityEngine;
using System.Collections;

public class AnimSettings : MonoBehaviour {


	public bool AnimNew = false;
	public AnimationClip AnimPlay;
	public GameObject ObjParent;
	public AudioClip Sound;

	private bool One = true;

	public void OnMouseDown(){
		Doing();
	}

	void Doing(){
		if(One){
			if(gameObject.GetComponent<Animation>()){gameObject.GetComponent<Animation>().Stop();}
			gameObject.GetComponent<AudioSource>().PlayOneShot(Sound);
			if(AnimNew){
				ObjParent.GetComponent<Animation>().Play(AnimPlay.name);
			}
			One=false;
		}
	}
}
