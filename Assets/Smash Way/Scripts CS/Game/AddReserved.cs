using UnityEngine;
using System.Collections;

public class AddReserved : MonoBehaviour {



	public int ThisAdd;
	public GameObject Cam_Object;

	void Start(){
		Cam_Object.GetComponent<SystemKilling>().ReserveAdd=ThisAdd;
		Cam_Object.GetComponent<SystemKilling>().AddReserv();
	}
}
