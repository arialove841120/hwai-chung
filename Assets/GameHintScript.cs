using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class GameHintScript : MonoBehaviour {

    public GameObject WASD;
    public GameObject mouse;
    public Text GameHintText;
    public float LifeTime; //字幕存活時間

    public void WASDsetActive()
    {
        GameHintText.text = "快使用WASD方向鍵移動吧!";
        WASD.SetActive(true);
        mouse.SetActive(true);
        Invoke("TextDisappear", LifeTime + 3);
        Invoke("ImageDisapper", LifeTime + 3);
    }

    public void ImageDisapper() //把圖片關掉
    {
        WASD.SetActive(false);
        mouse.SetActive(false);
    }

    public void GameStart()
    {
        GameHintText.text = "歡迎來到暗黑地牢!";
        Invoke("TextDisappear", LifeTime + 1);
    }

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
