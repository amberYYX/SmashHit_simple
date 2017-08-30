using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Base : MonoBehaviour {

	public int AssembleInt;
	public GameObject ObjectAssemble;

	public bool TapUp=false;
	public bool TapDown=false;
	public bool NoLooper=true;

	public RectTransform[] Rooms;

	public AnimationClip aRight1;
	public AnimationClip aRight2;

	public AnimationClip aLeft1;
	public AnimationClip aLeft2;

	private int UpBlock=0;
	private int DownBlock=0;

	public int SizeElements;
	public AudioClip SoundL;
	public AudioClip SoundR;

	public string[] StarsRe;
	public RectTransform Med;
	public Sprite[] MedSprites;
	public int ThisMed=0;

	private int ThisMedReset=0;

	public RectTransform PontWay;

	public GameObject WayObject;


	public void AssembleFA(){
		if(AssembleInt+1<Rooms.Length){AssembleInt++;}else{AssembleInt=0;}
	}
	public void AssembleFD(){
		if(AssembleInt>0){AssembleInt--;}else{AssembleInt=Rooms.Length-1;}
	}


	void Start(){
		SizeElements=Rooms.Length;SizeElements--;

		ThisMed=PlayerPrefs.GetInt(StarsRe[0].ToString());
		if(gameObject.name!="Canvas Menu"){
			Med.GetComponent<Image>().sprite=MedSprites[ThisMed];
		}
	}


	public void OnMouseDown(){
		if(PontWay.GetComponent<Image>().color.a > 0.9f){
			if(NoLooper){
				NoLooper=false;
				AssembleInt=ObjectAssemble.GetComponent<Base>().AssembleInt;
				if(TapUp){ StartCoroutine("UpBlockF");GetComponent<AudioSource>().PlayOneShot(SoundR);}
				if(TapDown){StartCoroutine("DownBlockF");GetComponent<AudioSource>().PlayOneShot(SoundL);}

				WayObject.GetComponent<BasisWay>().GoInNew=AssembleInt;
				WayObject.GetComponent<BasisWay>().ResetPosition();
			}
		}
	}

	public IEnumerator UpBlockF(){
		Rooms[AssembleInt].GetComponent<Animation>().Play (aRight2.name);
		if(AssembleInt+1<Rooms.Length){AssembleInt++;}else{AssembleInt=0;}
		Rooms[AssembleInt].GetComponent<Animation>().Play (aRight1.name);
		yield return new WaitForSeconds(0.333f);

		ThisMed=PlayerPrefs.GetInt(StarsRe[AssembleInt].ToString());
		if(StarsRe[AssembleInt].ToString()!="Non"){
			ThisMedReset=1;
		}else{
			ThisMedReset=-1;
		}

		NoLooper=true;
		ObjectAssemble.GetComponent<Base>().AssembleFA();
	}

	public IEnumerator DownBlockF(){
		Rooms[AssembleInt].GetComponent<Animation>().Play (aLeft1.name);
		if(AssembleInt>0){AssembleInt--;}else{AssembleInt=Rooms.Length-1;}
		Rooms[AssembleInt].GetComponent<Animation>().Play (aLeft2.name);
		yield return new WaitForSeconds(0.333f);

		ThisMed=PlayerPrefs.GetInt(StarsRe[AssembleInt].ToString());
		if(StarsRe[AssembleInt].ToString()!="Non"){
			ThisMedReset=1;
		}else{
			ThisMedReset=-1;
		}

		NoLooper=true;
		ObjectAssemble.GetComponent<Base>().AssembleFD();
	}


	void FixedUpdate(){
		if(ThisMedReset==1){
			if(Med.GetComponent<Image>().color.a>0){
				Med.GetComponent<Image>().fillAmount=Med.GetComponent<Image>().fillAmount - 0.1f;
				Med.GetComponent<Image> ().color = new Color (Med.GetComponent<Image>().color.r,Med.GetComponent<Image>().color.g,Med.GetComponent<Image>().color.b,Med.GetComponent<Image>().color.a - 0.1f);
			}else{
				ThisMedReset=2;
				Med.GetComponent<Image>().sprite=MedSprites[ThisMed];
			}
		}

		if(ThisMedReset==2){
			if(Med.GetComponent<Image>().color.a<1){
				Med.GetComponent<Image>().fillAmount=Med.GetComponent<Image>().fillAmount+0.1f;
				Med.GetComponent<Image> ().color = new Color (Med.GetComponent<Image>().color.r,Med.GetComponent<Image>().color.g,Med.GetComponent<Image>().color.b,Med.GetComponent<Image>().color.a + 0.1f);
			}else{
				ThisMedReset=0;
			}
		}

		if(ThisMedReset==-1){
			if(Med.GetComponent<Image>().color.a>0){
				Med.GetComponent<Image>().fillAmount=Med.GetComponent<Image>().fillAmount-0.1f;
				Med.GetComponent<Image> ().color = new Color (Med.GetComponent<Image>().color.r,Med.GetComponent<Image>().color.g,Med.GetComponent<Image>().color.b,Med.GetComponent<Image>().color.a - 0.1f);
			}else{ThisMedReset=0;}
		}

	}


}
