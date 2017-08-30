using UnityEngine;
using System.Collections;

public class FireFlareControl : MonoBehaviour {



	private bool Pus=false;

	void Start(){
		StartCoroutine ("iStart");
	}

	IEnumerator iStart(){
		yield return new WaitForSeconds(0.1f);
		Pus=true;

	}


	void Update(){
		if(Pus){
			if(gameObject.GetComponent<LensFlare>().brightness>0){
				gameObject.GetComponent<LensFlare>().brightness=gameObject.GetComponent<LensFlare>().brightness-0.74f;
			}else{
				gameObject.SetActive(false);Pus=false;
			}
		}
	}
}
