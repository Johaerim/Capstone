using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMove : MonoBehaviour
{
    public Transform cameraTransform;
    //Transform 값은 카메라 움직임에 따라 달라지므로, 해당 값을 카메라에
    //넘겨주기 위한 CameraTransform 변수 선언
    public CharacterController characterController;
    //CharacterController에 3D 오브젝트를 적용하기 위한 characterController 변수 선언

    public float moveSpeed = 20f; //이동속도

    public float jumpSpeed = 40f; //점프속도

    public float gravity= -20f; //중력

    public float yVelocity =0; //y축 움직임

    public CharacterController CharacterController { get => characterController; set => characterController = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        //키보드 가로(좌, 우)를 읽은 결과를 넘김

        float Vertical = Input.GetAxis("Vertical");
        // 위, 아래

        Vector3 moveDirection = new Vector3(Horizontal, 0, Vertical);
      
        moveDirection = cameraTransform.TransformDirection(moveDirection);
        //moveDirection 값은 카메라 위치
       
        moveDirection *= moveSpeed;
        // 최종 moveDirection = moveDirection * moveSpeed

        if(characterController.isGrounded)
        //만약 characterController가 땅에 붙어 있다면
        {
            yVelocity = 0;
            //y축 움직임 값 0이고
            if(Input.GetKeyDown(KeyCode.Space))
            // "스페이스 바 = 점프" 설정
            {
                yVelocity = jumpSpeed; // 사용자가 설정한 jumpSpeed 값을 yVelocity 값으로 넘겨서 처리
            }
        }

    yVelocity += (gravity+Time.deltaTime);
    // yvelocity 값은 yvelocity + (중력값 * Time.deltaTime)

    moveDirection.y = yVelocity;
    // 계산한 yVelocity 값을 moveDirection.y(y축 움직임 방향)로 넘겨줌

    CharacterController.Move(moveDirection * Time.deltaTime);
    // 최종적은로 characterController의 움직임은 방향 * Time.deltaTime 값 


    }
}
