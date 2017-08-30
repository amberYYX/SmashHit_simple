#pragma strict

var CamObject:GameObject;
var EndFon:GameObject;
var PauseButton:GameObject;
var Fon1:GameObject;
var Fon2:GameObject;

private var process:int=0;
var ReserveDist:float;
private var Speed:float;

var Table:RectTransform;
var TableAll:GameObject;
var Salut:GameObject;
var Music:GameObject;
var NewAssembleL:int=0;
var AssembleName:String;
var ResetFloatAdd:float=0;

private var DeltaVolume:float;


function OnTriggerEnter(other:Collider){
if(other.gameObject.tag=="Camera"){
if(EndFon.activeInHierarchy==false){
CamObject.GetComponent.<SystemKilling>().enabled=false;
CamObject.GetComponent.<CamAnim>().enabled=false;
PauseButton.SetActive(false);
Fon1.SetActive(false);
Fon2.SetActive(false);
process=1;

if(PlayerPrefs.GetInt("AssembleL")<NewAssembleL){
PlayerPrefs.SetInt("AssembleL",NewAssembleL);
}
var Dis:int;
Dis=CamObject.transform.position.z+ResetFloatAdd;
PlayerPrefs.SetInt(AssembleName.ToString(),Dis);
DeltaVolume=1-Music.GetComponent.<AudioSource>().volume;
}
}
}

private var Dist:float;

function Start(){
Dist=ReserveDist-gameObject.transform.position.z;
}

function FixedUpdate(){
//Music

if(process==1){
if(Music.GetComponent.<AudioSource>().volume>0){
Music.GetComponent.<AudioSource>().volume=
(ReserveDist-CamObject.transform.position.z-ResetFloatAdd)/(ReserveDist-gameObject.transform.position.z-ResetFloatAdd)-DeltaVolume;
}
//Move
if(CamObject.transform.position.z+ResetFloatAdd<ReserveDist){
Speed=((100-(CamObject.transform.position.z-gameObject.transform.position.z)*100/Dist)/100);
CamObject.transform.position.z=CamObject.transform.position.z+Speed;
}

if(CamObject.transform.position.z+1.5+ResetFloatAdd>ReserveDist){
Salut.SetActive(true);
TableAll.SetActive(true);
process=2;
}
}

if(process==2){
if(Table.GetComponent.<UI.Image>().color.a<1){
Table.GetComponent.<UI.Image>().color.a=Table.GetComponent.<UI.Image>().color.a+0.05;
Table.GetComponent.<UI.Image>().fillAmount=Table.GetComponent.<UI.Image>().fillAmount+0.05;
}else{process=3;
CamObject.GetComponent.<Stars>().FinishCall();
}
}
}
