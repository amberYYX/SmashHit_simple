#pragma strict

var ObjectCam:GameObject;
var ObjectRooms:GameObject;
var DeleteFloat:float;
var FinishSend:GameObject;

function OnTriggerEnter(other:Collider){
if(other.gameObject.tag=="Camera"){
ObjectRooms.transform.position.z=ObjectRooms.transform.position.z-DeleteFloat;
ObjectCam.transform.position.z=ObjectCam.transform.position.z-DeleteFloat;
FinishSend.GetComponent.<Finish>().ResetFloatAdd=DeleteFloat;
ObjectCam.GetComponent.<SystemKilling>().ResetFloatAdd=DeleteFloat;
ObjectCam.GetComponent.<CamAnim>().OtherDistance=DeleteFloat;
Destroy(gameObject);
}
}