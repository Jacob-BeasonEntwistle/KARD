using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    private Vector3 camPos;     // A variable to store the cameras position in the x, y and z axies.
    public Transform target;

    // Floats to set the minimum and maximum boundaries of the camera.
    //private float minX = -12;
    //private float maxX = 12;
    private float minY = -6;
    private float maxY = 6;

    // Update is called at the end of each frame.
    void LateUpdate()
    {
        if (target == null)
        {
            return;
        }

        // Sets the camera position to the players position (allows camera to follow player).
        camPos = target.position;

        //https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Mathf.Clamp.html
        // Forces the x and y values of the camera to stay between the maximum and minimum values.
        //camPos.x = Mathf.Clamp(camPos.x, minX, maxX);
        camPos.y = Mathf.Clamp(camPos.y, minY, maxY);

        // Sets the cameras z position to the same as it was at the start of the game.
        camPos.z = transform.position.z;

        // Sets the cameras position to the current values (accounting for the boundaries).
        transform.position = camPos;
    }
}
