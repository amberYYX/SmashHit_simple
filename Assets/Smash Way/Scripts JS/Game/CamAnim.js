#pragma strict

var speed:float;//max
var DoubleSpeed:float;
private var EndDistance:float;
private var Cof:float;
var OtherDistance:float; 
var AnimSpeed:AnimationCurve;
var Go:boolean=false;

var ReservRotate:float;
var RotateSpeed:float;
private var PuskReserve:int=0;



function Start(){
EndDistance=gameObject.GetComponent.<SystemKilling>().MaxDistance;
}



function Rotate(){
if(PuskReserve==0){
PuskReserve=1;
}
}

function FixedUpdate () {
gameObject.transform.position.z=gameObject.transform.position.z+DoubleSpeed;
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



