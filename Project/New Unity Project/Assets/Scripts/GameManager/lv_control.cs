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
    public int level = 0;
    public GameObject win_page;
    public GameObject deathpage;
	// Use this for initialization
	void Start () {
		
	}
    public void next_level() {
        
        Application.LoadLevel("level" + (level+1).ToString());

    }
    public void got_star()
    {
        score = true;
    }
    public void dead()
    {
        deathpage.SetActive(true);
    }
    public void reload() {
        Application.LoadLevel("level"+level.ToString());
    }
    public void win() {
        //
        if (score) {
            win_page.transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1f);
            win_page.transform.GetChild(1).GetComponent<Text>().color = new Color(1f, 1f, 0.04f, 1f);
            win_page.transform.GetChild(1).GetComponent<Text>().text = "完成奖励物品收集!!";
        }
        else {
            win_page.transform.GetChild(0).GetComponent<Image>().color = new Color(0.2f, 0.2f, 0.2f, 1f);
            win_page.transform.GetChild(1).GetComponent<Text>().color = new Color(1f, 0.7f, 0.7f, 1f);
            win_page.transform.GetChild(1).GetComponent<Text>().text = "未完成奖励物品收集...";
        }

        win_page.SetActive(true);

    }
    float elapsed=0;

    void Update () {
        elapsed += Time.deltaTime;
        if (elapsed>2 && elapsed<20) {
            level_picture.GetComponent<RectTransform>().position = Vector3.MoveTowards(level_picture.GetComponent<RectTransform>().position,
                new Vector3(2012,0,0), 
                20f);
        }

        if (Input.GetKeyDown(KeyCode.R) && win_page.activeInHierarchy)
        {
            reload();
        }
        else if (Input.anyKeyDown && win_page.activeInHierarchy)
        {
            next_level();
        }
        else if (Input.anyKeyDown && deathpage.activeInHierarchy)
        {
            reload();
        }

        

    }
}
