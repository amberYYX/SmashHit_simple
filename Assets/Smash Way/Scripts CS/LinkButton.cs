using UnityEngine;
using System.Collections;

public class LinkButton : MonoBehaviour {

	public string Link;

	public void OnMouseDown(){
		Application.OpenURL(Link.ToString());
	}
}
