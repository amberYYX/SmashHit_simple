#pragma strict

var Cam_Object:GameObject;
var Distance:float;
//var AudAlvl:AudioClip;
private var Rest:int=0;

function Search(){
yield WaitForSeconds(2);
if(gameObject.transform.position.z<Cam_Object.transform.position.z-Distance){
Destroy(gameObject);
}else{Rest=0;}
}

function Update(){
if(Rest==0){
Rest=1;
Search();
}
}
