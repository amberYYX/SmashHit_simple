#pragma strict

var Music:GameObject;
var Fon:RectTransform;
private var Stop:boolean=false;

function Start () {

}

function Update(){
if(!Stop){
if(Music.GetComponent.<AudioSource>().volume<1){
Music.GetComponent.<AudioSource>().volume=Music.GetComponent.<AudioSource>().volume+0.02;
Fon.GetComponent.<UI.Image>().color.a=Fon.GetComponent.<UI.Image>().color.a-0.02;
}else{Stop=true;gameObject.SetActive(false);}
}
}