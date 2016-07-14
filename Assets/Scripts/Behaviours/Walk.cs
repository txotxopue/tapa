using UnityEngine;
using System.Collections;


/// <summary>
/// Walk script managing the movement of the player.
/// Translates the character in the directions read from the input.
/// </summary>
public class Walk : AbstractBehaviour
{
    /// <summary> Speed of the character </summary>
    public float speed = 50f;
	
	// Update is called once per frame
	void Update ()
    {
        // get inputs
        var up = this.inputState.GetButtonValue(this.inputButtons[0]);
        var down = this.inputState.GetButtonValue(this.inputButtons[1]);
        var right = this.inputState.GetButtonValue(this.inputButtons[2]);
        var left = this.inputState.GetButtonValue(this.inputButtons[3]);

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

        var movement = new Vector2(velX, velY).normalized * this.speed;

        this.body2d.velocity = movement;
    }
}
