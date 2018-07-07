using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting_bullet : MonoBehaviour {
    public GameObject pfb;
    public float ShootSpeed;
    Animator animator;

    float elapsed;
    // Use this for initialization
	void Start () {
        animator = this.GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        elapsed += Time.deltaTime;
        if (elapsed > ShootSpeed) 
        {
            GameObject prefabInstance;
            prefabInstance = Instantiate(pfb, transform.position, Quaternion.identity, transform);
            animator.SetTrigger("Shoot");
            elapsed = 0;
        }	
	}
}
