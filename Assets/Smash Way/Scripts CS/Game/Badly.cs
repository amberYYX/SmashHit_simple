using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Badly : MonoBehaviour {



	public GameObject RedFonGO;
	public AudioClip SoundBadly;

	public int BadlyNaw = 0;

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag=="Badly"){
			if(BadlyNaw==0){
				GetComponent<AudioSource>().PlayOneShot(SoundBadly);
				GetComponent<SystemKilling>().BadlySet();
				RedFonGO.GetComponent<Image> ().color = new Color (RedFonGO.GetComponent<Image> ().color.r,RedFonGO.GetComponent<Image> ().color.g,RedFonGO.GetComponent<Image> ().color.b,1);
				StartCoroutine ("Shaking");
				RedFonGO.SetActive(true);
				BadlyNaw=1;
			}
		}
	}

	void FixedUpdate(){
		if(BadlyNaw == 1){
			if(RedFonGO.GetComponent<Image>().color.a>0){
				RedFonGO.GetComponent<Image>().color = new Color (RedFonGO.GetComponent<Image> ().color.r,RedFonGO.GetComponent<Image> ().color.g,RedFonGO.GetComponent<Image> ().color.b,RedFonGO.GetComponent<Image> ().color.a - 0.02f);
			}else{BadlyNaw=0;RedFonGO.SetActive(false);}
		}
	}

	IEnumerator Shaking(){
		gameObject.transform.Rotate(0,0,1.2f);
		yield  return new WaitForSeconds(0.05f);
		gameObject.transform.Rotate(0,0,-1.2f);
		yield  return new WaitForSeconds(0.05f);
		gameObject.transform.Rotate(0,0,1.4f);
		yield  return new WaitForSeconds(0.05f);
		gameObject.transform.Rotate(0,0,-1.4f);
		yield  return new WaitForSeconds(0.05f);
		gameObject.transform.Rotate(0,0,1.2f);
		yield  return new WaitForSeconds(0.05f);
		gameObject.transform.Rotate(0,0,-1.2f);
		yield  return new WaitForSeconds(0.05f);
		gameObject.transform.Rotate(0,0,1f);
		yield  return new WaitForSeconds(0.05f);
		gameObject.transform.Rotate(0,0,-1f);
		yield  return new WaitForSeconds(0.05f);
		gameObject.transform.Rotate(0,0,-0.8f);
		yield  return new WaitForSeconds(0.05f);
		gameObject.transform.Rotate(0,0,0.8f);
		yield  return new WaitForSeconds(0.05f);
		gameObject.transform.Rotate(0,0,0.6f);
		yield  return new WaitForSeconds(0.05f);
		gameObject.transform.Rotate(0,0,-0.6f);
		yield  return new WaitForSeconds(0.05f);
		gameObject.transform.Rotate(0,0,-0.4f);
		yield  return new WaitForSeconds(0.05f);
		gameObject.transform.Rotate(0,0,0.4f);
		yield  return new WaitForSeconds(0.05f);
		gameObject.transform.Rotate(0,0,0.2f);
		yield  return new WaitForSeconds(0.05f);
		gameObject.transform.Rotate(0,0,-0.2f);
	}

}
