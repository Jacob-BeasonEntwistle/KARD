using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraOnPlayer : MonoBehaviour
{
    private Vector3 camPos;     // A variable to store the cameras position in the x, y and z axies.
    private Movement playerM;   // A variable to store the player movement script.

    // Floats to set the minimum and maximum boundaries of the camera.
    //private float minX = -12;
    //private float maxX = 12;
    private float minY = -6;
    private float maxY = 6;


    // Start is called before the first frame update.
    void Start()
    {
        /* Gets the movement script from the object in scene with the 
         * tag "Player" and stores it in playerM variable. */
        playerM = GameObject.FindWithTag("Player").GetComponent<Movement>();
    }

    // Update is called at the end of each frame.
    void LateUpdate()
    {
        // Sets the camera position to the players position (allows camera to follow player).
        camPos = playerM.transform.position;

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
