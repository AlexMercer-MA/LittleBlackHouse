using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Sprites;

public class DiamondShine : MonoBehaviour {

    [SerializeField]
    SpriteRenderer spriteRenderer;
    [SerializeField]
    Sprite sprite;
    [SerializeField]
    Color color;
    [SerializeField]
    float redVal;

	void Start () 
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        sprite = spriteRenderer.sprite;
        color = spriteRenderer.color;
	}
	
	void Update () 
    {
        redVal = 0.7f + 0.3f * Mathf.Sin(Time.time * 5f);
        color = new Color(redVal, 1f, 1f);
        spriteRenderer.color = color;
	}
}
