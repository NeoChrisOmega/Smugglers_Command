﻿using UnityEngine;
using System.Collections;

public class KillObject : MonoBehaviour
{/*This is attached to the object, the object should be the solid object, 
    so that the AI can be the trigger colliders*/
    
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {//This will destroy the object when it goes too far out in space
        if (this.transform.position.z <= -5)
        {
            Destroy(this.gameObject);
        }	
	}
}
