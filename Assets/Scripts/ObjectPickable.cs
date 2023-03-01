using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickable : MonoBehaviour
{

    private Rigidbody objectRigidbody;
    private Transform objectGrabPointTransform;

    private void Awake()
    {
        objectRigidbody = GetComponent<Rigidbody>();
    }
    public void Grab(Transform objectGrabPointTransform)
    {
        this.objectGrabPointTransform = objectGrabPointTransform;
        objectRigidbody.useGravity = false;
    }

    private void FixedUpdate()
    {
        if (objectGrabPointTransform != null)
        {
            Vector3 newPosition = Vector3.Lerp(transform.position, objectGrabPointTransform.position, Time.deltaTime * 28f);
            transform.rotation.Equals(objectGrabPointTransform.rotation);

            objectRigidbody.MovePosition(newPosition);
            //objectRigidbody.transform.rotation = objectGrabPointTransform.GetComponentInParent<Transform>().rotation; 
        }
    }
}
