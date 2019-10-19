using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class XRControllerTracking : MonoBehaviour
{
    [Tooltip("The XR node to track rotation of.")]
    [SerializeField] XRNode node = XRNode.CenterEye;

    void Update()
    {
        transform.rotation = InputTracking.GetLocalRotation(node);
        // use local rotation when object is parented to a rotating object
        // the tracked camera must have the same parent
        //transform.localRotation = InputTracking.GetLocalRotation(node);
    }
}
