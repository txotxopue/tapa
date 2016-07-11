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
        var right = _inputState.GetButtonValue(_inputButtons[0]);
        var left = _inputState.GetButtonValue(_inputButtons[1]);

        if (right || left)
        {
            var velX = _speed * (float)_inputState._direction;
            _body2d.velocity = new Vector2(velX, _body2d.velocity.y);
        }
    }
}
