using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public string horizontalAxis = "Horizontal";    // Changeable in the editor
    public string verticalAxis = "Vertical";        // Changeable in the editor
    public Camera playerCamera;                     // Reference the game's camera.

    // Variables to store the x and y inputs.
    private float x = 0.0f;
    private float y = 0.0f;

    private float speed = 3f;               // Controls the speed of the player movement.
    public static bool isBoosting;
    private float boost = 7.5f;             // Adds a boost to the speed of the player.
    private float boostCounter = 3f;        // When it reaches 0, the boost stops.
    public Texture boostEffect;             // Allows for a texture to be attached.

    private float spriteSize = 40.0f;       // Set the size of the sprite.

    // Start is called before the first frame update.
    void Start()
    {
        if (playerCamera == null)
        {
            playerCamera = Camera.main;
        }
        // Boosting is set to false by default.
        isBoosting = false;
    }

    // Update is called once per frame.
    void Update()
    {
        HandleBoost();

        // Sets the default position of the player to (0,0) each frame.
        Vector3 pos = new Vector2(x, y);

        /* Gets the inputted value on the horizontal axies and 
         * clamps it to a value between -1 and 1 */
        float move = Mathf.Clamp(Input.GetAxis(horizontalAxis), -1, 1);
        // Sets the x position to increase based off of the calculations done.
        pos += new Vector3(move * speed, 0) * Time.deltaTime;
        /* Gets the inputted value on the vertical axies and 
         * clamps it to a value between -1 and 1 */
        move = Mathf.Clamp(Input.GetAxis(verticalAxis), -1, 1);
        // Sets the y position to increase based off of the calculations done.
        pos += new Vector3(0, move * speed) * Time.deltaTime;

        // Sets a new default position of the player to (0,0) when the player tries to leave the boundary.
        Vector3 newPos = (Vector2)playerCamera.WorldToScreenPoint(transform.position + pos);

        // Applies the calculated translation (pos) to the players position.
        transform.Translate(pos);
    }

    void HandleBoost()
    {
        // If boosting is true...
        if (isBoosting)
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
    }

    //https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Graphics.DrawTexture.html
    void OnGUI()
    {
        // If the player is boosting...
        if (isBoosting && playerCamera != null)
        {
            // a texture is drawn onto the screen to indicate the active effect.
            GUI.DrawTexture(new Rect(0, 0, playerCamera.pixelWidth, playerCamera.pixelHeight), boostEffect);
        }
    }
}
