using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Finish : MonoBehaviour {

	public GameObject CamObject;
	public GameObject EndFon;
	public GameObject PauseButton;
	public GameObject Fon1;
	public GameObject Fon2;

	private int process =0;
	public float ReserveDist;
	private float Speed;

	public RectTransform Table;
	public GameObject TableAll;
	public GameObject Salut;
	public GameObject Music;
	public int NewAssembleL=0;
	public string AssembleName;
	public float ResetFloatAdd =0;

	private float DeltaVolume;
	private float Dist;

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag=="Camera"){
			if(EndFon.activeInHierarchy==false){
				CamObject.GetComponent<SystemKilling>().enabled=false;
				CamObject.GetComponent<CamAnim>().enabled=false;
				PauseButton.SetActive(false);
				Fon1.SetActive(false);
				Fon2.SetActive(false);
				process=1;

				if(PlayerPrefs.GetInt("AssembleL")<NewAssembleL){
					PlayerPrefs.SetInt("AssembleL",NewAssembleL);
				}
				int Dis = (int) (CamObject.transform.position.z + ResetFloatAdd);
				PlayerPrefs.SetInt(AssembleName.ToString(),Dis);
				DeltaVolume=1-Music.GetComponent<AudioSource>().volume;
			}
		}
	}



	void Start(){
		Dist=ReserveDist-gameObject.transform.position.z;
	}

	void FixedUpdate(){
		//Music

		if(process==1){
			if(Music.GetComponent<AudioSource>().volume>0){
				Music.GetComponent<AudioSource>().volume=
					(ReserveDist-CamObject.transform.position.z-ResetFloatAdd)/(ReserveDist-gameObject.transform.position.z-ResetFloatAdd)-DeltaVolume;
			}
			//Move
			if(CamObject.transform.position.z+ResetFloatAdd<ReserveDist){
				Speed=((100-(CamObject.transform.position.z-gameObject.transform.position.z)*100/Dist)/100);
				CamObject.transform.position  = new Vector3(CamObject.transform.position.x,CamObject.transform.position.y,CamObject.transform.position.z+Speed);
			}

			if(CamObject.transform.position.z+1.5f+ResetFloatAdd>ReserveDist){
				Salut.SetActive(true);
				TableAll.SetActive(true);
				process=2;
			}
		}

		if(process==2){
			if(Table.GetComponent<Image>().color.a<1){
				Table.GetComponent<Image> ().color = new Color (Table.GetComponent<Image>().color.r,Table.GetComponent<Image>().color.g,Table.GetComponent<Image>().color.b,Table.GetComponent<Image>().color.a+0.05f);
				Table.GetComponent<Image>().fillAmount += 0.05f;
			}else{process=3;
				CamObject.GetComponent<Stars>().FinishCall();
			}
		}
	}

}
