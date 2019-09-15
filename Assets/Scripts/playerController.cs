using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    
    private Rigidbody rb;
    public GameObject parent;
    private Transform swordTransform;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
    {
        Vector3 dir = point - pivot; // get point direction relative to pivot
        dir = Quaternion.Euler(angles) * dir; // rotate it
        point = dir + pivot; // calculate rotated point
        return point; // return it
    }
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal") * 5;
        float v = Input.GetAxis("Vertical") * 5;
        Vector3 vel = rb.velocity;
        if (Input.GetKeyDown("space"))
        {
            vel.y=5.0f;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            swordTransform = parent.transform.GetChild(1);
            Vector3 dest = RotatePointAroundPivot(swordTransform.transform.localPosition, new Vector3 (0, 0, 1), new Vector3(90, 0, 0));
            swordTransform.transform.localPosition = dest;
        }
        vel.x = h;
        vel.z = v;
        rb.velocity = vel;
    }

}
