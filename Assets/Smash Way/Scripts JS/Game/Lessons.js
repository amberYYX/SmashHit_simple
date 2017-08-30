#pragma strict


var LinePGO:GameObject;
var TextPGO:GameObject;
var TextTGO:GameObject;
var TextGGO:GameObject;

private var Process:int=0;

var Message:int=0;
var MessageBox:int=0;

var TimeTapBox:int=0;

var TapBox:boolean=false;
var SendCall:GameObject;

function Start () {
if(!TapBox){
yield WaitForSeconds(3);
LinePGO.SetActive(true);
TextPGO.SetActive(true);
Process=1;
yield WaitForSeconds(TimeTapBox);
TextTGO.SetActive(true);
Process=3;
}
}


function Update () {
if(!TapBox){
if(Process==1){
if(LinePGO.GetComponent.<UI.Image>().color.a<1){
LinePGO.GetComponent.<UI.Image>().color.a=LinePGO.GetComponent.<UI.Image>().color.a+0.05;
TextPGO.GetComponent.<UI.Text>().color.a=TextPGO.GetComponent.<UI.Text>().color.a+0.05;
}else{if(Message>=2){Process=0;TimePause4();}}
}

if(Process==2){
if(LinePGO.GetComponent.<UI.Image>().color.a>0){
LinePGO.GetComponent.<UI.Image>().color.a=LinePGO.GetComponent.<UI.Image>().color.a-0.05;
TextPGO.GetComponent.<UI.Text>().color.a=TextPGO.GetComponent.<UI.Text>().color.a-0.05;
}else{TimePause();Process=0;}
}

if(Process==3){
if(LinePGO.GetComponent.<UI.Image>().color.a<1){
LinePGO.GetComponent.<UI.Image>().color.a=LinePGO.GetComponent.<UI.Image>().color.a+0.05;
TextTGO.GetComponent.<UI.Text>().color.a=TextTGO.GetComponent.<UI.Text>().color.a+0.05;
}else{Process=4;}
}

if(Process==4){
if(MessageBox>=1){Process=6;}
}


if(Process==6){
if(TextTGO.GetComponent.<UI.Text>().color.a>0){
TextTGO.GetComponent.<UI.Text>().color.a=TextTGO.GetComponent.<UI.Text>().color.a-0.05;
LinePGO.GetComponent.<UI.Image>().color.a=LinePGO.GetComponent.<UI.Image>().color.a-0.05;
}else{Process=0;
TimePause3();
TextTGO.SetActive(false);
TextGGO.SetActive(true);
}
}

if(Process==7){
if(TextGGO.GetComponent.<UI.Text>().color.a<1){
TextGGO.GetComponent.<UI.Text>().color.a=TextGGO.GetComponent.<UI.Text>().color.a+0.05;
LinePGO.GetComponent.<UI.Image>().color.a=LinePGO.GetComponent.<UI.Image>().color.a+0.05;
}else{Process=0; TimePause2();}
}

if(Process==8){
if(TextGGO.GetComponent.<UI.Text>().color.a>0){
TextGGO.GetComponent.<UI.Text>().color.a=TextGGO.GetComponent.<UI.Text>().color.a-0.05;
LinePGO.GetComponent.<UI.Image>().color.a=LinePGO.GetComponent.<UI.Image>().color.a-0.05;
}else{Process=0; 
TextGGO.SetActive(false);
LinePGO.SetActive(false);
gameObject.SetActive(false);
}
}
}
}


function TimePause(){
TextPGO.SetActive(false);
}

function TimePause2(){
yield WaitForSeconds(1);
Process=8;
}

function TimePause3(){
yield WaitForSeconds(5);
Process=7;
}

function TimePause4(){
yield WaitForSeconds(2);
Process=2;
}

function OnTouchDown(){
if(TapBox){
SendCall.GetComponent.<Lessons>().MessageBox++;
}
}

function OnMouseDown(){
if(TapBox){
SendCall.GetComponent.<Lessons>().MessageBox++;
}
}