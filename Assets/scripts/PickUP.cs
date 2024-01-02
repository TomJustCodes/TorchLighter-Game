using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUP : MonoBehaviour
{
    public float pickUpRange = 5f;
    public float moveForce = 250f;

    public Transform holdParent;

    private GameObject heldObj;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))//input mouse 0 
        {
            if (heldObj == null)//check to see if all ready holding an object or not
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
                {
                    //checks if there is an object to pickup
                    Pickupobject(hit.transform.gameObject);
                }
            }
            else
            {
                DropObject();
            }
        }
        if (heldObj != null)
        {
            MoveObject();
        }

    }

    void MoveObject()
    {
        //make the box move based of the movement of the camera
        if (Vector3.Distance(heldObj.transform.position, holdParent.position) > 0.1f)
        {
            Vector3 moveDirection = (holdParent.position - heldObj.transform.position);
            heldObj.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);
        }
    }


    void Pickupobject(GameObject pickobj)
    {
        if (pickobj.GetComponent<Rigidbody>() && pickobj.tag == "pickupable")//check if the object is marked as pickupable
        {
            Rigidbody objRig = pickobj.GetComponent<Rigidbody>();
            objRig.useGravity = false;
            objRig.drag = 10;
            objRig.transform.parent = holdParent;
            heldObj = pickobj;

        }
    }

    void DropObject()//return the values to normal drop the object
    {
        Rigidbody heldRig = heldObj.GetComponent<Rigidbody>();
        heldRig.useGravity = true;
        heldRig.drag = 1;
        heldObj.transform.parent = null;
        heldObj = null;
    }

    private void OnCollisionEnter(Collision collision)//if the box hit the player make sure object drops
    {
        if(collision.gameObject.tag == "pickupable" && collision.gameObject == heldObj)
        {
            DropObject();
        }
    }
}
