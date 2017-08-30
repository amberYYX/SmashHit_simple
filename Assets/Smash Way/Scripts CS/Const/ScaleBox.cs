using UnityEngine;
using System.Collections;

public class ScaleBox : MonoBehaviour {

	public ParticleSystem Glow;
	public Vector3 ScaleEnd;
	public float speedScale;
	public float speedParticle;
	private int Do=0;
	public Vector3 AddForce;
	public Vector3 AddRotation;
	public AudioClip Sound;

	private bool One=true;

	public void OnMouseDown(){
		Doing();
	}


	void Doing(){
		if(One){
			Do=1;
			if(gameObject.GetComponent<Animation>()){gameObject.GetComponent<Animation>().Stop();}
			gameObject.GetComponent<Rigidbody>().isKinematic=false;
			gameObject.GetComponent<Rigidbody>().velocity = AddForce;
			gameObject.GetComponent<Rigidbody>().angularVelocity = AddRotation;
			gameObject.GetComponent<AudioSource>().PlayOneShot(Sound);
			One=false;
		}
	}

	void FixedUpdate(){
		if(Do==1){
			if(gameObject.transform.localScale.x>ScaleEnd.x){
				gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x-speedScale,gameObject.transform.localScale.y,gameObject.transform.localScale.z);
			}
			if(gameObject.transform.localScale.y>ScaleEnd.y){
				gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x,gameObject.transform.localScale.y-speedScale,gameObject.transform.localScale.z);
			}
			if(gameObject.transform.localScale.z>ScaleEnd.z){
				gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x,gameObject.transform.localScale.y,gameObject.transform.localScale.z-speedScale);
			}
			if(Glow.GetComponent<ParticleSystem>().startSpeed>0){
				Glow.GetComponent<ParticleSystem>().startSpeed=Glow.GetComponent<ParticleSystem>().startSpeed-speedParticle;
			}
			if(Glow.GetComponent<ParticleSystem>().startSize>0){
				Glow.GetComponent<ParticleSystem>().startSize=Glow.GetComponent<ParticleSystem>().startSize-speedParticle;
			}
		}
	}

}
