using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinePrf_Mono : MonoBehaviour {

    Transform Line_A;
    Transform Line_B;
    // Use this for initialization
    void Awake () {
        Line_A = transform.GetChild(0);
        Line_B = transform.GetChild(1);
        Line_A.SetParent(GameObject.Find("WorldA").transform);
        Line_B.SetParent(GameObject.Find("WorldB").transform);
    }

}
