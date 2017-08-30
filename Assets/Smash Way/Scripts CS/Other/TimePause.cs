using UnityEngine;
using System.Collections;

public class TimePause : MonoBehaviour {



	public float TimeActive;
	public GameObject ObjectActive;


	void Start () {
		StartCoroutine ("iStart");
	}

	IEnumerator iStart(){
		yield return new WaitForSeconds(TimeActive);
		ObjectActive.SetActive(true);
	}

}
