﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour {

    public Image target;
    public float SmallSpeed;
    private Vector3 scaleTemp;

    // Use this for initialization
    void Start () {
        scaleTemp = target.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TargetInitial()
    {
        target.transform.localScale = scaleTemp;
    }

    public void TargetSmall()
    {
        if(target.transform.localScale.sqrMagnitude > 0.07f)
        {
            target.transform.localScale *= SmallSpeed;
        }
    }
}
