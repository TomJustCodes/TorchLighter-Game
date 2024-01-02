using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
	private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask Grappleable;
    public Transform TorchTip, camera, player;
    private float maxDistance = 75f;
    private SpringJoint joint;

    void Awake() 
	{
        lr = GetComponent<LineRenderer>();
    }

    void Update() {//inputs used for if and elseif for a holding functions
        if (Input.GetMouseButtonDown(0))
			{
            StartGrapple();
        }
        else if (Input.GetMouseButtonUp(0))
			{
            StopGrapple();
        }
    }

 
    void LateUpdate() {
        DrawRope();
    }


    void StartGrapple() {
        RaycastHit hit;
        if (Physics.Raycast(camera.position, camera.forward, out hit, maxDistance, Grappleable)) 
		{
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();//creates a joint for the player to the grapple point
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);


            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.minDistance = distanceFromPoint * 0.25f;

            joint.spring = 100f;
            joint.damper = 10f;
            joint.massScale = 10f;

            lr.positionCount = 2;
            currentGrapplePosition = TorchTip.position;
        }
    }
    void StopGrapple()
	{
        lr.positionCount = 0;
        Destroy(joint);//deystoys the joint 
    }

    private Vector3 currentGrapplePosition;
    
    void DrawRope()//visulaising the grapple
	{
    
        if (!joint) return;

        currentGrapplePosition = Vector3.Lerp(currentGrapplePosition, grapplePoint, Time.deltaTime * 8f);
        
        lr.SetPosition(0, TorchTip.position);
        lr.SetPosition(1, currentGrapplePosition);
    }

    public bool IsGrappling() 
	{
        return joint != null;
    }

    public Vector3 GetGrapplePoint() 
	{
        return grapplePoint;
    }
}
