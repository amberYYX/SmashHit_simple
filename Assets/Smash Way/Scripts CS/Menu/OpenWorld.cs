using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OpenWorld : MonoBehaviour {

	public GameObject Music;
	public RectTransform Fon;
	private bool Stop=false;

	void Update(){
		if(!Stop){
			if(Music.GetComponent<AudioSource>().volume<1){
				Music.GetComponent<AudioSource>().volume=Music.GetComponent<AudioSource>().volume+0.02f;
				Fon.GetComponent<Image> ().color = new Color (Fon.GetComponent<Image>().color.r,Fon.GetComponent<Image>().color.g,Fon.GetComponent<Image>().color.b,Fon.GetComponent<Image>().color.a - 0.02f);
			}else{Stop=true;gameObject.SetActive(false);}
		}
	}
}
