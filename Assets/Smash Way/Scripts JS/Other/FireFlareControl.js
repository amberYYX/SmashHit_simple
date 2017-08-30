#pragma strict

private var Pus:boolean=false;

function Start(){
yield WaitForSeconds(0.1);
Pus=true;
}


function Update(){
if(Pus){
if(gameObject.GetComponent.<LensFlare>().brightness>0){
gameObject.GetComponent.<LensFlare>().brightness=gameObject.GetComponent.<LensFlare>().brightness-0.74;
}else{
gameObject.SetActive(false);Pus=false;
}
}
}