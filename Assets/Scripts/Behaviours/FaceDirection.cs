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
        var right = _inputState.GetButtonValue(_inputButtons[0]);
        var left = _inputState.GetButtonValue(_inputButtons[1]);

        if (right)
        {
            _inputState._direction = EDirections.Right;
        }
        else if (left)
        {
            _inputState._direction = EDirections.Left;
        }

        // Mirrors the character if we are looking to the left
        transform.localScale = new Vector3((float)_inputState._direction, 1, 1);
    }
}
