using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swing : MonoBehaviour
{
    public Transform target;
    public LineRenderer _lineRenderer;
    public DistanceJoint2D _distanceJoint;
    public float jumpforce = 20f;
     public Rigidbody2D rb;


    void Start()
    {
        _distanceJoint.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector2 mousePos = transform.position;
            mousePos.x+=4;
            Vector2 camPos = target.position;
            mousePos.y=5+camPos.y;
            _lineRenderer.SetPosition(0,mousePos);
            _lineRenderer.SetPosition(1, transform.position);
            _distanceJoint.connectedAnchor = mousePos;
            _distanceJoint.enabled = true;
            _lineRenderer.enabled = true;
        }
        else if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            _distanceJoint.enabled = false;
            _lineRenderer.enabled = false;
            rb.AddForce(Vector2.up*jumpforce, ForceMode2D.Impulse);
        }
        if(_distanceJoint.enabled)
        {
            _lineRenderer.SetPosition(1, transform.position);
        }
    }
}
