using UnityEngine;
using System.Collections;

public class Crash : MonoBehaviour {

	public GameObject Add;
	public GameObject Effect_to;
	public GameObject Effect_after;
	public GameObject PrefabShards;
	public AudioClip[] AudioSound;
	public AudioClip[] AudioSoundNoGravity;
	private bool LoopNon=true;
	public bool LessonsBool=false;
	public GameObject LessonsGO;

	void Start(){
		gameObject.transform.Rotate(0,0,Random.Range(0,3)*90);
	}

	public void OnMouseDown(){
		Doing();
	}

	void Doing(){
		if(LoopNon){
			if(Physics.gravity.y>1||Physics.gravity.y<-1){
				gameObject.GetComponent<AudioSource>().PlayOneShot(AudioSound[Random.Range(0,AudioSound.Length)]);
			}
			if(Physics.gravity.y<1&&Physics.gravity.y>-1){
				gameObject.GetComponent<AudioSource>().PlayOneShot(AudioSoundNoGravity[Random.Range(0,AudioSoundNoGravity.Length)]);
			}
			Add.SetActive(true);
			Effect_to.SetActive(false);
			Effect_after.SetActive(true);
			gameObject.GetComponent<Rigidbody>().isKinematic=true;
			gameObject.GetComponent<BoxCollider>().enabled=false;
			gameObject.GetComponent<MeshRenderer>().enabled=false;
			GameObject NewShards = Instantiate(PrefabShards);
			NewShards.transform.position = gameObject.transform.position;
			NewShards.transform.rotation = Quaternion.identity;
			NewShards.transform.SetParent (gameObject.transform);
			LoopNon=false;
			if(LessonsBool){LessonsGO.GetComponent<Lessons>().Message++;}
		}
	}

}
