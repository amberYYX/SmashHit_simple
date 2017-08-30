#pragma strict


var FonRend:boolean=false;
var Pause:boolean=false;
var Continie:boolean=false;
var DefaultGo:boolean=false;
var Cam:GameObject;
var TableRT:RectTransform;
var TableAll:GameObject;
var PauseRT:RectTransform;
var ReloadFon1GO:GameObject;
var ReloadFon2GO:GameObject;
var NameLevel:String;
var PauseLoad:AudioClip;
private var PitchAudio:float;

private var NoLoop:int=0;

var ColliderNoTap:GameObject;

var Music:GameObject;
var Vol:float;

private var NoLoopMus:boolean=true;

function Start(){
PitchAudio=Music.GetComponent.<AudioSource>().pitch;
}


function OnMouseDown(){
if(Pause){
if(TableRT.GetComponent.<UI.Image>().fillAmount<0.1){
if(NoLoop==0){
NoLoop=1;
//Cam.layer=2;
TableAll.SetActive(true);
GetComponent.<AudioSource>().PlayOneShot(PauseLoad);
ColliderNoTap.SetActive(true);
}
}
}
if(Continie){
if(NoLoop==0){
Time.timeScale=1;
NoLoop=-1;
GetComponent.<AudioSource>().PlayOneShot(PauseLoad);
ColliderNoTap.SetActive(false);
}
}

if(DefaultGo){
if(NoLoop==0){
Time.timeScale=1;
NoLoop=2;
GetComponent.<AudioSource>().PlayOneShot(PauseLoad);
}
}
}

function Update(){
if(Pause){
if(NoLoopMus){
if(Music.GetComponent.<AudioSource>().volume<Vol){
Music.GetComponent.<AudioSource>().volume=Music.GetComponent.<AudioSource>().volume+0.01;
}else{NoLoopMus=false;}
}
}
}


function FixedUpdate(){

if(FonRend){
if(ReloadFon2GO.GetComponent.<UI.Image>().color.a>0){
ReloadFon2GO.GetComponent.<UI.Image>().color.a=ReloadFon2GO.GetComponent.<UI.Image>().color.a-0.1;
}else{
if(ReloadFon1GO.GetComponent.<UI.Image>().color.a>0){
ReloadFon1GO.GetComponent.<UI.Image>().color.a=ReloadFon1GO.GetComponent.<UI.Image>().color.a-0.1;
}else{
FonRend=false;
ReloadFon1GO.SetActive(false);
ReloadFon2GO.SetActive(false);
}
}
}

if(NoLoop==1){
if(TableRT.GetComponent.<UI.Image>().color.a<1){
PauseRT.GetComponent.<UI.Image>().color.a=PauseRT.GetComponent.<UI.Image>().color.a-0.1;
TableRT.GetComponent.<UI.Image>().color.a=TableRT.GetComponent.<UI.Image>().color.a+0.1;
TableRT.GetComponent.<UI.Image>().fillAmount=TableRT.GetComponent.<UI.Image>().fillAmount+0.1;
}else{
NoLoop=0;
Music.GetComponent.<AudioSource>().pitch=0;
Time.timeScale=0;
}
}

if(NoLoop==-1){
if(TableRT.GetComponent.<UI.Image>().color.a>0){
PauseRT.GetComponent.<UI.Image>().color.a=PauseRT.GetComponent.<UI.Image>().color.a+0.1;
TableRT.GetComponent.<UI.Image>().color.a=TableRT.GetComponent.<UI.Image>().color.a-0.1;
TableRT.GetComponent.<UI.Image>().fillAmount=TableRT.GetComponent.<UI.Image>().fillAmount-0.1;
}else{
NoLoop=0;
TableAll.SetActive(false);
Music.GetComponent.<AudioSource>().pitch=PitchAudio;
}
}

if(NoLoop==2){
ReloadFon1GO.SetActive(true);
ReloadFon2GO.SetActive(true);
NoLoop=-2;
}

if(NoLoop==-2){
if(TableRT.GetComponent.<UI.Image>().color.a>0){
TableRT.GetComponent.<UI.Image>().color.a=TableRT.GetComponent.<UI.Image>().color.a-0.1;
TableRT.GetComponent.<UI.Image>().fillAmount=TableRT.GetComponent.<UI.Image>().fillAmount-0.1;
}
if(ReloadFon1GO.GetComponent.<UI.Image>().color.a<1){
ReloadFon1GO.GetComponent.<UI.Image>().color.a=ReloadFon1GO.GetComponent.<UI.Image>().color.a+0.1;
}else{
if(ReloadFon2GO.GetComponent.<UI.Image>().color.a<1){
ReloadFon2GO.GetComponent.<UI.Image>().color.a=ReloadFon2GO.GetComponent.<UI.Image>().color.a+0.1;
}else{
NoLoop=0;
Application.LoadLevel(NameLevel.ToString());
}
}
}
}