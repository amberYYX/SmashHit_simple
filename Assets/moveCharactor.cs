using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCharactor : MonoBehaviour {

    public Transform pos;  //寻路点位置

    public UnityEngine.AI.NavMeshAgent nav;  //寻路路径

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        nav.SetDestination(pos.position); //设置角色的寻路点

    }
}
