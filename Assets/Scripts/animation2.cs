using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation2 : MonoBehaviour
{
    // The current frame of the player being shown on screen.
    public Vector2 currentFrame = new Vector2(0, 0);
    // The total number of frames for the player.
    private Vector2 numberOfFrames = new Vector2(2, 2);

    private Vector2 size;                   // The size of the visible sprite.
    private MeshRenderer animRenderer;      // Stores the renderer of the sprite.


    // Start is called before the first frame update
    void Start()
    {
        // Gets the spritesheet for the animation.
        animRenderer = GetComponent<MeshRenderer>();

        // A singular frame is displayed within the quad.
        size = new Vector2(1.0f / numberOfFrames.x, 1.0f / numberOfFrames.y);
    }

    // Update is called once per frame
    void Update()
    {
        // If the player is moving down...
        if (Input.GetAxis("Vertical2") < 0)
        {
            // the first frame is displayed.
            currentFrame.x = 0;
            currentFrame.y = 0;
        }

        // If the player is moving up...
        if (Input.GetAxis("Vertical2") > 0)
        {
            // the second frame is displayed.
            currentFrame.x = 1;
            currentFrame.y = 0;
        }

        // If the player is moving left...
        if (Input.GetAxis("Horizontal2") < 0)
        {
            // the first frame of the second line is displayed.
            currentFrame.x = 0;
            currentFrame.y = 1;
        }

        // If the player is moving right...
        if (Input.GetAxis("Horizontal2") > 0)
        {
            // the second frame of the second line is displayed.
            currentFrame.x = 1;
            currentFrame.y = 1;
        }

        // Amount to offset the sprite sheet as it is shown within the quad area.
        Vector2 offSet = new Vector2(currentFrame.x * size.x, 1.0f - size.y - currentFrame.y * size.y);

        // The offset and size values are applied to the rendered material to show a singular frame of the sprite sheet.
        animRenderer.material.SetTextureOffset("_MainTex", offSet);
        animRenderer.material.SetTextureScale("_MainTex", size);
    }
}
