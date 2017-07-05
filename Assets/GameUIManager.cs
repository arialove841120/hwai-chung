using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour {

    public Image target;
    public float SmallSpeed;
    private Vector3 scaleTemp;
    public GameHintScript gameHintScript;
    float LifeTime;

    // Use this for initialization
    void Start ()
    {
        LifeTime = gameHintScript.LifeTime + 1.5F;
        gameHintScript.GameStart();
        scaleTemp = target.transform.localScale; //取大小比例
	}
	
	// Update is called once per frame
	void Update ()
    {   
        if(LifeTime > 0)
        {
            LifeTime -= Time.deltaTime;
        }
        else if (LifeTime < 0)
        {
            gameHintScript.WASDsetActive();

            LifeTime = 0;
        }
    }

    public void TargetInitial() //變回初始大小
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
