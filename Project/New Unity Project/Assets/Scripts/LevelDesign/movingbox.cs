using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingbox : MonoBehaviour {
    public float start_x;
    public float start_y;
    public float end_x;
    public float end_y;

    public float speed=0.01f;
    Vector3 startposition;
    Vector3 endposition;
    Vector3 destination;
    void Awake() {
        startposition = new Vector3(transform.localPosition.x + start_x, transform.localPosition.y + start_y, transform.localPosition.z);
        endposition = new Vector3(transform.localPosition.x + end_x, transform.localPosition.y + end_y, transform.localPosition.z);
        destination = endposition;
    }
	void Update () {

        if (Vector3.Distance(transform.localPosition, endposition)<0.1f){
            destination = startposition;          
        }else if (Vector3.Distance(transform.localPosition, startposition) < 0.1f)
        {
            destination = endposition;
        }

        transform.localPosition = Vector3.MoveTowards(transform.localPosition, destination, speed);
    }
}
