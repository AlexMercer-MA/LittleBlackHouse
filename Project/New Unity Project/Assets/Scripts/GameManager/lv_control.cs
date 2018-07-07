using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lv_control : MonoBehaviour {
    public static lv_control GetInstance;
    public GameObject level_picture;
    
    void Awake() {
        GetInstance= this;
        level_picture.transform.GetChild(0).GetComponent<Text>().text = "Level " + level.ToString();
    }
    public bool score = false;
    public int level = 2;
    public GameObject win_page;
	// Use this for initialization
	void Start () {
		
	}
    public void next_level() {
        
        Application.LoadLevel("Scene"+(level+1).ToString());

    }
    public void got_star()
    {
        score = true;
    }
    public GameObject deathpage;
    public void dead() {
        deathpage.SetActive(true);
    }
    public void reload() {
        Application.LoadLevel("Scene"+level.ToString());
    }
    public void win() {
        //
        if (score) {
            win_page.transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 0, 1f);
            win_page.transform.GetChild(1).GetComponent<Text>().text = "You got the star!!";
        }
        else {
            win_page.transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 0, 0.5f);
            win_page.transform.GetChild(1).GetComponent<Text>().text = "You didn't get the star...";
        }

        win_page.SetActive(true);

    }
    float elapsed=0;

    void Update () {
        elapsed += Time.deltaTime;
        if (elapsed>2 && elapsed<20) {
            level_picture.GetComponent<RectTransform>().position = Vector3.MoveTowards(level_picture.GetComponent<RectTransform>().position,
                new Vector3(2012,0,0), 
                20f); }

    }
}
