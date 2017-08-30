#pragma strict
@ ImageEffectOpaque

var GravityTrue:boolean=false;
var GravityFalse:boolean=false;
var GravityAnti:boolean=false;
var GravityDefault:boolean=false;
var GravityDefaultX:float;
var GravityDefaultY:float;
var GravityDefaultZ:float;
//var Cam:GameObject;


function Awake () {
if(GravityTrue){Physics.gravity.y=-9.81;Physics.gravity.x=0;Physics.gravity.z=0;}
if(GravityFalse){Physics.gravity.y=0;Physics.gravity.x=0;Physics.gravity.z=0;}
if(GravityAnti){Physics.gravity.y=9.81;Physics.gravity.x=0;Physics.gravity.z=0;}
if(GravityDefault){
Physics.gravity.x=GravityDefaultX;
Physics.gravity.y=GravityDefaultY;
Physics.gravity.z=GravityDefaultZ;
}
}
