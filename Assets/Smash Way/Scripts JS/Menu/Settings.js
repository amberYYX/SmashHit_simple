#pragma strict

var ThisRuleSetting:boolean=false;
var BarsArray:GameObject[];
var SettAnim:AnimationClip[];
var BarAnim:AnimationClip[];
private var NonTapTap:int=1;

var ThisSettingGraphics:boolean=false;
var SpriteArray:Sprite[];

var Face:RectTransform;

private var GraphicsSave:int=0;
private var MiniBat:int=0;

function Awake(){
if(ThisSettingGraphics){
if(PlayerPrefs.HasKey("GraphicsSave")){
GraphicsSave=PlayerPrefs.GetInt("GraphicsSave");
QualitySett();
}else{
GraphicsSave=2;
PlayerPrefs.SetInt("GraphicsSave",GraphicsSave);
}
}
}


function OnDown(){
if(ThisRuleSetting){
if(NonTapTap==1){
NonTapTap=2;
gameObject.GetComponent.<Animation>().Play(SettAnim[0].name);
BarsArray[0].GetComponent.<Animation>().Play(BarAnim[0].name);
BarsArray[1].GetComponent.<Animation>().Play(BarAnim[1].name);
ResetTime();
}
if(NonTapTap==-1){
NonTapTap=-2;
gameObject.GetComponent.<Animation>().Play(SettAnim[1].name);
BarsArray[0].GetComponent.<Animation>().Play(BarAnim[1].name);
BarsArray[1].GetComponent.<Animation>().Play(BarAnim[0].name);
ResetTime();
}
}
if(ThisSettingGraphics){
if(MiniBat==0){
if(GraphicsSave==3){MiniBat=3;}
if(GraphicsSave==2){MiniBat=2;}
if(GraphicsSave==1){MiniBat=1;}
}
}
}

function ResetTime(){
yield WaitForSeconds(BarAnim[0].length);
if(NonTapTap==2){NonTapTap=-1;}else{NonTapTap=1;}
}


function Update(){
if(ThisSettingGraphics){
if(MiniBat==1){
if(Face.GetComponent.<UI.Image>().color.a>0){
Face.GetComponent.<UI.Image>().color.a=Face.GetComponent.<UI.Image>().color.a-0.1;
}else{
MiniBat=11;
GraphicsSave=2;
QualitySettings.SetQualityLevel(2);
gameObject.GetComponent.<UI.Image>().sprite=SpriteArray[1];
PlayerPrefs.SetInt("GraphicsSave",GraphicsSave);
}
}
if(MiniBat==11){
if(Face.GetComponent.<UI.Image>().color.a<1){
Face.GetComponent.<UI.Image>().color.a=Face.GetComponent.<UI.Image>().color.a+0.1;
}else{MiniBat=0;}
}

if(MiniBat==2){
if(Face.GetComponent.<UI.Image>().color.a>0){
Face.GetComponent.<UI.Image>().color.a=Face.GetComponent.<UI.Image>().color.a-0.1;
}else{
MiniBat=22;
GraphicsSave=3;
QualitySettings.SetQualityLevel(3);
gameObject.GetComponent.<UI.Image>().sprite=SpriteArray[2];
PlayerPrefs.SetInt("GraphicsSave",GraphicsSave);
}
}
if(MiniBat==22){
if(Face.GetComponent.<UI.Image>().color.a<1){
Face.GetComponent.<UI.Image>().color.a=Face.GetComponent.<UI.Image>().color.a+0.1;
}else{MiniBat=0;}
}

if(MiniBat==3){
if(Face.GetComponent.<UI.Image>().color.a>0){
Face.GetComponent.<UI.Image>().color.a=Face.GetComponent.<UI.Image>().color.a-0.1;
}else{
MiniBat=33;
GraphicsSave=1;
QualitySettings.SetQualityLevel(1);
gameObject.GetComponent.<UI.Image>().sprite=SpriteArray[0];
PlayerPrefs.SetInt("GraphicsSave",GraphicsSave);
}
}
if(MiniBat==33){
if(Face.GetComponent.<UI.Image>().color.a<1){
Face.GetComponent.<UI.Image>().color.a=Face.GetComponent.<UI.Image>().color.a+0.1;
}else{MiniBat=0;}
}
}
}



function QualitySett(){
if(GraphicsSave==1){QualitySettings.SetQualityLevel(1);
gameObject.GetComponent.<UI.Image>().sprite=SpriteArray[0];
}
if(GraphicsSave==2){QualitySettings.SetQualityLevel(2);
gameObject.GetComponent.<UI.Image>().sprite=SpriteArray[1];
}
if(GraphicsSave==3){QualitySettings.SetQualityLevel(3);
gameObject.GetComponent.<UI.Image>().sprite=SpriteArray[2];
}
}