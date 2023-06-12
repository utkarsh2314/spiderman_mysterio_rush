using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public float FollowSpeed =2f;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = new Vector3(target.position.x,target.position.y,-10f);
        transform.position = Vector3.Slerp(transform.position,mousePos,FollowSpeed*Time.deltaTime);
    }
}
