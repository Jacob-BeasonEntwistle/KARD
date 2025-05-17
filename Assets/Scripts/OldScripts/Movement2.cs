using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
    // Variables to store the x and y inputs.
    private float x = 0.0f;
    private float y = 0.0f;

    private float speed = 3f;               // Controls the speed of the player movement.
    public static bool isBoosting;
    private float boost = 7.5f;             // Adds a boost to the speed of the player.
    private float boostCounter = 3f;        // When it reaches 0, the boost stops.
    public Texture boostEffect;             // Allows for a texture to be attached.

    private float spriteSize = 40.0f;      // Set the size of the sprite.
    public Camera GameCamera2;             // Reference the game's camera.

    // Start is called before the first frame update.
    void Start()
    {
        // Finds the 2nd camera in the scene.
        GameCamera2 = GameObject.FindWithTag("MainCamera2").GetComponent<Camera>();
        // Boosting is set to false by default.
        isBoosting = false;
    }

    // Update is called once per frame.
    void Update()
    {
        // If boosting is true...
        if (isBoosting == true)
        {
            // speed becomes the boost speed...
            speed = boost;
            // the boost counter decreases as the time increases...
            boostCounter -= Time.deltaTime;
            // a countdown is displayed in the console.
            Debug.Log("Boost remaining: " + (int)boostCounter);
            // then, if the boost counter is less than or equal to 0...
            if (boostCounter <= 0)
            {
                // boosting is set to false...
                isBoosting = false;
                // the speed is reset...
                speed = 3f;
                // and the boost counter is reset.
                boostCounter = 3f;
            }
        }

        // Sets the default position of the player to (0,0) each frame.
        Vector3 pos = new Vector2(x, y);
                
        /* Gets the inputted value on the horizontal axies and 
         * clamps it to a value between -1 and 1 */
        float move = Mathf.Clamp(Input.GetAxis("Horizontal2"), -1, 1);
        // Sets the x position to increase based off of the calculations done.
        pos += new Vector3(move * speed, 0) * Time.deltaTime;
        /* Gets the inputted value on the vertical axies and 
         * clamps it to a value between -1 and 1 */
        move = Mathf.Clamp(Input.GetAxis("Vertical2"), -1, 1);
        // Sets the y position to increase based off of the calculations done.
        pos += new Vector3(0, move * speed) * Time.deltaTime;

        // [Removing this code and making camera a child of the player2 made the player movement work]
        //// Sets a new default position of the player to (0,0) when the player tries to leave the boundary.
        //Vector3 newPos = (Vector2)GameCamera2.WorldToScreenPoint(transform.position + pos);

        //// If the new position is outside the cameras width...
        //if (newPos.x + spriteSize > GameCamera2.pixelWidth || newPos.x - spriteSize < 0)
        //{
        //    /* the position becomes (x, y) meaning once it reaces the edge of the screen, 
        //     * its position repeatedly gets reset to where it is near the edge. */
        //    pos = new Vector2(x, y);
        //}

        //// If the new position is outside the cameras height...
        //if (newPos.y + spriteSize > GameCamera2.pixelHeight || newPos.y - spriteSize < 0)
        //{
        //    /* The position is reset to the current position, 
        //     * blocking the player from moving outside the boundaries. */
        //    pos = new Vector2(x, y);
        //}

        // Applies the calculated translation (pos) to the players position.
        transform.Translate(pos);
    }

    //https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Graphics.DrawTexture.html
    void OnGUI()
    {
        // If the player is boosting...
        if (isBoosting == true)
        {
            // a texture is drawn onto the screen to indicate the active effect.
            GUI.DrawTexture(new Rect(0, 0, GameCamera2.pixelWidth, GameCamera2.pixelHeight), boostEffect);
        }
    }
}
