#pragma strict


var BlocCollision:boolean=false;
var ConParent:GameObject;

var ForceAdd:boolean=false;
var ForceVel:Vector3;
var ForceRot:Vector3;

var ExplosionAdd:boolean=false;
var Explosion:GameObject;
var FxAdd:boolean=false;
var Fx:GameObject;


var RotationAdd:boolean=false;
var RotationSpeed:Vector3;

var AudioList:AudioClip[];
var OncePlay:int;

var TakeAdd:boolean=false;
var TakeVel:Vector3;
var TakeRot:Vector3;
var TakeEndPosition:float;
var Cam:GameObject;

private var end:boolean=false;

function Start(){
if(FxAdd){Fx.SetActive(true);}
}


function OnCollisionEnter(other: Collision){
if(BlocCollision){
if(other.gameObject.tag=="Badly"){
DoingAll();
}
}
}

function OnMouseDown(){
if(!BlocCollision){
DoingAll();
}
}

function DoingAll(){
gameObject.GetComponent.<AudioSource>().volume=0.3;
if(gameObject.GetComponent.<Animation>()){gameObject.GetComponent.<Animation>().Stop();}
if(ConParent.GetComponent.<Animation>()){ConParent.GetComponent.<Animation>().Stop();}
gameObject.GetComponent.<Rigidbody>().isKinematic = false;
RotationAdd=false;
if(TakeAdd){
gameObject.GetComponent.<Rigidbody>().velocity = 
gameObject.GetComponent.<Rigidbody>().velocity + TakeVel;
gameObject.GetComponent.<AudioSource>().PlayOneShot(AudioList[OncePlay]);
}
if(ForceAdd){
gameObject.GetComponent.<Rigidbody>().velocity = ForceVel;
gameObject.GetComponent.<Rigidbody>().angularVelocity = ForceRot;
ForceAdd=false;
gameObject.GetComponent.<AudioSource>().PlayOneShot(AudioList[OncePlay]);
}
if(ExplosionAdd){
Explosion.SetActive(true);
if(FxAdd){Fx.SetActive(false);}
ExplosionAdd=false;
OncePlay=0;
gameObject.GetComponent.<AudioSource>().PlayOneShot(AudioList[OncePlay]);
}
}


function Update(){
if(RotationAdd){gameObject.transform.Rotate(RotationSpeed);}
if(TakeAdd){
if(!end){
if(Cam.transform.position.z>TakeEndPosition){end=true;TakeAdd=false;
gameObject.GetComponent.<Rigidbody>().constraints = RigidbodyConstraints.None;
gameObject.GetComponent.<Rigidbody>().angularVelocity = TakeRot;
if(FxAdd){Fx.SetActive(false);Explosion.SetActive(true);
gameObject.GetComponent.<AudioSource>().PlayOneShot(AudioList[2]);}}
}
}
}