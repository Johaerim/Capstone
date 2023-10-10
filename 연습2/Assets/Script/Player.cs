using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public Transform camaraTransform;

    public CharacterController characterController;

    public float moveSpeed = 10f;

    public float jumpSpeed = 10f;

    public float gravity = -20f;

    public float yVelocity = 0; //y축 움직임

    
       
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(h, 0, v);

        moveDirection = camaraTransform.TransformDirection(moveDirection);

        moveDirection *= moveSpeed;

        if(characterController.isGrounded)
        {
            yVelocity = 0;

            if(Input.GetKeyDown(KeyCode.Space))
            {
                yVelocity = jumpSpeed;
            }
        }

        yVelocity += (gravity * Time.deltaTime);

        moveDirection.y = yVelocity;

        characterController.Move(moveDirection * Time.deltaTime);
    }
}
