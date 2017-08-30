#pragma strict

//System Counting and Update
var WayPercent:RectTransform;
var MaxDistance:float;
private var Result:int;
private var ResultSave:int;


var LineReserve:RectTransform;

private var ReserveFloat:float=100; // 100 - original
var ReserveAdd:float;
var Convertation:float;
private var SpeedDown:float;

var CircleStats:RectTransform;
private var AddActive:int=0;

var BadlyPointGO:GameObject;
private var NoLoopPoint:int=0;


private var EndReserve:boolean=false;
private var CycleBadly:int=0;


var BadlyFonGO:GameObject;



var PauseGO:GameObject;
var TapResetGO:GameObject;
var TextResetGO:GameObject;


var FonScorGO:GameObject;
var TextScorGO:GameObject;

private var CycleGameOver:int=0;
private var ScoreNaw:int;

//var Sound_Click:AudioClip;
var Sound_GameOver:AudioClip;

var NoCollision:GameObject;
var AssembleName:String;
var Music:GameObject;
var Lessons:GameObject;
var ResetFloatAdd:float=0;

function BadlySet(){
ReserveFloat=ReserveFloat-40;
gameObject.GetComponent.<Stars>().Hits--;
}



function AddReserv(){
ReserveFloat=ReserveFloat+ReserveAdd;
ReserveAdd=0;
if(ReserveFloat>100){ReserveFloat=100;}
AddActive=1;
}
//
//function Doing(){
//GetComponent.<AudioSource>().PlayOneShot(Sound_Click);
//RenderState();
//}


function RenderState(){
LineReserve.GetComponent.<UI.Image>().fillAmount=ReserveFloat/100;
Result = 100-(MaxDistance-gameObject.transform.position.z-ResetFloatAdd)*100/MaxDistance;
if(Result < 0){Result = 0;}
if(ResultSave!=Result){
WayPercent.GetComponent.<UI.Text>().text = Result.ToString() + "%";
ResultSave=Result;
}


if(ReserveFloat<25){
if(BadlyPointGO.activeInHierarchy==false){BadlyPointGO.SetActive(true);}
if(NoLoopPoint==0){
if(BadlyPointGO.GetComponent.<UI.Image>().color.a<1){
BadlyPointGO.GetComponent.<UI.Image>().color.a=BadlyPointGO.GetComponent.<UI.Image>().color.a+0.1;
}else{NoLoopPoint=1;}
}
if(NoLoopPoint==1){
if(BadlyPointGO.GetComponent.<UI.Image>().color.a>0){
BadlyPointGO.GetComponent.<UI.Image>().color.a=BadlyPointGO.GetComponent.<UI.Image>().color.a-0.1;
}else{NoLoopPoint=0;}
}
}else{BadlyPointGO.SetActive(false);}
}



function FixedUpdate(){
//Processed
SpeedDown=GetComponent.<CamAnim>().DoubleSpeed;
SpeedDown=SpeedDown/Convertation;
ReserveFloat=ReserveFloat-SpeedDown;
if(ReserveFloat<=0.5){EndReserve=true;CycleBadly=1;
LineReserve.GetComponent.<UI.Image>().fillAmount=0;
}

if(!EndReserve){RenderState();}

if(CycleBadly==1){
BadlyFonGO.SetActive(true);
CycleBadly=2;
}


if(CycleBadly==2){
if(BadlyFonGO.GetComponent.<UI.Image>().color.a<0.6){
BadlyFonGO.GetComponent.<UI.Image>().color.a=BadlyFonGO.GetComponent.<UI.Image>().color.a+0.3;
}else{CycleBadly=3;}
}

if(CycleBadly==3){
if(PauseGO.GetComponent.<UI.Image>().color.a>0){
PauseGO.GetComponent.<UI.Image>().color.a=PauseGO.GetComponent.<UI.Image>().color.a-0.1;
}else{
if(CycleGameOver==0){
if(Lessons){Lessons.SetActive(false);}
NoCollision.SetActive(true);
CycleGameOver=1;
GetComponent.<Badly>().BadlyNaw=2;
GetComponent.<AudioSource>().PlayOneShot(Sound_GameOver);
gameObject.GetComponent.<CamAnim>().Go=false;
PauseGO.SetActive(false);
TapResetGO.SetActive(true);
TextResetGO.SetActive(true);
FonScorGO.SetActive(true);
TextScorGO.SetActive(true);
ScoreNaw=gameObject.transform.position.z+ResetFloatAdd;
PlayerPrefs.SetInt("LastLevels",0);
TextScorGO.GetComponent.<UI.Text>().text = ScoreNaw.ToString();
if(ScoreNaw>PlayerPrefs.GetInt(AssembleName.ToString())){
PlayerPrefs.SetInt(AssembleName.ToString(),ScoreNaw);
}
gameObject.layer=2;
}
}
if(gameObject.GetComponent.<CamAnim>().speed>0.01){
gameObject.GetComponent.<CamAnim>().speed=gameObject.GetComponent.<CamAnim>().speed-0.01;
}else{
gameObject.GetComponent.<CamAnim>().enabled=false;
}
if(CycleGameOver==1){
if(TapResetGO.GetComponent.<UI.Image>().color.a<0.7){
TapResetGO.GetComponent.<UI.Image>().color.a=TapResetGO.GetComponent.<UI.Image>().color.a+0.1;
TextResetGO.GetComponent.<UI.Text>().color.a=TextResetGO.GetComponent.<UI.Text>().color.a+0.1;
}else{
if(TextScorGO.GetComponent.<UI.Text>().color.a<0.7){
TextScorGO.GetComponent.<UI.Text>().color.a=TextScorGO.GetComponent.<UI.Text>().color.a+0.02;
FonScorGO.GetComponent.<UI.Image>().color.a=FonScorGO.GetComponent.<UI.Image>().color.a+0.02;
Music.GetComponent.<AudioSource>().volume=Music.GetComponent.<AudioSource>().volume-0.02;
}else{
CycleGameOver=2;
}
}
}
}
}


function Update(){
if(AddActive==1){
CircleStats.sizeDelta.x=100;
AddActive=-1;
}
if(AddActive==-1){
if(CircleStats.sizeDelta.x>75){
CircleStats.sizeDelta.x=CircleStats.sizeDelta.x-1.5;
}else{AddActive=0;}}
}