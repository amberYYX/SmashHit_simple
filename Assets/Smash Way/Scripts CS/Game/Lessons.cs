using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Lessons : MonoBehaviour {

	public GameObject LinePGO;
	public GameObject TextPGO;
	public GameObject TextTGO;
	public GameObject TextGGO;

	private int Process=0;

	public int Message=0;
	public int MessageBox=0;

	public int TimeTapBox=0;

	public bool TapBox=false;
	public GameObject SendCall;

	void Start () {
		if(!TapBox){
			StartCoroutine ("iStart");
		}
	}

	IEnumerator iStart(){
		yield return new WaitForSeconds(3);
		LinePGO.SetActive(true);
		TextPGO.SetActive(true);
		Process=1;
		yield return new WaitForSeconds(TimeTapBox);
		TextTGO.SetActive(true);
		Process=3;
	}


	void Update () {
		if(!TapBox){
			if(Process==1){
				if(LinePGO.GetComponent<Image>().color.a<1){
					LinePGO.GetComponent<Image> ().color = new Color (LinePGO.GetComponent<Image>().color.r,LinePGO.GetComponent<Image>().color.g,LinePGO.GetComponent<Image>().color.b,LinePGO.GetComponent<Image>().color.a + 0.05f);
					TextPGO.GetComponent<Text> ().color = LinePGO.GetComponent<Image> ().color;
				}else{if(Message>=2){Process=0;StartCoroutine("TimePause4");}}
			}
					if(Process==2){
						if(LinePGO.GetComponent<Image>().color.a>0){
					LinePGO.GetComponent<Image> ().color = new Color (LinePGO.GetComponent<Image>().color.r,LinePGO.GetComponent<Image>().color.g,LinePGO.GetComponent<Image>().color.b,LinePGO.GetComponent<Image>().color.a - 0.05f);
					TextPGO.GetComponent<Text> ().color = LinePGO.GetComponent<Image> ().color;
						}else{TimePause();Process=0;}
					}

					if(Process==3){
						if(LinePGO.GetComponent<Image>().color.a<1){
					LinePGO.GetComponent<Image> ().color = new Color (LinePGO.GetComponent<Image>().color.r,LinePGO.GetComponent<Image>().color.g,LinePGO.GetComponent<Image>().color.b,LinePGO.GetComponent<Image>().color.a + 0.05f);
					TextTGO.GetComponent<Text>().color = LinePGO.GetComponent<Image> ().color;
						}else{Process=4;}
					}

					if(Process==4){
						if(MessageBox>=1){Process=6;}
					}


					if(Process==6){
						if(TextTGO.GetComponent<Text>().color.a>0){
					TextTGO.GetComponent<Text> ().color = LinePGO.GetComponent<Image> ().color;
						LinePGO.GetComponent<Image> ().color = new Color (LinePGO.GetComponent<Image>().color.r,LinePGO.GetComponent<Image>().color.g,LinePGO.GetComponent<Image>().color.b,LinePGO.GetComponent<Image>().color.a - 0.05f);
						}else{Process=0;
					StartCoroutine("TimePause3");
							TextTGO.SetActive(false);
							TextGGO.SetActive(true);
						}
					}

					if(Process==7){
						if(TextGGO.GetComponent<Text>().color.a<1){
					TextGGO.GetComponent<Text> ().color = LinePGO.GetComponent<Image> ().color;
					LinePGO.GetComponent<Image> ().color = new Color (LinePGO.GetComponent<Image>().color.r,LinePGO.GetComponent<Image>().color.g,LinePGO.GetComponent<Image>().color.b,LinePGO.GetComponent<Image>().color.a + 0.05f);
				}else{Process=0; StartCoroutine("TimePause2");}
					}

					if(Process==8){
						if(TextGGO.GetComponent<Text>().color.a>0){
					TextGGO.GetComponent<Text> ().color = LinePGO.GetComponent<Image> ().color;
					LinePGO.GetComponent<Image> ().color = new Color (LinePGO.GetComponent<Image>().color.r,LinePGO.GetComponent<Image>().color.g,LinePGO.GetComponent<Image>().color.b,LinePGO.GetComponent<Image>().color.a - 0.05f);
						}else{Process=0; 
							TextGGO.SetActive(false);
							LinePGO.SetActive(false);
							gameObject.SetActive(false);
						}
					}
				}
			}


			void TimePause(){
				TextPGO.SetActive(false);
			}

			IEnumerator TimePause2(){
			yield return new WaitForSeconds(1);
				Process=8;
			}

			IEnumerator TimePause3(){
			yield return new WaitForSeconds(5);
				Process=7;
			}

			IEnumerator TimePause4(){
				yield return new WaitForSeconds(2);
				Process=2;
			}

			public void OnTouchDown(){
				if(TapBox){
					SendCall.GetComponent<Lessons>().MessageBox++;
				}
			}

			public void OnMouseDown(){
				if(TapBox){
					SendCall.GetComponent<Lessons>().MessageBox++;
				}
			}
}
