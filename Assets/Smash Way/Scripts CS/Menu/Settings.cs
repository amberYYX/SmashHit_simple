using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Settings : MonoBehaviour {



	public bool ThisRuleSetting=false;
	public GameObject[] BarsArray;
	public AnimationClip[] SettAnim;
	public AnimationClip[] BarAnim;
	private int NonTapTap=1;

	public bool ThisSettingGraphics=false;
	public Sprite[] SpriteArray;

	public RectTransform Face;

	private int GraphicsSave=0;
	private int MiniBat=0;

	void Awake(){
		if(ThisSettingGraphics){
			if(PlayerPrefs.HasKey("GraphicsSave")){
				GraphicsSave=PlayerPrefs.GetInt("GraphicsSave");
				QualitySett();
			}else{
				GraphicsSave=2;
				PlayerPrefs.SetInt("GraphicsSave",GraphicsSave);
			}
		}
	}


	public void OnDown(){
		if(ThisRuleSetting){
			if(NonTapTap==1){
				NonTapTap=2;
				gameObject.GetComponent<Animation>().Play(SettAnim[0].name);
				BarsArray[0].GetComponent<Animation>().Play(BarAnim[0].name);
				BarsArray[1].GetComponent<Animation>().Play(BarAnim[1].name);
				ResetTime();
			}
			if(NonTapTap==-1){
				NonTapTap=-2;
				gameObject.GetComponent<Animation>().Play(SettAnim[1].name);
				BarsArray[0].GetComponent<Animation>().Play(BarAnim[1].name);
				BarsArray[1].GetComponent<Animation>().Play(BarAnim[0].name);
				ResetTime();
			}
		}
		if(ThisSettingGraphics){
			if(MiniBat==0){
				if(GraphicsSave==3){MiniBat=3;}
				if(GraphicsSave==2){MiniBat=2;}
				if(GraphicsSave==1){MiniBat=1;}
			}
		}
	}

	IEnumerator ResetTime(){
		yield return new WaitForSeconds(BarAnim[0].length);
		if(NonTapTap==2){NonTapTap=-1;}else{NonTapTap=1;}
	}


	void Update(){
		if(ThisSettingGraphics){
			if(MiniBat==1){
				if(Face.GetComponent<Image>().color.a>0){
					Face.GetComponent<Image> ().color = new Color (Face.GetComponent<Image>().color.r,Face.GetComponent<Image>().color.g,Face.GetComponent<Image>().color.b,Face.GetComponent<Image>().color.a - 0.1f);
				}else{
					MiniBat=11;
					GraphicsSave=2;
					QualitySettings.SetQualityLevel(2);
					gameObject.GetComponent<Image>().sprite=SpriteArray[1];
					PlayerPrefs.SetInt("GraphicsSave",GraphicsSave);
				}
			}
			if(MiniBat==11){
				if(Face.GetComponent<Image>().color.a<1){
					Face.GetComponent<Image> ().color = new Color (Face.GetComponent<Image>().color.r,Face.GetComponent<Image>().color.g,Face.GetComponent<Image>().color.b,Face.GetComponent<Image>().color.a + 0.1f);
				}else{MiniBat=0;}
			}

			if(MiniBat==2){
				if(Face.GetComponent<Image>().color.a>0){
					Face.GetComponent<Image> ().color = new Color (Face.GetComponent<Image>().color.r,Face.GetComponent<Image>().color.g,Face.GetComponent<Image>().color.b,Face.GetComponent<Image>().color.a - 0.1f);
				}else{
					MiniBat=22;
					GraphicsSave=3;
					QualitySettings.SetQualityLevel(3);
					gameObject.GetComponent<Image>().sprite=SpriteArray[2];
					PlayerPrefs.SetInt("GraphicsSave",GraphicsSave);
				}
			}
			if(MiniBat==22){
				if(Face.GetComponent<Image>().color.a<1){
					Face.GetComponent<Image> ().color = new Color (Face.GetComponent<Image>().color.r,Face.GetComponent<Image>().color.g,Face.GetComponent<Image>().color.b,Face.GetComponent<Image>().color.a + 0.1f);
				}else{MiniBat=0;}
			}

			if(MiniBat==3){
				if(Face.GetComponent<Image>().color.a>0){
					Face.GetComponent<Image> ().color = new Color (Face.GetComponent<Image>().color.r,Face.GetComponent<Image>().color.g,Face.GetComponent<Image>().color.b,Face.GetComponent<Image>().color.a - 0.1f);
				}else{
					MiniBat=33;
					GraphicsSave=1;
					QualitySettings.SetQualityLevel(1);
					gameObject.GetComponent<Image>().sprite=SpriteArray[0];
					PlayerPrefs.SetInt("GraphicsSave",GraphicsSave);
				}
			}
			if(MiniBat==33){
				if(Face.GetComponent<Image>().color.a<1){
					Face.GetComponent<Image> ().color = new Color (Face.GetComponent<Image>().color.r,Face.GetComponent<Image>().color.g,Face.GetComponent<Image>().color.b,Face.GetComponent<Image>().color.a + 0.1f);
				}else{MiniBat=0;}
			}
		}
	}



	void QualitySett(){
		if(GraphicsSave==1){QualitySettings.SetQualityLevel(1);
			gameObject.GetComponent<Image>().sprite=SpriteArray[0];
		}
		if(GraphicsSave==2){QualitySettings.SetQualityLevel(2);
			gameObject.GetComponent<Image>().sprite=SpriteArray[1];
		}
		if(GraphicsSave==3){QualitySettings.SetQualityLevel(3);
			gameObject.GetComponent<Image>().sprite=SpriteArray[2];
		}
	}
}
