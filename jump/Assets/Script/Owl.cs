using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owl : MonoBehaviour
{
    Animator anim;
    Transform chkPoint;

    float moveSpeed = 8f; //이동속도
    float jumpSpeed = 12f; //점프 속도
    float gravity = 19f; //중력

    Vector3 moveDir; // 이동 방향과 속도
    bool isDead = false; //사망

    

    void Start()
    {
        anim = GetComponent<Animator>();

        chkPoint = transform.Find("CheckPoint");

        manger = FindObjectOfType<GameManager>();

    }

    void Update()
    {
       if(isDead) return;

       CheckBranch();
       MoveOwl();
    }
    
    
    void MoveOwl()
    {
        Vector2 pos = Camera.main.WorldToScreenPoint(transform.position);
        if(pos.y < -100)
        {
            isDead = true;
            manager.SendMessage("SetGameOver");
            return;
        }

        float keyValue = Input.GetAxis("Horizontal");

        if(manager.isMobile)
        {
            keyValue = manager.btnAxis;
        }

        moveDir.x = keyValue * moveSpeed;

        moveDir.y -= gravity * Time.deltaTime;
        

        transform.Translate(moveDir * Time.deltaTime);
        anim.SetFloat("velocity", moveDir.y);
       
    }

    void CheckBranch()
    {
        RaycastHit2D hit = Physics2D.Raycast(chkPoint.position, Vector2.down, 0.2f);

        Debug.DrawRay(chkPoint.position, Vector2.down * 1f, Color.blue);

        if(hit.collider != null && hit.collider.tag == "Branch")
        {
            moveDir.y=jumpSpeed;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        Transform other = coll.transform;

        switch(other.tag)
        {
            case "Bird":
        other.SendMessage("DropBird");
        break;
        }
        
    }
}
