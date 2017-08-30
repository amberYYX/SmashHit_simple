using UnityEngine;
using System.Collections;

public class DestroyRoom : MonoBehaviour {

	public GameObject ThisRoom;
	public GameObject NextRoom;
	public bool Last=false;

	void OnTriggerEnter( Collider other){
		if(other.gameObject.tag=="Camera"){
			Destroy(ThisRoom);
			if(!Last){NextRoom.SetActive(true);}
		}
	}
}
