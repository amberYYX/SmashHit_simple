using UnityEngine;
using System.Collections;

public class CamAnim : MonoBehaviour {



	public float speed;//max
	public float DoubleSpeed;
	private float EndDistance;
	private float Cof;
	public float OtherDistance; 
	public AnimationCurve AnimSpeed;
	public bool Go=false;

	public float ReservRotate;
	public float RotateSpeed;
	private int PuskReserve=0;



	void Start(){
		EndDistance=gameObject.GetComponent<SystemKilling>().MaxDistance;
	}



	public void Rotate(){
		if(PuskReserve==0){
			PuskReserve=1;
		}
	}

	void FixedUpdate () {
		gameObject.transform.position = new Vector3(gameObject.transform.position.x,gameObject.transform.position.y, gameObject.transform.position.z+DoubleSpeed);
		if(!Go){
			Cof=(gameObject.transform.position.z+OtherDistance)/EndDistance;
			if(Cof>0&&Cof<1){DoubleSpeed=speed+AnimSpeed.Evaluate(Cof);}
			else{DoubleSpeed=speed+AnimSpeed.Evaluate(0);}
		}else{
			DoubleSpeed=speed;
		}

		//Rotate
		if(PuskReserve==1){
			if(ReservRotate>0){
				gameObject.transform.Rotate(0,0,RotateSpeed);
				ReservRotate=ReservRotate-RotateSpeed;
			}else{PuskReserve=0;}
		}

	}




}
