using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_script : MonoBehaviour {

    public float destroyDelay;

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, destroyDelay);
    }

    public float speed_x;
    public float speed_y;

    // Update is called once per frame
    void Update () {
        transform.Translate(speed_x,speed_y,0);
	}
}
