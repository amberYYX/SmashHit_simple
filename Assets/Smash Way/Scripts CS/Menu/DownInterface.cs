using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DownInterface : MonoBehaviour {

	public bool ThisSound=false;
	public bool ThisDistance=false;
	public RectTransform RectSound;
	public Sprite SpriteSyes;
	public Sprite SpriteSno;
	private int SoundActive=0;

	public int ScoreArray;
	private int ToolkingArray=0;
	private int AssembleDist;
	public string[] ArrayDist;
	public RectTransform Distance;

	void Start(){
		if(ThisSound){
			if(PlayerPrefs.HasKey("SoundActive")){
				SoundActive=PlayerPrefs.GetInt("SoundActive");
			}else{SoundActive=1;}
			DoingSound();
		}
		if(ThisDistance){DoingDistance();}
	}

	public void OnMouseDown(){
		if(ThisSound){
			if(SoundActive==0){SoundActive=1;DoingSound();
			}else{SoundActive=0;DoingSound();}
		}
	}



	public void DoingSound(){
		if(SoundActive==0){AudioListener.pause=true;
			RectSound.GetComponent<Image>().sprite=SpriteSno;}
		if(SoundActive==1){AudioListener.pause=false;
			RectSound.GetComponent<Image>().sprite=SpriteSyes;}
		PlayerPrefs.SetInt("SoundActive",SoundActive);
	}

	public void DoingDistance(){
		while(ToolkingArray<ScoreArray){
			AssembleDist=AssembleDist+PlayerPrefs.GetInt(ArrayDist[ToolkingArray].ToString());
			ToolkingArray++;
		}
		Distance.GetComponent<Text>().text=AssembleDist.ToString();
		PlayerPrefs.SetInt("AllDistance",AssembleDist);
	}
}
