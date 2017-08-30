using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Stars : MonoBehaviour {

	public RectTransform Med;
	public Sprite Stars0;
	public Sprite Stars1;
	public Sprite Stars2;
	public Sprite Stars3;


	public int Hits=5;//=5
	public string ReitStars;
	private int GetHits;

	private int PuskProcess=0;

	void Start(){
		if(PlayerPrefs.HasKey(ReitStars.ToString())){
			GetHits = PlayerPrefs.GetInt(ReitStars.ToString());
		}else{GetHits = 0;}


	}


	public void FinishCall(){
		if(Hits<1){Hits=0;}
		if(Hits==2||Hits==1){Hits=1;}
		if(Hits==4||Hits==3){Hits=2;}
		if(Hits>=5){Hits=3;}

		if(GetHits<Hits){
			PlayerPrefs.SetInt(ReitStars.ToString(),Hits);
		}
		if(Hits==3){
			Med.GetComponent<Image>().sprite=Stars3;
		}
		if(Hits==2){
			Med.GetComponent<Image>().sprite=Stars2;
		}
		if(Hits==1){
			Med.GetComponent<Image>().sprite=Stars1;
		}
		if(Hits==0){
			Med.GetComponent<Image>().sprite=Stars0;
		}
		PuskProcess=1;
	}

	void FixedUpdate(){
		if(PuskProcess==1){
			if(Med.GetComponent<Image>().fillAmount<1){
				Med.GetComponent<Image>().fillAmount=Med.GetComponent<Image>().fillAmount+0.05f;
				Med.GetComponent<Image> ().color = new Color (Med.GetComponent<Image>().color.r,Med.GetComponent<Image>().color.g,Med.GetComponent<Image>().color.b,Med.GetComponent<Image>().color.a + 0.05f);
			}else{
				PuskProcess=0;
			}
		}
	}

}
