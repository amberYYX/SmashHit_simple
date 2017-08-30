using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BasisWay : MonoBehaviour {

	public RectTransform SpritesBase;
	public float GoInNew;

	public float[] PointPosition;

	private int Process=0;


	public void ResetPosition(){
		Process=1;
	}
		
	void FixedUpdate(){
		if(Process==1){
			if(SpritesBase.GetComponent<Image>().color.a>0){
				SpritesBase.GetComponent<Image> ().color = new Color (SpritesBase.GetComponent<Image>().color.r,SpritesBase.GetComponent<Image>().color.g,SpritesBase.GetComponent<Image>().color.b,SpritesBase.GetComponent<Image>().color.a - 0.1f);
			}else{
				Process=2;
				SpritesBase.transform.localPosition = new Vector3 ( PointPosition[(int) GoInNew],SpritesBase.transform.localPosition.y,SpritesBase.transform.localPosition.z);
			}
		}
		if(Process==2){
			if(SpritesBase.GetComponent<Image>().color.a<1){
				SpritesBase.GetComponent<Image> ().color = new Color (SpritesBase.GetComponent<Image>().color.r,SpritesBase.GetComponent<Image>().color.g,SpritesBase.GetComponent<Image>().color.b,SpritesBase.GetComponent<Image>().color.a + 0.1f);
			}else{
				Process=0;
			}
		}
	}
}
