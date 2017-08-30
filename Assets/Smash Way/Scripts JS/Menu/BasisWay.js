#pragma strict

var SpritesBase:RectTransform;
var GoInNew:float;

var PointPosition:float[];

private var Process:int=0;


function ResetPosition(){
Process=1;
}








function FixedUpdate(){
if(Process==1){
if(SpritesBase.GetComponent.<UI.Image>().color.a>0){
SpritesBase.GetComponent.<UI.Image>().color.a=SpritesBase.GetComponent.<UI.Image>().color.a-0.1;
}else{
Process=2;
SpritesBase.transform.localPosition.x=PointPosition[GoInNew];
}
}
if(Process==2){
if(SpritesBase.GetComponent.<UI.Image>().color.a<1){
SpritesBase.GetComponent.<UI.Image>().color.a=SpritesBase.GetComponent.<UI.Image>().color.a+0.1;
}else{
Process=0;
}
}
}