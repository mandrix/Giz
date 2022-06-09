using UnityEngine;
using System.Collections;

public class MoveSample : MonoBehaviour
{	
	void Start(){
		iTween.MoveBy(gameObject, iTween.Hash("y", 2, "x", 2, "z", 2, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .1));
	}
}

