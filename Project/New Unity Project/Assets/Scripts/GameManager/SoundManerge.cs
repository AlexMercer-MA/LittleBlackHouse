using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManerge : Single_Behaviour<SoundManerge> {
    public AudioClip[] audios;

    [HideInInspector]
    public AudioSource source;
	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
        source.loop = false;
    }
	
	// Update is called once per frame
	void Update () {
     
    }

    public void PlayAudio(int id)
    {
        source.clip = audios[id];      
        source.Play();
    }
}
