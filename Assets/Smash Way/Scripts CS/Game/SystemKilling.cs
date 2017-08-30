using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SystemKilling : MonoBehaviour {



	//System Counting and Update
	public RectTransform WayPercent;
	public float MaxDistance;
	private int Result;
	private int ResultSave;


	public RectTransform LineReserve;

	private float ReserveFloat=100; // 100 - original
	public float ReserveAdd;
	public float Convertation;
	private float SpeedDown;

	public RectTransform CircleStats;
	private int AddActive=0;

	public GameObject BadlyPointGO;
	private int NoLoopPoint=0;


	private bool EndReserve=false;
	private int CycleBadly=0;


	public GameObject BadlyFonGO;



	public GameObject PauseGO;
	public GameObject TapResetGO;
	public GameObject TextResetGO;


	public GameObject FonScorGO;
	public GameObject TextScorGO;

	private int CycleGameOver=0;
	private int ScoreNaw;

	//var Sound_Click:AudioClip;
	public AudioClip Sound_GameOver;

	public GameObject NoCollision;
	public string AssembleName;
	public GameObject Music;
	public GameObject Lessons;
	public float ResetFloatAdd=0;

	public void BadlySet(){
		ReserveFloat=ReserveFloat-40;
		gameObject.GetComponent<Stars>().Hits--;
	}



	public void AddReserv(){
		ReserveFloat=ReserveFloat+ReserveAdd;
		ReserveAdd=0;
		if(ReserveFloat>100){ReserveFloat=100;}
		AddActive=1;
	}


	public void RenderState(){
		LineReserve.GetComponent<Image>().fillAmount=ReserveFloat/100;
		Result = (int) (100-(MaxDistance-gameObject.transform.position.z-ResetFloatAdd)*100/MaxDistance);
		if(Result < 0){Result = 0;}
		if(ResultSave!=Result){
			WayPercent.GetComponent<Text>().text = Result.ToString() + "%";
			ResultSave=Result;
		}


		if(ReserveFloat<25){
			if(BadlyPointGO.activeInHierarchy==false){BadlyPointGO.SetActive(true);}
			if(NoLoopPoint==0){
				if(BadlyPointGO.GetComponent<Image>().color.a<1){
					BadlyPointGO.GetComponent<Image> ().color = new Color (BadlyPointGO.GetComponent<Image>().color.r,BadlyPointGO.GetComponent<Image>().color.g,BadlyPointGO.GetComponent<Image>().color.b,BadlyPointGO.GetComponent<Image>().color.a + 0.1f);
				}else{NoLoopPoint=1;}
			}
			if(NoLoopPoint==1){
				if(BadlyPointGO.GetComponent<Image>().color.a>0){
					BadlyPointGO.GetComponent<Image> ().color = new Color (BadlyPointGO.GetComponent<Image>().color.r,BadlyPointGO.GetComponent<Image>().color.g,BadlyPointGO.GetComponent<Image>().color.b,BadlyPointGO.GetComponent<Image>().color.a - 0.1f);
				}else{NoLoopPoint=0;}
			}
		}else{BadlyPointGO.SetActive(false);}
	}



	void FixedUpdate(){
		//Processed
		SpeedDown=GetComponent<CamAnim>().DoubleSpeed;
		SpeedDown=SpeedDown/Convertation;
		ReserveFloat=ReserveFloat-SpeedDown;
		if(ReserveFloat<=0.5){EndReserve=true;CycleBadly=1;
			LineReserve.GetComponent<Image>().fillAmount=0;
		}

		if(!EndReserve){RenderState();}

		if(CycleBadly==1){
			BadlyFonGO.SetActive(true);
			CycleBadly=2;
		}


		if(CycleBadly==2){
			if(BadlyFonGO.GetComponent<Image>().color.a<0.6){
				BadlyFonGO.GetComponent<Image> ().color = new Color (BadlyFonGO.GetComponent<Image>().color.r,BadlyFonGO.GetComponent<Image>().color.g,BadlyFonGO.GetComponent<Image>().color.b,BadlyFonGO.GetComponent<Image>().color.a +0.3f);
			}else{CycleBadly=3;}
		}

		if(CycleBadly==3){
			if(PauseGO.GetComponent<Image>().color.a>0){
				PauseGO.GetComponent<Image> ().color = new Color (PauseGO.GetComponent<Image>().color.r,PauseGO.GetComponent<Image>().color.g,PauseGO.GetComponent<Image>().color.b,PauseGO.GetComponent<Image>().color.a-0.1f);
			}else{
				if(CycleGameOver==0){
					if(Lessons){Lessons.SetActive(false);}
					NoCollision.SetActive(true);
					CycleGameOver=1;
					GetComponent<Badly>().BadlyNaw=2;
					GetComponent<AudioSource>().PlayOneShot(Sound_GameOver);
					gameObject.GetComponent<CamAnim>().Go=false;
					PauseGO.SetActive(false);
					TapResetGO.SetActive(true);
					TextResetGO.SetActive(true);
					FonScorGO.SetActive(true);
					TextScorGO.SetActive(true);
					ScoreNaw= (int) (gameObject.transform.position.z+ResetFloatAdd);
					PlayerPrefs.SetInt("LastLevels",0);
					TextScorGO.GetComponent<Text>().text = ScoreNaw.ToString();
					if(ScoreNaw>PlayerPrefs.GetInt(AssembleName.ToString())){
						PlayerPrefs.SetInt(AssembleName.ToString(),ScoreNaw);
					}
					gameObject.layer=2;
				}
			}
			if(gameObject.GetComponent<CamAnim>().speed>0.01f){
				gameObject.GetComponent<CamAnim>().speed=gameObject.GetComponent<CamAnim>().speed-0.01f;
			}else{
				gameObject.GetComponent<CamAnim>().enabled=false;
			}
			if(CycleGameOver==1){
				if(TapResetGO.GetComponent<Image>().color.a<0.7f){
					TapResetGO.GetComponent<Image> ().color = new Color (TapResetGO.GetComponent<Image>().color.r,TapResetGO.GetComponent<Image>().color.g,TapResetGO.GetComponent<Image>().color.b,TapResetGO.GetComponent<Image>().color.a+0.1f);
					TextResetGO.GetComponent<Text> ().color = new Color (TextResetGO.GetComponent<Text>().color.r,TextResetGO.GetComponent<Text>().color.g,TextResetGO.GetComponent<Text>().color.b,TextResetGO.GetComponent<Text>().color.a +0.1f);
				}else{
					if(TextScorGO.GetComponent<Text>().color.a<0.7f){
						TextScorGO.GetComponent<Text> ().color = new Color (TextScorGO.GetComponent<Text>().color.r,TextScorGO.GetComponent<Text>().color.g,TextScorGO.GetComponent<Text>().color.b,TextScorGO.GetComponent<Text>().color.a+0.02f);
						FonScorGO.GetComponent<Image> ().color = new Color (FonScorGO.GetComponent<Image> ().color.r,FonScorGO.GetComponent<Image> ().color.g,FonScorGO.GetComponent<Image> ().color.b,FonScorGO.GetComponent<Image> ().color.a + 0.02f);
						Music.GetComponent<AudioSource>().volume=Music.GetComponent<AudioSource>().volume-0.02f;
					}else{
						CycleGameOver=2;
					}
				}
			}
		}
	}


	void Update(){
		if(AddActive==1){
			CircleStats.sizeDelta = new Vector2 (100,CircleStats.sizeDelta.y);
			AddActive=-1;
		}
		if(AddActive==-1){
			if(CircleStats.sizeDelta.x>75){
				CircleStats.sizeDelta = new Vector2 (CircleStats.sizeDelta.x-1.5f,CircleStats.sizeDelta.y);
			}else{AddActive=0;}}
	}
}
