using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Animator animatorController;
    public Transform rotateYTransform;
    public Transform rotateXTransform;
    public float rotateSpeed;
    public float currentRotateX = 0;
    public float MoveSpeed;
    public float BowMoveSpeed;
    float currentSpeed = 0;
    private float ChargingBar = 0; //集氣條
    public float ChargingValue;


    public Rigidbody rigidBody;

    public JumpSensor JumpSensor;
    public float JumpSpeed;
    public GunManager gunManager;

    public GameUIManager gameUIManager;

    // Use this for initialization
    void Start()
    {
        Cursor.visible = false; //隱藏游標
        animatorController = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //決定鍵盤input的結果
        Vector3 movDirection = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) { movDirection.z += 1; }
        if (Input.GetKey(KeyCode.S)) { movDirection.z -= 1; }
        if (Input.GetKey(KeyCode.D)) { movDirection.x += 1; }
        if (Input.GetKey(KeyCode.A)) { movDirection.x -= 1; }
        movDirection = movDirection.normalized;

        //決定要給Animator的動畫參數
        if (movDirection.magnitude == 0 || !JumpSensor.IsCanJump()) { currentSpeed = 0; }
        else
        {
            if (movDirection.z < 0) { currentSpeed = -MoveSpeed; }
            else { currentSpeed = MoveSpeed; }
        }
        animatorController.SetFloat("Speed", currentSpeed);
        animatorController.SetBool("LeftMouse", Input.GetMouseButton(0));

        //判斷是否拉弓
        if (Input.GetMouseButton(0))
        {
            ChargingBar += Time.deltaTime; //開始累積

            gameUIManager.TargetSmall();

            //轉換成世界座標的方向
            Vector3 worldSpaceDirection = movDirection.z * rotateYTransform.transform.forward +
                                          movDirection.x * rotateYTransform.transform.right;
            Vector3 velocity = rigidBody.velocity;
            velocity.x = worldSpaceDirection.x * BowMoveSpeed;
            velocity.z = worldSpaceDirection.z * BowMoveSpeed;

            if (Input.GetKey(KeyCode.Space) && JumpSensor.IsCanJump())
            {
                velocity.y = JumpSpeed;
            }

            rigidBody.velocity = velocity;
        }
        else
        {
            if(ChargingBar >= ChargingValue) //放開左鍵判斷是否累積到可發射值
            {
                gunManager.TryToTriggerGun();
            }

            gameUIManager.TargetInitial();

            ChargingBar = 0; //歸零

            //轉換成世界座標的方向
            Vector3 worldSpaceDirection = movDirection.z * rotateYTransform.transform.forward +
                                          movDirection.x * rotateYTransform.transform.right;
            Vector3 velocity = rigidBody.velocity;
            velocity.x = worldSpaceDirection.x * MoveSpeed;
            velocity.z = worldSpaceDirection.z * MoveSpeed;

            if (Input.GetKey(KeyCode.Space) && JumpSensor.IsCanJump())
            {
                velocity.y = JumpSpeed;
            }

            rigidBody.velocity = velocity;
        }

        //計算滑鼠
        rotateYTransform.transform.localEulerAngles += new Vector3(0, Input.GetAxis("Horizontal"), 0) * rotateSpeed;
        currentRotateX += Input.GetAxis("Vertical") * rotateSpeed;

        if (currentRotateX > 90)
        {
            currentRotateX = 90;
        }
        else if (currentRotateX < -90)
        {
            currentRotateX = -90;
        }
        rotateXTransform.transform.localEulerAngles = new Vector3(-currentRotateX, 0, 0);

    }

}
