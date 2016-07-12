using UnityEngine;
using System.Collections;


/// <summary>
/// Script updating the facing direction of a character
/// accordingly to the input read.
/// </summary>
public class FaceDirection : AbstractBehaviour
{	
	// Update is called once per frame
	void Update ()
    {
        var up = _inputState.GetButtonValue(_inputButtons[0]);
        var down = _inputState.GetButtonValue(_inputButtons[1]);
        var right = _inputState.GetButtonValue(_inputButtons[2]);
        var left = _inputState.GetButtonValue(_inputButtons[3]);

        if (up)
        {
            _inputState._direction = EDirections.Up;
        }
        else if (down)
        {
            _inputState._direction = EDirections.Down;
        }
        if (right)
        {
            _inputState._direction = EDirections.Right;
        }
        else if (left)
        {
            _inputState._direction = EDirections.Left;
        }

        // Mirrors the character if we are looking to the left
        //transform.localScale = new Vector3((float)_inputState._direction, 1, 1);
    }
}
