#pragma strict


var AnimNew:boolean=false;
var AnimPlay:AnimationClip;
var ObjParent:GameObject;
var Sound:AudioClip;

private var One:boolean=true;

function OnMouseDown(){
Doing();
}

function Doing(){
if(One){
if(gameObject.GetComponent.<Animation>()){gameObject.GetComponent.<Animation>().Stop();}
gameObject.GetComponent.<AudioSource>().PlayOneShot(Sound);
if(AnimNew){
ObjParent.GetComponent.<Animation>().Play(AnimPlay.name);
}
One=false;
}
}