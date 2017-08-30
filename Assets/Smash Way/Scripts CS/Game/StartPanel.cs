using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartPanel : MonoBehaviour {


	public GameObject Table;
	public RectTransform TableRT;
	public GameObject Continie;
	public RectTransform ContinieRT;
	public GameObject New;
	public RectTransform NewRT;
	public GameObject Menu;
	public RectTransform MenuRT;
	public GameObject Cam;

	private bool Stat = false;


	void Start () {
		StartCoroutine ("iStart");
	}

	IEnumerator iStart(){
		if(PlayerPrefs.GetInt("SaveFlight")==1){
			Cam.layer=2;
			yield return new WaitForSeconds(0.5f);
			Table.SetActive(true);
			Continie.SetActive(true);
			New.SetActive(true);
			Menu.SetActive(true);
			Stat=true;
		}

	}

	void FixedUpdate(){
		if(Stat){
			if(TableRT.GetComponent<Image>().color.a<1){
				TableRT.GetComponent<Image>().color = new Color(TableRT.GetComponent<Image>().color.r,TableRT.GetComponent<Image>().color.g,TableRT.GetComponent<Image>().color.b,TableRT.GetComponent<Image>().color.a +0.05f);
				ContinieRT.GetComponent<Image>().color = TableRT.GetComponent<Image>().color;
				NewRT.GetComponent<Image>().color = TableRT.GetComponent<Image>().color;
				MenuRT.GetComponent<Image>().color = TableRT.GetComponent<Image>().color;
			}else{
				Time.timeScale=0;
				Stat=false;
			}
		}
	}
}
