using UnityEngine;
using System.Collections;

public class ControlAll : MonoBehaviour {


	public bool GravityTrue=false;
	public bool GravityFalse=false;
	public bool GravityAnti=false;
	public bool GravityDefault=false;
	public float GravityDefaultX;
	public float GravityDefaultY;
	public float GravityDefaultZ;
	//var Cam:GameObject;


	void Awake () {
		if(GravityTrue){Physics.gravity= new Vector3 (0,-9.81f,0);}
		if(GravityFalse){Physics.gravity= new Vector3 (0,0,0);}
		if(GravityAnti){Physics.gravity= new Vector3 (0,9.81f,0);}
		if(GravityDefault){
			Physics.gravity = new Vector3 (GravityDefaultX,GravityDefaultY,GravityDefaultZ);
		}
	}

}
