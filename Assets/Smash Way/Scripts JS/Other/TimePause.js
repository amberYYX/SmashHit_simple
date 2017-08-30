#pragma strict

var TimeActive:float;
var ObjectActive:GameObject;


function Start () {
yield WaitForSeconds(TimeActive);
ObjectActive.SetActive(true);
}
