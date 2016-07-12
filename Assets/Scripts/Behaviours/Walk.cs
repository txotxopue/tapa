using UnityEngine;
using System.Collections;


/// <summary>
/// Walk script managing the movement of the player.
/// Translates the character in the directions read from the input.
/// </summary>
public class Walk : AbstractBehaviour
{
    /// <summary> Speed of the character </summary>
    public float _speed = 50f;
	
	// Update is called once per frame
	void Update ()
    {
        // get inputs
        var up = _inputState.GetButtonValue(_inputButtons[0]);
        var down = _inputState.GetButtonValue(_inputButtons[1]);
        var right = _inputState.GetButtonValue(_inputButtons[2]);
        var left = _inputState.GetButtonValue(_inputButtons[3]);

        float velX = 0;
        float velY = 0;
        if (right)
        {
            velX = 1f;
        }
        else if (left)
        {
            velX = -1f;
        }
        if (up)
        {
            velY = 1f;
        }
        else if (down)
        {
            velY = -1f;
        }

        var movement = new Vector2(velX, velY).normalized * _speed;

        _body2d.velocity = movement;
    }
}
