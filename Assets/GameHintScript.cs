using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHintScript : MonoBehaviour {

    public Text GameHintText;

    public void NotFoundKey()
    {
        GameHintText.text = "尚未取得鑰匙";
    }

    public void GetKey()
    {
        GameHintText.text = "取得鑰匙";
    }

    public void OpenChest()
    {
        GameHintText.text = "咑咑咑咑咑咑咑～!";
    }

    public void TextDisappear()
    {
        GameHintText.text = "";
    }
}
