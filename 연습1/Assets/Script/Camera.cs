using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float turnSpeed = 4.0f; //마우스 회전 속도
    private float xRotate = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float yRotateSize = Input.GetAxis("Mouse X") *turnSpeed; 
        //Input.GetAxis("Mouse X") : 마우스를 좌우로 움직인 양
        
        float yRotate = transform.eulerAngles.y + yRotateSize;

        float xRotateSize = -Input.GetAxis("Mouse Y") * turnSpeed;
        //Input.GetAxis("Mouse Y") : 마우스를 위아래로 움직인 양
        // 위아래 회전량을 더해주지만 -45도 ~ 80도로 제한 (-45:하늘방향, 80:바닥방향)
        // 각도 제한
        xRotate = Mathf.Clamp(xRotate+ xRotateSize, -45, 80);
        // Clamp 는 값의 범위를 제한하는 함수

        transform.eulerAngles= new Vector3(xRotate, yRotate,0);

    }
}
