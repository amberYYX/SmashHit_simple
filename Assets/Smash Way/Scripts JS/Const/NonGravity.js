#pragma strict



var ForceAdd:boolean=false;
var ForceVel:Vector3;
var ForceRot:Vector3;

var Sound:AudioClip;
var ForceVelDoing:Vector3;
var ForceRotDoing:Vector3;
private var OneDoing:boolean=false;


function Start () {
if(ForceAdd){
gameObject.GetComponent.<Rigidbody>().isKinematic = false;
gameObject.GetComponent.<Rigidbody>().velocity = ForceVel;
gameObject.GetComponent.<Rigidbody>().angularVelocity = ForceRot;
ForceAdd=false;
}
}


function OnTouchDown(){
Doing();
}

function OnMouseDown(){
Doing();
}

function Doing(){
if(!OneDoing){
OneDoing=true;
gameObject.GetComponent.<Rigidbody>().isKinematic = false;
gameObject.GetComponent.<Rigidbody>().velocity =
gameObject.GetComponent.<Rigidbody>().velocity + ForceVelDoing;
gameObject.GetComponent.<Rigidbody>().angularVelocity = 
gameObject.GetComponent.<Rigidbody>().angularVelocity + ForceRotDoing;
if(Sound){gameObject.GetComponent.<AudioSource>().PlayOneShot(Sound);}
}
}