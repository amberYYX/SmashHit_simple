using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BaseOpen : MonoBehaviour {



	public bool ThisBase=false;
	public RectTransform[] Levels;
	public Sprite[] OpenLevels;
	public Sprite[] BlokLevels;
	public int LevelsList;
	public string[] LevelsListName;
	private int AssembleL=0;
	private int SyclesNaw=0;
	private bool SyclesOpen=false;

	public GameObject MusicPlay;
	public RectTransform Fon2;
	public GameObject Fon2GO;
	private bool TimeDown=false;
	public GameObject Loading;
	public AudioClip Sound;

	private bool Stop=false;

	void Start(){
		if(ThisBase){
			if(PlayerPrefs.HasKey("AssembleL")){
				AssembleL=PlayerPrefs.GetInt("AssembleL");
			}else{
				PlayerPrefs.SetInt("AssembleL",AssembleL);
			}
			SyclesOpen=true;
		}
	}
	void Update(){
		if(SyclesOpen){
			if(SyclesNaw<Levels.Length){
				if(AssembleL>=SyclesNaw){Levels[SyclesNaw].GetComponent<Image>().sprite=OpenLevels[SyclesNaw];}
				else{Levels[SyclesNaw].GetComponent<Image>().sprite=BlokLevels[SyclesNaw];}
				SyclesNaw++;
			}else{SyclesOpen=false;}
		}
	}

	public void OnMouseDown(){
		AssembleL=PlayerPrefs.GetInt("AssembleL");
		if(AssembleL>=LevelsList){
			TimeDown=true;
			Loading.SetActive(true);
			Fon2GO.SetActive(true);
			GetComponent<AudioSource>().PlayOneShot(Sound);
		}
	}

	void FixedUpdate(){
		if(TimeDown){
			if(Fon2.GetComponent<Image>().color.a<1){
				MusicPlay.GetComponent<AudioSource>().volume=MusicPlay.GetComponent<AudioSource>().volume-0.02f;
				Fon2.GetComponent<Image> ().color = new Color (Fon2.GetComponent<Image>().color.r,Fon2.GetComponent<Image>().color.g,Fon2.GetComponent<Image>().color.b,Fon2.GetComponent<Image>().color.a + 0.02f );
			}else{TimeDown=false;
				SceneManager.LoadScene(LevelsListName[LevelsList].ToString());
			}
		}
	}

}
