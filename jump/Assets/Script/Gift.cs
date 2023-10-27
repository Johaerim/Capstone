using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift : MonoBehaviour
{
    int kind;

    void Start()
    {
        InitGift();
    }

    void Update()
    {
        
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        if (pos.y < -30)
        {
            Destroy(gameObject);
        }
    }

    
    void InitGift()
    {
        
        kind = int.Parse(transform.name.Substring(4, 1));

         
        Sprite[] sprites = Resources.LoadAll<Sprite>("gift");
        
        GetComponent<SpriteRenderer>().sprite = sprites[kind];
    }

    void GetGift()
    {
        GetComponent<AudioSource>().Play();

        GameObject score = Instantiate(Resources.Load("score"))as GameObject;
        score.transfomr.position = transform.position;

        Destroy(GetComponent<Collider>());
        GetComponent<SpriteRenderer>().sprite = null;
        Destroy(gameObject, 0.5f);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        Transform other = coll.transform;

        switch(other.tag)
        {
            case "Gift":
            other.SendMessage("GetGift");
            break;
        }
    }
}
