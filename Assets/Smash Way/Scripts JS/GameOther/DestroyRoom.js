#pragma strict

var ThisRoom:GameObject;
var NextRoom:GameObject;
var Last:boolean=false;

function OnTriggerEnter(other:Collider){
if(other.gameObject.tag=="Camera"){
Destroy(ThisRoom);
if(!Last){NextRoom.SetActive(true);}
}
}