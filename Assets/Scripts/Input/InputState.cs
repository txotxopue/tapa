﻿using UnityEngine;
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
    Right = 1,
    Left = -1
}


/// <summary>
/// Class holding the state of the virtual buttons needed to control our character.
/// </summary>
public class InputState : MonoBehaviour
{
    /// <summary> The direction we are facing </summary>
    public EDirections _direction = EDirections.Right;
    /// <summary> The current absolute horizontal velocity </summary>
    public float _absVelX;
    /// <summary> The current absolute vertical velocity </summary>
    public float _absVelY;

    /// <summary> Reference to the character Rigidbody2D </summary>
    private Rigidbody2D _body2d;
    /// <summary> The list of the virtual buttons used by the character and their current state </summary>
    private Dictionary<EButtons, ButtonState> _buttonStates = new Dictionary<EButtons, ButtonState>();

    void Awake()
    {
        _body2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        _absVelX = Mathf.Abs(_body2d.velocity.x);
        _absVelY = Mathf.Abs(_body2d.velocity.y);
    }

    /// <summary>
    /// Method to set the value of a given virtual input.
    /// Its called from the input manager, who reads the actual inputs.
    /// </summary>
    /// <param name="key">Virtual button key to set</param>
    /// <param name="value">Button value to set</param>
    public void SetButtonValue(EButtons key, bool value)
    {
        if (!_buttonStates.ContainsKey(key))
        {
            _buttonStates.Add(key, new ButtonState());
        }
        var state = _buttonStates[key];

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
        if (_buttonStates.ContainsKey(key))
        {
            return _buttonStates[key].bPressed;
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
        if (_buttonStates.ContainsKey(key))
        {
            return _buttonStates[key].holdTime;
        }
        else
        {
            return 0f;
        }
    }
}