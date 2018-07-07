using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStarter : MonoBehaviour {

    public playerWorld world;

	// Use this for initialization
	void OnEnable () 
    {
        if (world == playerWorld.worldA)
        {
            this.transform.position = new Vector3(5.0f, 0.0f, 0.0f);
        }
        else if(world == playerWorld.worldB)
        {
            this.transform.position = new Vector3(-5.0f, 0.0f, 0.0f);
        }
	}	
}

public enum playerWorld
{
    worldA,
    worldB,
}
