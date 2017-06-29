using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverScript : MonoBehaviour
{

    public float rotateSpeed = 1.5f;
    public float currentSpeed;
    public float moveSpeed;
    public Rigidbody rigidBody;

    // Use this for initialization
    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movDirection = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) { movDirection += this.transform.forward; }
        if (Input.GetKey(KeyCode.S)) { movDirection -= this.transform.forward; }
        if (Input.GetKey(KeyCode.D)) { movDirection += this.transform.right; }
        if (Input.GetKey(KeyCode.A)) { movDirection -= this.transform.right; }
        movDirection = movDirection.normalized;

        rigidBody.velocity = movDirection * moveSpeed;

        this.transform.localEulerAngles += new Vector3(0, Input.GetAxis("Horizontal"), 0) * rotateSpeed;
        this.transform.localEulerAngles += new Vector3(-Input.GetAxis("Vertical"), 0, 0) * rotateSpeed;
        if (this.transform.localEulerAngles.x > 90)
        {
            this.transform.localEulerAngles.Set(90, this.transform.localEulerAngles.y, this.transform.localEulerAngles.z);
        }
        else if (this.transform.localEulerAngles.x < -90)
        {
            this.transform.localEulerAngles.Set(-90, this.transform.localEulerAngles.y, this.transform.localEulerAngles.z);
        }
    }
}
