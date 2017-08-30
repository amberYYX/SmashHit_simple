#pragma strict

var Add:GameObject;
var Effect_to:GameObject;
var Effect_after:GameObject;
var PrefabShards:GameObject;
var AudioSound:AudioClip[];
var AudioSoundNoGravity:AudioClip[];
private var LoopNon:boolean=true;
var LessonsBool:boolean=false;
var LessonsGO:GameObject;

function Start(){
gameObject.transform.Rotate(0,0,Random.Range(0,3)*90);
}

function OnMouseDown(){
Doing();
}

function Doing(){
if(LoopNon){
if(Physics.gravity.y>1||Physics.gravity.y<-1){
gameObject.GetComponent.<AudioSource>().PlayOneShot(AudioSound[Random.Range(0,AudioSound.Length)]);
}
if(Physics.gravity.y<1&&Physics.gravity.y>-1){
gameObject.GetComponent.<AudioSource>().PlayOneShot(AudioSoundNoGravity[Random.Range(0,AudioSoundNoGravity.Length)]);
}
Add.SetActive(true);
Effect_to.SetActive(false);
Effect_after.SetActive(true);
gameObject.GetComponent.<Rigidbody>().isKinematic=true;
gameObject.GetComponent.<BoxCollider>().enabled=false;
gameObject.GetComponent.<MeshRenderer>().enabled=false;
var NewShards = Instantiate(PrefabShards,gameObject.transform.position,Quaternion.identity);
NewShards.transform.parent = gameObject.transform;
LoopNon=false;
if(LessonsBool){LessonsGO.GetComponent.<Lessons>().Message++;}
}
}
