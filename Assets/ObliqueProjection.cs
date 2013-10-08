﻿using UnityEngine;
using System.Collections;

[ExecuteInEditMode, RequireComponent(typeof(Camera))]
public class ObliqueProjection : MonoBehaviour
{
    public float angle = 45.0f;
    public float zScale = 0.2f;
    public float zOffset = 5.0f;

    void Update ()
    {
        camera.orthographic = true;
        var orthoHeight = camera.orthographicSize;
        var orthoWidth = camera.aspect * orthoHeight;
        var m = Matrix4x4.Ortho (-orthoWidth, orthoWidth, -orthoHeight, orthoHeight, camera.nearClipPlane, camera.farClipPlane);
        var s = zScale * 0.5f / orthoHeight;
        m [0, 2] = +s * Mathf.Sin (Mathf.Deg2Rad * -angle);
        m [1, 2] = -s * Mathf.Cos (Mathf.Deg2Rad * -angle);
        m [0, 3] = -zOffset * m [0, 2];
        m [1, 3] = -zOffset * m [1, 2];
        camera.projectionMatrix = m;
    }
}