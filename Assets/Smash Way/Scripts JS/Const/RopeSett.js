#pragma strict

var Rope:GameObject;
var LineRope:LineRenderer;
var ArrayPoint:GameObject[];
var AddForce:Vector3;
var Sound:AudioClip;
var OneForce:boolean=false;
function Start(){
Rope.SetActive(true);
}


function OnMouseDown(){
Doing();
}

function Doing(){
gameObject.GetComponent.<AudioSource>().PlayOneShot(Sound);
if(!OneForce){
if(gameObject.transform.localPosition.z<0){
gameObject.GetComponent.<Rigidbody>().velocity = 
gameObject.GetComponent.<Rigidbody>().velocity - AddForce;
}else{
gameObject.GetComponent.<Rigidbody>().velocity = 
gameObject.GetComponent.<Rigidbody>().velocity + AddForce;
}
}else{
gameObject.GetComponent.<Rigidbody>().velocity = 
gameObject.GetComponent.<Rigidbody>().velocity + AddForce;
}
}

function Update(){
LineRope.SetPosition(0,ArrayPoint[0].transform.position);
LineRope.SetPosition(1,ArrayPoint[1].transform.position);
LineRope.SetPosition(2,ArrayPoint[2].transform.position);
LineRope.SetPosition(3,ArrayPoint[3].transform.position);
LineRope.SetPosition(4,ArrayPoint[4].transform.position);
LineRope.SetPosition(5,ArrayPoint[5].transform.position);
LineRope.SetPosition(6,ArrayPoint[6].transform.position);
LineRope.SetPosition(7,ArrayPoint[7].transform.position);
LineRope.SetPosition(8,ArrayPoint[8].transform.position);
LineRope.SetPosition(9,ArrayPoint[9].transform.position);
LineRope.SetPosition(10,ArrayPoint[10].transform.position);
}