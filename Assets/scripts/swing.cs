using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swing : MonoBehaviour
{
    public Transform target;
    public LineRenderer _lineRenderer;
    public DistanceJoint2D _distanceJoint;
    public float jumpforce = 50f;
    public Rigidbody2D rb;
    public float transitionTime = 0.1f;
    public float maxy=10f;
    void Start()
    {
        _distanceJoint.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 mousePos = transform.position;
            mousePos.x+=4;
            Vector3 camPos = target.position;
            mousePos.y=5f+camPos.y;
            _lineRenderer.SetPosition(0,mousePos);
            _lineRenderer.SetPosition(1, transform.position);
            _distanceJoint.connectedAnchor = mousePos;
            _distanceJoint.enabled = true;
            _lineRenderer.enabled = true;
            StartCoroutine(ApplyForce(jumpforce));
        }
        else if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            _distanceJoint.enabled = false;
            _lineRenderer.enabled = false;
        }
        if(_distanceJoint.enabled)
        {
            _lineRenderer.SetPosition(1, transform.position);
        }
        if(rb.position.y>maxy){
            _distanceJoint.enabled = false;
            _lineRenderer.enabled = false;
            Vector2 zero= new Vector2(0,0);
            rb.velocity=zero;
        }
    }
    IEnumerator ApplyForce(float jumpforce)
    {
        Vector2 force=new Vector2 (jumpforce, 0);
        yield return new WaitForSeconds(transitionTime);
        
        rb.AddForce(force, ForceMode2D.Impulse);
    }
}
