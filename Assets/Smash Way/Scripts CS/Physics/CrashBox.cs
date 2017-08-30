using UnityEngine;
using System.Collections;

public class CrashBox : MonoBehaviour {



	public bool ExplosionNoCollider=false;
	public bool NoRotationRandom=false;

	public GameObject Effect_to;
	public GameObject Effect_after;
	public GameObject PrefabShards;
	public AudioClip[] AudioSound;
	public AudioClip[] AudioSoundNoGravity;
	private bool LoopNon=true;

	void Start(){
		if(!NoRotationRandom){
			gameObject.transform.Rotate(0,0,Random.Range(0,3)*90);
		}
	}

	void OnCollisionEnter(Collision other){
		if(!ExplosionNoCollider){
			if(other.gameObject.tag=="Badly"){
				DoingAll();
			}
		}
	}


	public void OnMouseDown(){
		if(ExplosionNoCollider){
			DoingAll();
		}
	}


	void DoingAll(){
		if(LoopNon){
			if(Physics.gravity.y>1||Physics.gravity.y<-1){
				gameObject.GetComponent<AudioSource>().PlayOneShot(AudioSound[Random.Range(0,AudioSound.Length)]);
			}
			if(Physics.gravity.y<1&&Physics.gravity.y>-1){
				gameObject.GetComponent<AudioSource>().PlayOneShot(AudioSoundNoGravity[Random.Range(0,AudioSoundNoGravity.Length)]);
			}
			if(gameObject.GetComponent<Animation>()){gameObject.GetComponent<Animation>().Stop();}

			Effect_to.SetActive(false);
			Effect_after.SetActive(true);
			gameObject.GetComponent<Rigidbody>().isKinematic=true;
			gameObject.GetComponent<BoxCollider>().enabled=false;
			gameObject.GetComponent<MeshRenderer>().enabled=false;
			PrefabShards.SetActive(true);
			LoopNon=false;
		}
	}

}
