using UnityEngine;
using System.Collections;

public class ResetFloat : MonoBehaviour {
	
	public GameObject ObjectCam;
	public GameObject ObjectRooms;
	public float DeleteFloat;
	public GameObject FinishSend;

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag=="Camera"){
			ObjectRooms.transform.position = new Vector3 (ObjectRooms.transform.position.x,ObjectRooms.transform.position.y,ObjectRooms.transform.position.z - DeleteFloat);
			ObjectCam.transform.position = new Vector3 (ObjectCam.transform.position.x,ObjectCam.transform.position.y,ObjectCam.transform.position.z-DeleteFloat);
			FinishSend.GetComponent<Finish>().ResetFloatAdd=DeleteFloat;
			ObjectCam.GetComponent<SystemKilling>().ResetFloatAdd=DeleteFloat;
			ObjectCam.GetComponent<CamAnim>().OtherDistance=DeleteFloat;
			Destroy(gameObject);
		}
	}
}
