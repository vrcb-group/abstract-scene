using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class DisableHMD : MonoBehaviour
{
    void Update()
    {
        if(TryGetCenterEyePosition(out Vector3 pos))
        {
            transform.position = pos;
        }
        if (TryGetCenterEyeFeature(out Quaternion rot))
        {
            transform.rotation = Quaternion.Inverse(rot);
        }
        //transform.position = -InputTracking.GetNodeStates(XRNode.CenterEye);
        //transform.rotation = Quaternion.Inverse(InputTracking.GetLocalRotation(XRNode.CenterEye));
    }

    bool TryGetCenterEyeFeature(out Quaternion rotation)
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(XRNode.CenterEye);
        if (device.isValid)
        {
            if (device.TryGetFeatureValue(CommonUsages.centerEyeRotation, out rotation))
                return true;
        }
        // This is the fail case, where there was no center eye was available.
        rotation = Quaternion.identity;
        return false;
    }

    bool TryGetCenterEyePosition(out Vector3 _position)
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(XRNode.CenterEye);
        if (device.isValid)
        {
            if (device.TryGetFeatureValue(CommonUsages.centerEyePosition, out _position))
                return true;
        }
        // This is the fail case, where there was no center eye was available.
        _position = transform.localPosition;
        return false;
    }

}
