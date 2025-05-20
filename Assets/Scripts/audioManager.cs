using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    //https://docs.unity3d.com/2020.1/Documentation/ScriptReference/HeaderAttribute.html
    // Creates a divider in the inspector for the audio sources.
    [Header("-----------Audio Source-----------")]
    // Allows you to attach a music source.
    [SerializeField] AudioSource musicSource;
    // Allows you to attach a SFX source.
    [SerializeField] AudioSource SFXSource;

    // Creates a divider in the inspector for the audio clips.
    [Header("-----------Clips Source-----------")]
    public AudioClip background;    // The background music.
    public AudioClip thrusters;     // The sound for the thrusters.
    public AudioClip collect;       // The collection sound effect.
    public AudioClip pew;           // The pew sound effect.
    //https://docs.unity3d.com/6000.0/Documentation/ScriptReference/AudioSource-clip.html

    private void Start()
    {
        // Plays the background music when the game starts.
        musicSource.clip = background;
        musicSource.Play();
    }

    void Update()
    {
        //https://youtu.be/A8AfFgOZvQ4
        // If the player moves in any direction, the thruster sound effect will be played.
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            SFXSource.clip = thrusters;     // Loads the thruster sound effect into the SFXSource.
            SFXSource.Play();               // Plays the sound effect loaded into the SFXSource.
        }

        // If cargo is collected...
        if (cargo.cargoCollected == true)
        {
            SFXSource.clip = collect;               // the collect sound is loaded...
            SFXSource.Play();                       // the sound is played...
            Debug.Log("Collected audio played.");   // and a message is sent to the Debug Log.
        }

        if (ships.hasFired == true)
        {
            SFXSource.clip = pew;                   // the zap sound is loaded...
            SFXSource.Play();                       // the sound is played...
            Debug.Log("Ship fired lazer.");         // and a message is sent to the Debug Log.
            ships.hasFired = false;
        }
    }
}
