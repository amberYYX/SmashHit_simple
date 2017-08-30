using UnityEngine;
using System.Collections;

public class Force : MonoBehaviour {




	public bool BlocCollision = false;
	public GameObject ConParent;

	public bool ForceAdd = false;
	public Vector3 ForceVel;
	public Vector3 ForceRot;

	public bool ExplosionAdd = false;
	public GameObject Explosion;
	public bool FxAdd=false;
	public GameObject Fx;


	public bool RotationAdd=false;
	public Vector3 RotationSpeed;

	public AudioClip[] AudioList;
	public int OncePlay;

	public bool TakeAdd=false;
	public Vector3 TakeVel;
	public Vector3 TakeRot;
	public float TakeEndPosition;
	public GameObject Cam;

	private bool end = false;

	void Start(){
		if(FxAdd){Fx.SetActive(true);}
	}


	void OnCollisionEnter(Collision other){
		if(BlocCollision){
			if(other.gameObject.tag=="Badly"){
				DoingAll();
			}
		}
	}

	public void OnMouseDown(){
		if(!BlocCollision){
			DoingAll();
		}
	}

	void DoingAll(){
		gameObject.GetComponent<AudioSource>().volume=0.3f;
		if(gameObject.GetComponent<Animation>()){gameObject.GetComponent<Animation>().Stop();}
		if(ConParent.GetComponent<Animation>()){ConParent.GetComponent<Animation>().Stop();}
		gameObject.GetComponent<Rigidbody>().isKinematic = false;
		RotationAdd=false;
		if(TakeAdd){
			gameObject.GetComponent<Rigidbody>().velocity = 
				gameObject.GetComponent<Rigidbody>().velocity + TakeVel;
			gameObject.GetComponent<AudioSource>().PlayOneShot(AudioList[OncePlay]);
		}
		if(ForceAdd){
			gameObject.GetComponent<Rigidbody>().velocity = ForceVel;
			gameObject.GetComponent<Rigidbody>().angularVelocity = ForceRot;
			ForceAdd=false;
			gameObject.GetComponent<AudioSource>().PlayOneShot(AudioList[OncePlay]);
		}
		if(ExplosionAdd){
			Explosion.SetActive(true);
			if(FxAdd){Fx.SetActive(false);}
			ExplosionAdd=false;
			OncePlay=0;
			gameObject.GetComponent<AudioSource>().PlayOneShot(AudioList[OncePlay]);
		}
	}


	void Update(){
		if(RotationAdd){gameObject.transform.Rotate(RotationSpeed);}
		if(TakeAdd){
			if(!end){
				if(Cam.transform.position.z>TakeEndPosition){end=true;TakeAdd=false;
					gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
					gameObject.GetComponent<Rigidbody>().angularVelocity = TakeRot;
					if(FxAdd){Fx.SetActive(false);Explosion.SetActive(true);
						gameObject.GetComponent<AudioSource>().PlayOneShot(AudioList[2]);}}
			}
		}
	}
}
