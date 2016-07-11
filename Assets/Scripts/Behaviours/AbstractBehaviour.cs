using UnityEngine;
using System.Collections;


/// <summary>
/// Abstract class for our character behaviours.
/// It holds a list of virtual buttons that our behaviours
/// may need to perform their actions.
/// Also contains a list of other behaviours that may need to be disabled in certain case.
/// And the reference to the input state and the rigidbody that every behaviour will use.
/// </summary>
public abstract class AbstractBehaviour : MonoBehaviour
{
    /// <summary> List of virtual buttons needed by this behaviour </summary>
    public EButtons[] _inputButtons;
    /// <summary> List of behaviours that this behaviour must disable when performing certain action </summary>
    public MonoBehaviour[] _disableScripts;

    /// <summary> Reference to the input state, needed to read the neccesary virtual buttons </summary>
    protected InputState _inputState;
    /// <summary> Rigidbody2D reference, needed to transform the character </summary>
    protected Rigidbody2D _body2d;
    //protected CollisionState collisionState;

    protected virtual void Awake()
    {
        _inputState = GetComponent<InputState>();
        _body2d = GetComponent<Rigidbody2D>();
        //collisionState = GetComponent<CollisionState>();
    }

    /// <summary>
    /// Method to enable/disable all the behaviours in the disable list
    /// </summary>
    /// <param name="value">true to enable the behaviours, or false to disable them</param>
    protected virtual void ToggleScripts(bool value)
    {
        foreach (var script in _disableScripts)
        {
            script.enabled = value;
        }
    }
}
