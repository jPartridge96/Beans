using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectObject : MonoBehaviour
{
    [SerializeField] private Transform playerViewTransform;
    [SerializeField] private Transform objectGrabPointTransform;
    [SerializeField] private LayerMask pickUpLayerMask;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float pickUpDistance = 2f;
        if (Input.GetKeyDown(KeyCode.E))
        {
           if(Physics.Raycast(playerViewTransform.position, playerViewTransform.forward, out RaycastHit raycastHit, pickUpDistance))
            {
                if(raycastHit.transform.TryGetComponent(out ObjectPickable objectPickable))
                {
                    objectPickable.Grab(objectGrabPointTransform);
                    Debug.Log(objectPickable);
                }
            }
        }
    }

}
