using UnityEngine;
using System.Collections;

public class DestroyAll : MonoBehaviour {



	public GameObject Cam_Object;
	public float Distance;
	private int Rest = 0;

	IEnumerator Search(){
		yield return new WaitForSeconds(2);
		if(gameObject.transform.position.z < Cam_Object.transform.position.z- Distance){
			Destroy(gameObject);
		}else{Rest=0;}
	}

	void Update(){
		if(Rest == 0){
			Rest= 1;
			StartCoroutine("Search");
		}
	}

}
