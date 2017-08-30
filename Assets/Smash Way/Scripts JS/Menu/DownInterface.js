#pragma strict

var ThisSound:boolean=false;
var ThisDistance:boolean=false;
var RectSound:RectTransform;
var SpriteSyes:Sprite;
var SpriteSno:Sprite;
private var SoundActive:int=0;

var ScoreArray:int;
private var ToolkingArray:int=0;
private var AssembleDist:int;
var ArrayDist:String[];
var Distance:RectTransform;

function Start(){
if(ThisSound){
if(PlayerPrefs.HasKey("SoundActive")){
SoundActive=PlayerPrefs.GetInt("SoundActive");
}else{SoundActive=1;}
DoingSound();
}
if(ThisDistance){DoingDistance();}
}

function OnMouseDown(){
if(ThisSound){
if(SoundActive==0){SoundActive=1;DoingSound();
}else{SoundActive=0;DoingSound();}
}
}



function DoingSound(){
if(SoundActive==0){AudioListener.pause=true;
RectSound.GetComponent.<UI.Image>().sprite=SpriteSno;}
if(SoundActive==1){AudioListener.pause=false;
RectSound.GetComponent.<UI.Image>().sprite=SpriteSyes;}
PlayerPrefs.SetInt("SoundActive",SoundActive);
}

function DoingDistance(){
while(ToolkingArray<ScoreArray){
AssembleDist=AssembleDist+PlayerPrefs.GetInt(ArrayDist[ToolkingArray].ToString());
ToolkingArray++;
}
Distance.GetComponent.<UI.Text>().text=AssembleDist.ToString();
PlayerPrefs.SetInt("AllDistance",AssembleDist);
}