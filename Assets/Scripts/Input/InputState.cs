using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// Structure containing if a button is pressed and for how long.
/// </summary>
public class ButtonState
{
    /// <summary> Is the button pressed? </summary>
    public bool bPressed;
    /// <summary> The time the button has been hold down </summary>
    public float holdTime = 0;
}


/// <summary>
/// An Enum with the 4 possible direction a character may be facing.
/// </summary>
public enum EDirections
{
    Up = 0,
    Down = 1,
    Right = 2,
    Left = 3,
    UpRight = 4,
    UpLeft = 5,
    DownRight = 6,
    DownLeft = 7
}


/// <summary>
/// Class holding the state of the virtual buttons needed to control our character.
/// </summary>
public class InputState : MonoBehaviour
{
    /// <summary> The direction we are facing </summary>
    public EDirections direction = EDirections.Right;
    /// <summary> The current absolute horizontal velocity </summary>
    public float absVelX;
    /// <summary> The current absolute vertical velocity </summary>
    public float absVelY;

    /// <summary> Reference to the character Rigidbody2D </summary>
    private Rigidbody2D body2d;
    /// <summary> The list of the virtual buttons used by the character and their current state </summary>
    private Dictionary<EButtons, ButtonState> buttonStates = new Dictionary<EButtons, ButtonState>();

    void Awake()
    {
        this.body2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        this.absVelX = Mathf.Abs(this.body2d.velocity.x);
        this.absVelY = Mathf.Abs(this.body2d.velocity.y);
    }

    /// <summary>
    /// Method to set the value of a given virtual input.
    /// Its called from the input manager, who reads the actual inputs.
    /// </summary>
    /// <param name="key">Virtual button key to set</param>
    /// <param name="value">Button value to set</param>
    public void SetButtonValue(EButtons key, bool value)
    {
        if (!this.buttonStates.ContainsKey(key))
        {
            this.buttonStates.Add(key, new ButtonState());
        }
        var state = this.buttonStates[key];

        // Reset the holdtime when the button is pressed after being non pressed
        if (state.bPressed && !value)
        {
            state.holdTime = 0;
        }
        // if it was pressed, udpate the hold time
        else if (state.bPressed && value)
        {
            state.holdTime += Time.deltaTime;
        }
        state.bPressed = value;

    }

    /// <summary>
    /// Read if the given button is pressed or not
    /// </summary>
    /// <param name="key">Virtual button to read</param>
    /// <returns>True if the button is pressed, or false if not</returns>
    public bool GetButtonValue(EButtons key)
    {
        if (this.buttonStates.ContainsKey(key))
        {
            return this.buttonStates[key].bPressed;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Read for how long the given button have been pressed
    /// </summary>
    /// <param name="key">Virtual button to read</param>
    /// <returns>the time in seconds that the button have been pressed</returns>
    public float GetButtonHoldTime(EButtons key)
    {
        if (this.buttonStates.ContainsKey(key))
        {
            return this.buttonStates[key].holdTime;
        }
        else
        {
            return 0f;
        }
    }
}
