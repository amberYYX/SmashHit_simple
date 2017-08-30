#pragma strict

var ThisRotation:boolean=false;
var Cam:GameObject;
var Angle:int;
var AngleSpeed:float;

function OnTriggerEnter(other:Collider){
if(other.gameObject.tag=="Camera"){
if(ThisRotation){
Cam.GetComponent.<CamAnim>().ReservRotate=Angle;
Cam.GetComponent.<CamAnim>().RotateSpeed=AngleSpeed;
Cam.GetComponent.<CamAnim>().Rotate();
}
}
}