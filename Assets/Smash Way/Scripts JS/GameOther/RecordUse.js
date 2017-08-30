#pragma strict

var FinishObj:GameObject;
private var Distance:int;
var Sprite:GameObject;

function Awake () {
Distance=PlayerPrefs.GetInt(FinishObj.GetComponent.<Finish>().AssembleName.ToString());
gameObject.transform.position.z=Distance;
if(FinishObj.GetComponent.<Finish>().NewAssembleL<=PlayerPrefs.GetInt("AssembleL")){
gameObject.SetActive(false);
}
}

function Start(){
yield WaitForSeconds(7);
Sprite.SetActive(true);
}