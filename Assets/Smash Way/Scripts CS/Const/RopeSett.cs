using UnityEngine;
using System.Collections;

public class RopeSett : MonoBehaviour {



	public GameObject Rope;
	public LineRenderer LineRope;
	public GameObject[] ArrayPoint;
	public Vector3 AddForce;
	public AudioClip Sound;
	public bool OneForce=false;

	void Start(){
		Rope.SetActive(true);
	}


	public void OnMouseDown(){
		Doing();
	}

	void Doing(){
		gameObject.GetComponent<AudioSource>().PlayOneShot(Sound);
		if(!OneForce){
			if(gameObject.transform.localPosition.z<0){
				gameObject.GetComponent<Rigidbody>().velocity = 
				gameObject.GetComponent<Rigidbody>().velocity - AddForce;
			}else{
				gameObject.GetComponent<Rigidbody>().velocity = 
				gameObject.GetComponent<Rigidbody>().velocity + AddForce;
			}
		}else{
			gameObject.GetComponent<Rigidbody>().velocity = 
			gameObject.GetComponent<Rigidbody>().velocity + AddForce;
		}
	}

	void Update(){
		LineRope.SetPosition(0,ArrayPoint[0].transform.position);
		LineRope.SetPosition(1,ArrayPoint[1].transform.position);
		LineRope.SetPosition(2,ArrayPoint[2].transform.position);
		LineRope.SetPosition(3,ArrayPoint[3].transform.position);
		LineRope.SetPosition(4,ArrayPoint[4].transform.position);
		LineRope.SetPosition(5,ArrayPoint[5].transform.position);
		LineRope.SetPosition(6,ArrayPoint[6].transform.position);
		LineRope.SetPosition(7,ArrayPoint[7].transform.position);
		LineRope.SetPosition(8,ArrayPoint[8].transform.position);
		LineRope.SetPosition(9,ArrayPoint[9].transform.position);
		LineRope.SetPosition(10,ArrayPoint[10].transform.position);
	}
}
