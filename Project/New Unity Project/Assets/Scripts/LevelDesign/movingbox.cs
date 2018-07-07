using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingbox : MonoBehaviour {

    public float speed=0.1f;
    public Vector3 startposition;
    public Vector3 endposition;
    Vector3 destination;
    void Awake() {
        destination = endposition;
    }
	void Update () {
        //Debug.Log(destination.y);
        if (Vector3.Distance(transform.localPosition, endposition)<0.001f){
            destination = startposition;          
        }else if (Vector3.Distance(transform.localPosition, startposition) < 0.001f)
        {
            destination = endposition;
        }

        transform.localPosition = Vector3.MoveTowards(transform.localPosition, destination, speed);
    }
}
