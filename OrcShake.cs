using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class OrcShake : MonoBehaviour
{
    public void ShakeOnHit()
    {
        CameraShaker.Instance.ShakeOnce(4f, 4f, 1f, 1f);
    }

    public void ShakeOnWalk()
    {
        CameraShaker.Instance.ShakeOnce(1f, 1f, 1f, 1f);
    }
}
