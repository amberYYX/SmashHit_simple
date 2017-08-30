#pragma strict

var Med:RectTransform;
var Stars0:Sprite;
var Stars1:Sprite;
var Stars2:Sprite;
var Stars3:Sprite;


var Hits:int=5;//=5
var ReitStars:String;
private var GetHits:int;

private var PuskProcess:int=0;

function Start(){
if(PlayerPrefs.HasKey(ReitStars.ToString())){
GetHits=PlayerPrefs.GetInt(ReitStars.ToString());
}else{GetHits=0;}


}


function FinishCall(){
if(Hits<1){Hits=0;}
if(Hits==2||Hits==1){Hits=1;}
if(Hits==4||Hits==3){Hits=2;}
if(Hits>=5){Hits=3;}

if(GetHits<Hits){
PlayerPrefs.SetInt(ReitStars.ToString(),Hits);
}
if(Hits==3){
Med.GetComponent.<UI.Image>().sprite=Stars3;
}
if(Hits==2){
Med.GetComponent.<UI.Image>().sprite=Stars2;
}
if(Hits==1){
Med.GetComponent.<UI.Image>().sprite=Stars1;
}
if(Hits==0){
Med.GetComponent.<UI.Image>().sprite=Stars0;
}
PuskProcess=1;
}

function FixedUpdate(){
if(PuskProcess==1){
 if(Med.GetComponent.<UI.Image>().fillAmount<1){
	Med.GetComponent.<UI.Image>().fillAmount=Med.GetComponent.<UI.Image>().fillAmount+0.05;
	Med.GetComponent.<UI.Image>().color.a=Med.GetComponent.<UI.Image>().color.a+0.05;
   }else{
   	PuskProcess=0;
   }
  }
}