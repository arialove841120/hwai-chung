using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour {

    public Image target;
    public float SmallSpeed;
    private Vector3 scaleTemp;
    public GameHintScript gameHintScript;
    float Lifetime;

    // Use this for initialization
    void Start ()
    {
        Lifetime = gameHintScript.LifeTime + 0.5f;
        gameHintScript.StartText();
        scaleTemp = target.transform.localScale; //取大小比例
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Lifetime > 0)
        {
            Lifetime -= Time.deltaTime;
        }
        else if(Lifetime < 0)
        {
            gameHintScript.OpenImage();
            Lifetime = 0;
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
