﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public bool hasGoldKey = false;
    public GameHintScript gameHintScript; //控制字幕程式碼
    public float LifeTime; //字幕存活時間

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void getKey(string keyType)
    {
        if(keyType.ToLower().Equals("gold") )
        {
            this.hasGoldKey = true;
            gameHintScript.GetKey();
            Invoke("textDisappear" , LifeTime);
        }
    }

    void textDisappear()
    {
        gameHintScript.TextDisappear();
    }
}
