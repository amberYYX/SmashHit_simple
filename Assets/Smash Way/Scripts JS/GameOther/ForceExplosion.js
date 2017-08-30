#pragma strict

var Explosion:GameObject;
var Effector:GameObject;
var AudioList:AudioClip;
private var Stop:boolean=false;

function OnMouseDown(){
OnTouchDown();
}


function OnTouchDown(){
if(!Stop){
Effector.SetActive(false);
gameObject.GetComponent.<Rigidbody>().isKinematic=false;
Explosion.SetActive(true);
if(gameObject.GetComponent.<Animation>()){gameObject.GetComponent.<Animation>().enabled=false;}
gameObject.GetComponent.<AudioSource>().PlayOneShot(AudioList);
Stop=true;
}
}