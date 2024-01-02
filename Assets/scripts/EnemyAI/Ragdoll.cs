using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    Rigidbody[] rigidbodies;
    Animator Animator;
    BoxCollider hitbox;

    void Start()
    {

        rigidbodies = GetComponentsInChildren<Rigidbody>();
        Animator = GetComponent<Animator>();
        hitbox = GetComponent<BoxCollider>();
        DeactivateRagdoll();
    }

    public void DeactivateRagdoll()
    {
        foreach(var rigidBody in rigidbodies)
        {
            rigidBody.isKinematic = true;
        }
        Animator.enabled = true;
        hitbox.enabled = true;
    }

    public void ActivateRagdoll()
    {
        foreach (var rigiBody in rigidbodies)
        {
            rigiBody.isKinematic = false;
        }
        Animator.enabled = false;
        hitbox.enabled = false;

    }
}
