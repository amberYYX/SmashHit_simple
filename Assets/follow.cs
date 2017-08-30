using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour {

    public Vector3 offset;  //用来存储角色与摄像机之间的距离
    public Vector3 rotation;
    public Transform cam;  //用来存储相机的位置

	// Use this for initialization
	void Start () {

        offset = transform.position - cam.position;  //算出摄影机与角色之间的距离
        offset.z = -5;
        offset.y = 4;
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = cam.position + offset;    //实时更新角色的为位置

	}
}
