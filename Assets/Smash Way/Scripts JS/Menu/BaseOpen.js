#pragma strict

var ThisBase:boolean=false;
var Levels:RectTransform[];
var OpenLevels:Sprite[];
var BlokLevels:Sprite[];
var LevelsList:int;
var LevelsListName:String[];
private var AssembleL:int=0;
private var SyclesNaw:int=0;
private var SyclesOpen:boolean=false;

var MusicPlay:GameObject;
var Fon2:RectTransform;
var Fon2GO:GameObject;
private var TimeDown:boolean=false;
var Loading:GameObject;
var Sound:AudioClip;

private var Stop:boolean=false;

function Start(){
if(ThisBase){
if(PlayerPrefs.HasKey("AssembleL")){
AssembleL=PlayerPrefs.GetInt("AssembleL");
}else{
PlayerPrefs.SetInt("AssembleL",AssembleL);
}
SyclesOpen=true;
}
}
function Update(){
if(SyclesOpen){
if(SyclesNaw<Levels.Length){
if(AssembleL>=SyclesNaw){Levels[SyclesNaw].GetComponent.<UI.Image>().sprite=OpenLevels[SyclesNaw];}
else{Levels[SyclesNaw].GetComponent.<UI.Image>().sprite=BlokLevels[SyclesNaw];}
SyclesNaw++;
}else{SyclesOpen=false;}
}
}

function OnMouseDown(){
AssembleL=PlayerPrefs.GetInt("AssembleL");
if(AssembleL>=LevelsList){
TimeDown=true;
Loading.SetActive(true);
Fon2GO.SetActive(true);
GetComponent.<AudioSource>().PlayOneShot(Sound);
}
}

function FixedUpdate(){
if(TimeDown){
if(Fon2.GetComponent.<UI.Image>().color.a<1){
MusicPlay.GetComponent.<AudioSource>().volume=MusicPlay.GetComponent.<AudioSource>().volume-0.02;
Fon2.GetComponent.<UI.Image>().color.a=Fon2.GetComponent.<UI.Image>().color.a+0.02;
}else{TimeDown=false;
Application.LoadLevel(LevelsListName[LevelsList].ToString());
}
}
}
