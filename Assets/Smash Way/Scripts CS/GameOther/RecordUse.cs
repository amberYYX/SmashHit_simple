using UnityEngine;
using System.Collections;

public class RecordUse : MonoBehaviour {



	public GameObject FinishObj;
	private int Distance;
	public GameObject Sprite;

	void Awake () {
		Distance=PlayerPrefs.GetInt(FinishObj.GetComponent<Finish>().AssembleName.ToString());
		gameObject.transform.position = new Vector3 (gameObject.transform.position.x,gameObject.transform.position.y,Distance);
		if(FinishObj.GetComponent<Finish>().NewAssembleL<=PlayerPrefs.GetInt("AssembleL")){
			gameObject.SetActive(false);
		}
	}

	void Start(){
		StartCoroutine ("iStart");
	}

	IEnumerator iStart(){
		yield return new WaitForSeconds(7);
		Sprite.SetActive(true);
	}
}
