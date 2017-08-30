using UnityEngine;
using System.Collections;

public class TriggerOther : MonoBehaviour {



	public bool ThisRotation=false;
	public GameObject Cam;
	public int Angle;
	public float AngleSpeed;

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag=="Camera"){
			if(ThisRotation){
				Cam.GetComponent<CamAnim>().ReservRotate=Angle;
				Cam.GetComponent<CamAnim>().RotateSpeed=AngleSpeed;
				Cam.GetComponent<CamAnim>().Rotate();
			}
		}
	}
}
