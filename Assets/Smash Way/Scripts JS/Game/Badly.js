#pragma strict

var RedFonGO:GameObject;
var SoundBadly:AudioClip;

var BadlyNaw:int=0;

function OnTriggerEnter(other:Collider){
if(other.gameObject.tag=="Badly"){
if(BadlyNaw==0){
GetComponent.<AudioSource>().PlayOneShot(SoundBadly);
GetComponent.<SystemKilling>().BadlySet();
RedFonGO.GetComponent.<UI.Image>().color.a=1;
Shaking();
RedFonGO.SetActive(true);
BadlyNaw=1;
}
}
}

function FixedUpdate(){
if(BadlyNaw==1){
if(RedFonGO.GetComponent.<UI.Image>().color.a>0){
RedFonGO.GetComponent.<UI.Image>().color.a=RedFonGO.GetComponent.<UI.Image>().color.a-0.02;
}else{BadlyNaw=0;RedFonGO.SetActive(false);}
}
}

function Shaking(){
gameObject.transform.Rotate(0,0,1.2);
yield WaitForSeconds(0.05);
gameObject.transform.Rotate(0,0,-1.2);
yield WaitForSeconds(0.05);
gameObject.transform.Rotate(0,0,1.4);
yield WaitForSeconds(0.05);
gameObject.transform.Rotate(0,0,-1.4);
yield WaitForSeconds(0.05);
gameObject.transform.Rotate(0,0,1.2);
yield WaitForSeconds(0.05);
gameObject.transform.Rotate(0,0,-1.2);
yield WaitForSeconds(0.05);
gameObject.transform.Rotate(0,0,1);
yield WaitForSeconds(0.05);
gameObject.transform.Rotate(0,0,-1);
yield WaitForSeconds(0.05);
gameObject.transform.Rotate(0,0,-0.8);
yield WaitForSeconds(0.05);
gameObject.transform.Rotate(0,0,0.8);
yield WaitForSeconds(0.05);
gameObject.transform.Rotate(0,0,0.6);
yield WaitForSeconds(0.05);
gameObject.transform.Rotate(0,0,-0.6);
yield WaitForSeconds(0.05);
gameObject.transform.Rotate(0,0,-0.4);
yield WaitForSeconds(0.05);
gameObject.transform.Rotate(0,0,0.4);
yield WaitForSeconds(0.05);
gameObject.transform.Rotate(0,0,0.2);
yield WaitForSeconds(0.05);
gameObject.transform.Rotate(0,0,-0.2);
}
