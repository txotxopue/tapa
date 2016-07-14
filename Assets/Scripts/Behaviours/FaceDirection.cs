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
        var up = this.inputState.GetButtonValue(this.inputButtons[0]);
        var down = this.inputState.GetButtonValue(this.inputButtons[1]);
        var right = this.inputState.GetButtonValue(this.inputButtons[2]);
        var left = this.inputState.GetButtonValue(this.inputButtons[3]);

        if (up)
        {
            if (right)
            {
                this.inputState._direction = EDirections.UpRight;
            }
            else if (left)
            {
                this.inputState._direction = EDirections.UpLeft;
            }
            else
            {
                this.inputState._direction = EDirections.Up;
            }
        }
        else if (down)
        {
            if (right)
            {
                this.inputState._direction = EDirections.DownRight;
            }
            else if (left)
            {
                this.inputState._direction = EDirections.DownLeft;
            }
            else
            {
                this.inputState._direction = EDirections.Down;
            }
        }
        else if (right)
        {
            this.inputState._direction = EDirections.Right;
        }
        else if (left)
        {
            this.inputState._direction = EDirections.Left;
        }

        // Mirrors the character if we are looking to the left
        //transform.localScale = new Vector3((float)_inputState._direction, 1, 1);
    }
}
