using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_manager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    public GameObject menu;
    public void menu_open() {
        menu.SetActive(true);
    }
    public void start_level(int index) {

        Application.LoadLevel("Scene"+index.ToString());
    }
	// Update is called once per frame
	void Update () {
		
	}
}
