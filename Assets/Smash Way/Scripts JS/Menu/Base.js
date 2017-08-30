#pragma strict


var AssembleInt:int=0;
var ObjectAssemble:GameObject;

var TapUp:boolean=false;
var TapDown:boolean=false;
var NoLooper:boolean=true;

var Rooms:RectTransform[];

var aRight1:AnimationClip;
var aRight2:AnimationClip;

var aLeft1:AnimationClip;
var aLeft2:AnimationClip;

private var UpBlock:int=0;
private var DownBlock:int=0;

var SizeElements:int;
var SoundL:AudioClip;
var SoundR:AudioClip;

var StarsRe:String[];
var Med:RectTransform;
var MedSprites:Sprite[];
var ThisMed:int=0;

private var ThisMedReset:int=0;

var PontWay:RectTransform;

var WayObject:GameObject;
function AssembleFA(){
if(AssembleInt+1<Rooms.Length){AssembleInt++;}else{AssembleInt=0;}
}
function AssembleFD(){
if(AssembleInt>0){AssembleInt--;}else{AssembleInt=Rooms.Length-1;}
}


function Start(){
SizeElements=Rooms.Length;SizeElements--;

ThisMed=PlayerPrefs.GetInt(StarsRe[0].ToString());
if(gameObject.name!="Canvas Menu"){
Med.GetComponent.<UI.Image>().sprite=MedSprites[ThisMed];
}
}


function OnMouseDown(){
if(PontWay.GetComponent.<UI.Image>().color.a>0.9){
if(NoLooper){
NoLooper=false;
AssembleInt=ObjectAssemble.GetComponent.<Base>().AssembleInt;
if(TapUp){UpBlockF();GetComponent.<AudioSource>().PlayOneShot(SoundR);}
if(TapDown){DownBlockF();GetComponent.<AudioSource>().PlayOneShot(SoundL);}

WayObject.GetComponent.<BasisWay>().GoInNew=AssembleInt;
WayObject.GetComponent.<BasisWay>().ResetPosition();
}
}
}

function UpBlockF(){
Rooms[AssembleInt].GetComponent.<Animation>().Play (aRight2.name);
if(AssembleInt+1<Rooms.Length){AssembleInt++;}else{AssembleInt=0;}
Rooms[AssembleInt].GetComponent.<Animation>().Play (aRight1.name);
yield WaitForSeconds(0.333);

ThisMed=PlayerPrefs.GetInt(StarsRe[AssembleInt].ToString());
if(StarsRe[AssembleInt].ToString()!="Non"){
ThisMedReset=1;
}else{
ThisMedReset=-1;
}

NoLooper=true;
ObjectAssemble.GetComponent.<Base>().AssembleFA();
}

function DownBlockF(){
Rooms[AssembleInt].GetComponent.<Animation>().Play (aLeft1.name);
if(AssembleInt>0){AssembleInt--;}else{AssembleInt=Rooms.Length-1;}
Rooms[AssembleInt].GetComponent.<Animation>().Play (aLeft2.name);
yield WaitForSeconds(0.333);

ThisMed=PlayerPrefs.GetInt(StarsRe[AssembleInt].ToString());
if(StarsRe[AssembleInt].ToString()!="Non"){
ThisMedReset=1;
}else{
ThisMedReset=-1;
}

NoLooper=true;
ObjectAssemble.GetComponent.<Base>().AssembleFD();
}


function FixedUpdate(){
if(ThisMedReset==1){
if(Med.GetComponent.<UI.Image>().color.a>0){
Med.GetComponent.<UI.Image>().fillAmount=Med.GetComponent.<UI.Image>().fillAmount-0.1;
Med.GetComponent.<UI.Image>().color.a=Med.GetComponent.<UI.Image>().color.a-0.1;
}else{
ThisMedReset=2;
Med.GetComponent.<UI.Image>().sprite=MedSprites[ThisMed];
}
}

if(ThisMedReset==2){
if(Med.GetComponent.<UI.Image>().color.a<1){
Med.GetComponent.<UI.Image>().fillAmount=Med.GetComponent.<UI.Image>().fillAmount+0.1;
Med.GetComponent.<UI.Image>().color.a=Med.GetComponent.<UI.Image>().color.a+0.1;
}else{
ThisMedReset=0;
}
}

if(ThisMedReset==-1){
if(Med.GetComponent.<UI.Image>().color.a>0){
Med.GetComponent.<UI.Image>().fillAmount=Med.GetComponent.<UI.Image>().fillAmount-0.1;
Med.GetComponent.<UI.Image>().color.a=Med.GetComponent.<UI.Image>().color.a-0.1;
}else{ThisMedReset=0;}
}

}