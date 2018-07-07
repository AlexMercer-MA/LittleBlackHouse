using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingbox : MonoBehaviour {

    public float speed=0.1f;
    public Vector3 startposition;
    public Vector3 endposition;
    Vector3 destination;
    void Awake() {
        destination = transform.position;
    }
	void Update () {
        Debug.Log(destination.x);
        if (Vector3.Distance(transform.position, endposition)<1){
            destination = startposition;          
        }else if (Vector3.Distance(transform.position, startposition) < 1)
        {
            destination = endposition;
        }

        transform.position = Vector3.MoveTowards(transform.position, destination, speed);
    }
}
