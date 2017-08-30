#pragma strict

var Glow:ParticleSystem;
var ScaleEnd:Vector3;
var speedScale:float;
var speedParticle:float;
private var Do:int=0;
var AddForce:Vector3;
var AddRotation:Vector3;
var Sound:AudioClip;

private var One:boolean=true;

function OnMouseDown(){
Doing();
}


function Doing(){
if(One){
Do=1;
if(gameObject.GetComponent.<Animation>()){gameObject.GetComponent.<Animation>().Stop();}
gameObject.GetComponent.<Rigidbody>().isKinematic=false;
gameObject.GetComponent.<Rigidbody>().velocity = AddForce;
gameObject.GetComponent.<Rigidbody>().angularVelocity = AddRotation;
gameObject.GetComponent.<AudioSource>().PlayOneShot(Sound);
One=false;
}
}

function FixedUpdate(){
if(Do==1){
if(gameObject.transform.localScale.x>ScaleEnd.x){
gameObject.transform.localScale.x=gameObject.transform.localScale.x-speedScale;
}
if(gameObject.transform.localScale.y>ScaleEnd.y){
gameObject.transform.localScale.y=gameObject.transform.localScale.y-speedScale;
}
if(gameObject.transform.localScale.z>ScaleEnd.z){
gameObject.transform.localScale.z=gameObject.transform.localScale.z-speedScale;
}
if(Glow.GetComponent.<ParticleSystem>().startSpeed>0){
Glow.GetComponent.<ParticleSystem>().startSpeed=Glow.GetComponent.<ParticleSystem>().startSpeed-speedParticle;
}
if(Glow.GetComponent.<ParticleSystem>().startSize>0){
Glow.GetComponent.<ParticleSystem>().startSize=Glow.GetComponent.<ParticleSystem>().startSize-speedParticle;
}
}
}
