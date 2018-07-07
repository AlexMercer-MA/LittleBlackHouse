using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting_bullet : MonoBehaviour {
    public GameObject pfb;
    public float ShootSpeed;

    float elapsed;
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        elapsed += Time.deltaTime;
        if (elapsed > ShootSpeed) {
            GameObject prefabInstance;
            //prefabInstance.transform.parent = transform;
            prefabInstance = Instantiate(pfb,transform,false);
            //prefabInstance.transform.position = transform.localPosition;
            elapsed = 0;
        }	
	}
}
