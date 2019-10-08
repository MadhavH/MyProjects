using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level : MonoBehaviour {
    [SerializeField]int breakableblocks; //Serialized for debugging purposes
    SceneLoader sc; 
	// Use this for initialization
    public void CountBreakableBlocks()
    {
        breakableblocks++;
    }
    private void Start()
    {
        sc = FindObjectOfType<SceneLoader>();
    }
    public void minusbreakableblocks()
    {
        breakableblocks--;
    }
	
	
	// Update is called once per frame
	void Update () {
        if(breakableblocks == 0)
        {
            sc.LoadNextScene();
        }
		
	}
}
