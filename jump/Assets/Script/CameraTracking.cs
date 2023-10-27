using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{

    Transform target;
    float height;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Owl").transform;
        height = target.position.y;
        
    }

    void LateUpdate()
    {
        float ty = target.position.y;
        if(ty <= height) return;

        float cy = transform.position.y;
        cy = Mathf.Lerp(cy,ty,5*Time.deltaTime);

        Vector3 pos = transform.position;
        pos.y = cy- 0.1f;
        transform.position = pos;

        height = ty;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
