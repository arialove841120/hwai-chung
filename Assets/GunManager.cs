using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    private float shootCounter = 0;
    private float muzzleCounter = 0;

    public GameObject muzzleFlash;
    public GameObject bulletCandidate;

    public void TryToTriggerGun()
    {
        GameObject newBullet = GameObject.Instantiate(bulletCandidate);
        BulletScript bullet = newBullet.GetComponent<BulletScript>();

        bullet.transform.position = muzzleFlash.transform.position;
        bullet.transform.rotation = muzzleFlash.transform.rotation;

        bullet.InitAndShoot(muzzleFlash.transform.forward);
        
    }

    public void Update()
    {
        
    }



}
