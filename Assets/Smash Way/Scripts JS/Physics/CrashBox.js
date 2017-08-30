#pragma strict

var ExplosionNoCollider:boolean=false;
var NoRotationRandom:boolean=false;

var Effect_to:GameObject;
var Effect_after:GameObject;
var PrefabShards:GameObject;
var AudioSound:AudioClip[];
var AudioSoundNoGravity:AudioClip[];
private var LoopNon:boolean=true;

function Start(){
if(!NoRotationRandom){
gameObject.transform.Rotate(0,0,Random.Range(0,3)*90);
}
}

function OnCollisionEnter(other: Collision){
if(!ExplosionNoCollider){
if(other.gameObject.tag=="Badly"){
DoingAll();
}
}
}


function OnMouseDown(){
if(ExplosionNoCollider){
DoingAll();
}
}


function DoingAll(){
if(LoopNon){
if(Physics.gravity.y>1||Physics.gravity.y<-1){
gameObject.GetComponent.<AudioSource>().PlayOneShot(AudioSound[Random.Range(0,AudioSound.Length)]);
}
if(Physics.gravity.y<1&&Physics.gravity.y>-1){
gameObject.GetComponent.<AudioSource>().PlayOneShot(AudioSoundNoGravity[Random.Range(0,AudioSoundNoGravity.Length)]);
}
if(gameObject.GetComponent.<Animation>()){gameObject.GetComponent.<Animation>().Stop();}

Effect_to.SetActive(false);
Effect_after.SetActive(true);
gameObject.GetComponent.<Rigidbody>().isKinematic=true;
gameObject.GetComponent.<BoxCollider>().enabled=false;
gameObject.GetComponent.<MeshRenderer>().enabled=false;
PrefabShards.SetActive(true);
LoopNon=false;
}
}
