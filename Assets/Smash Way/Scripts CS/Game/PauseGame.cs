using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour {

	public bool FonRend=false;
	public bool Pause=false;
	public bool Continie=false;
	public bool DefaultGo=false;
	public GameObject Cam;
	public RectTransform TableRT;
	public GameObject TableAll;
	public RectTransform PauseRT;
	public GameObject  ReloadFon1GO;
	public GameObject ReloadFon2GO;
	public string NameLevel;
	public AudioClip PauseLoad;
	private float PitchAudio;

	private int NoLoop = 0;

	public GameObject ColliderNoTap;

	public GameObject Music;
	public float Vol;

	private bool NoLoopMus =true;

	void Start(){
		PitchAudio=Music.GetComponent<AudioSource>().pitch;
	}


	public void OnMouseDown(){
		if(Pause){
			if(TableRT.GetComponent<Image>().fillAmount < 0.1f){
				if(NoLoop==0){
					NoLoop=1;
					//Cam.layer=2;
					TableAll.SetActive(true);
					GetComponent<AudioSource>().PlayOneShot(PauseLoad);
					ColliderNoTap.SetActive(true);
				}
			}
		}
		if(Continie){
			if(NoLoop==0){
				Time.timeScale=1;
				NoLoop=-1;
				GetComponent<AudioSource>().PlayOneShot(PauseLoad);
				ColliderNoTap.SetActive(false);
			}
		}

		if(DefaultGo){
			if(NoLoop==0){
				Time.timeScale=1;
				NoLoop=2;
				GetComponent<AudioSource>().PlayOneShot(PauseLoad);
			}
		}
	}

	void Update(){
		if(Pause){
			if(NoLoopMus){
				if(Music.GetComponent<AudioSource>().volume<Vol){
					Music.GetComponent<AudioSource>().volume=Music.GetComponent<AudioSource>().volume+0.01f;
				}else{NoLoopMus=false;}
			}
		}
	}


	void FixedUpdate(){

		if(FonRend){
			if(ReloadFon2GO.GetComponent<Image>().color.a>0){
				ReloadFon2GO.GetComponent<Image> ().color = new Color (ReloadFon2GO.GetComponent<Image>().color.r,ReloadFon2GO.GetComponent<Image>().color.g,ReloadFon2GO.GetComponent<Image>().color.b,ReloadFon2GO.GetComponent<Image>().color.a -0.1f);
			}else{
				if(ReloadFon1GO.GetComponent<Image>().color.a>0){
					ReloadFon1GO.GetComponent<Image>().color = new Color (ReloadFon1GO.GetComponent<Image>().color.r,ReloadFon1GO.GetComponent<Image>().color.g,ReloadFon1GO.GetComponent<Image>().color.b,ReloadFon1GO.GetComponent<Image>().color.a -0.1f);
				}else{
					FonRend=false;
					ReloadFon1GO.SetActive(false);
					ReloadFon2GO.SetActive(false);
				}
			}
		}

		if(NoLoop==1){
			if(TableRT.GetComponent<Image>().color.a<1){
				PauseRT.GetComponent<Image> ().color = new Color (PauseRT.GetComponent<Image> ().color.r,PauseRT.GetComponent<Image> ().color.g,PauseRT.GetComponent<Image> ().color.b,PauseRT.GetComponent<Image> ().color.a - 0.1f);
				TableRT.GetComponent<Image>().color = new Color(TableRT.GetComponent<Image>().color.r,TableRT.GetComponent<Image>().color.g,TableRT.GetComponent<Image>().color.b,TableRT.GetComponent<Image>().color.a +0.1f);
				TableRT.GetComponent<Image>().fillAmount=TableRT.GetComponent<Image>().fillAmount+0.1f;
			}else{
				NoLoop=0;
				Music.GetComponent<AudioSource>().pitch=0;
				Time.timeScale=0;
			}
		}

		if(NoLoop==-1){
			if(TableRT.GetComponent<Image>().color.a>0){
				PauseRT.GetComponent<Image> ().color = new Color (PauseRT.GetComponent<Image> ().color.r,PauseRT.GetComponent<Image> ().color.g,PauseRT.GetComponent<Image> ().color.b,PauseRT.GetComponent<Image> ().color.a + 0.1f);
				TableRT.GetComponent<Image>().color = new Color(TableRT.GetComponent<Image>().color.r,TableRT.GetComponent<Image>().color.g,TableRT.GetComponent<Image>().color.b,TableRT.GetComponent<Image>().color.a  - 0.1f);
				TableRT.GetComponent<Image>().fillAmount=TableRT.GetComponent<Image>().fillAmount-0.1f;
			}else{
				NoLoop=0;
				TableAll.SetActive(false);
				Music.GetComponent<AudioSource>().pitch = PitchAudio;
			}
		}

		if(NoLoop==2){
			ReloadFon1GO.SetActive(true);
			ReloadFon2GO.SetActive(true);
			NoLoop=-2;
		}

		if(NoLoop==-2){
			if(TableRT.GetComponent<Image>().color.a>0){
				TableRT.GetComponent<Image>().color = new Color(TableRT.GetComponent<Image>().color.r,TableRT.GetComponent<Image>().color.g,TableRT.GetComponent<Image>().color.b,TableRT.GetComponent<Image>().color.a  - 0.1f);
				TableRT.GetComponent<Image>().fillAmount=TableRT.GetComponent<Image>().fillAmount-0.1f;
			}
			if(ReloadFon1GO.GetComponent<Image>().color.a < 1){
				ReloadFon1GO.GetComponent<Image> ().color = new Color (ReloadFon1GO.GetComponent<Image>().color.r,ReloadFon1GO.GetComponent<Image>().color.g,ReloadFon1GO.GetComponent<Image>().color.b,ReloadFon1GO.GetComponent<Image>().color.a + 0.1f);
			}else{
				if(ReloadFon2GO.GetComponent<Image>().color.a<1){
					ReloadFon2GO.GetComponent<Image> ().color = new Color (ReloadFon2GO.GetComponent<Image>().color.r,ReloadFon2GO.GetComponent<Image>().color.g,ReloadFon2GO.GetComponent<Image>().color.b,ReloadFon2GO.GetComponent<Image>().color.a + 0.1f);
				}else{
					NoLoop=0;
					SceneManager.LoadScene(NameLevel.ToString());
				}
			}
		}
	}
}
