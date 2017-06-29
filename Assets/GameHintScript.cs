﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHintScript : MonoBehaviour {

    public Text GameHintText;
    public float LifeTime; //字幕存活時間

    public void NotFoundKey()
    {
        GameHintText.text = "尚未取得鑰匙";
        Invoke("TextDisappear", LifeTime);
    }

    public void GetKey()
    {
        GameHintText.text = "取得鑰匙";
        Invoke("TextDisappear", LifeTime);
    }

    public void OpenChest()
    {
        GameHintText.text = "寶箱打開囉~!";
        Invoke("TextDisappear", LifeTime + 1);
    }

    public void TextDisappear()
    {
        GameHintText.text = "";
    }
}
