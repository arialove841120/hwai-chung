using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chestScript : MonoBehaviour
{

    public CollisionListScript PlayerSensor;
    public bool isOpen = false;
    public GameObject openState;
    public GameObject closeState;
    public GameHintScript gameHintScript; //控制字幕程式碼
    public float LifeTime; //字幕存活時間

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerSensor.CollisionObjects.Count > 0 && this.isOpen == false)
        {
            if(PlayerSensor.CollisionObjects[0].GetComponent<PlayerScript>() != null)
            {
                if(PlayerSensor.CollisionObjects[0].GetComponent<PlayerScript>().hasGoldKey == true)
                {
                    this.isOpen = true;
                    this.openState.SetActive(true);
                    this.closeState.SetActive(false);
                    gameHintScript.OpenChest();
                    Invoke("textDisappear", LifeTime + 1);
                }
                else
                {
                    gameHintScript.NotFoundKey();
                    Invoke("textDisappear" , LifeTime);
                }
            }
            
        }
    }

    void textDisappear() //白癡做法~
    {
        gameHintScript.TextDisappear();
    }
}
