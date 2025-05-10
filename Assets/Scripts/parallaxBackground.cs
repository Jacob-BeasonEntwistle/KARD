using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxBackground : MonoBehaviour
{
    // Stores the transform of the camera.
    public Transform cam;
    // Stores the multiplier of the parallaxing effect.
    public float parallaxMult = 0.3f;

    // Update is called once per frame
    void Update()
    {
        // Applies the new calculated transform to the parallaxing background.
        transform.position = new Vector2(cam.position.x * parallaxMult, cam.position.y * parallaxMult);
    }
}
