using UnityEngine;
using System.Collections;


/// <summary>
/// Virtual buttons enum to refer input 
/// by any behaviour from any player
/// </summary>
public enum EButtons
{
    Right,
    Left,
    Up,
    Down,
    A,
    B
}


/// <summary>
/// Enum of conditions that 
/// can be checked in input
/// </summary>
public enum ECondition
{
    GreaterThan,
    LessThan
}


/// <summary>
/// Structure containing an input axis, the virtual input 
/// which is mapped to and the condition. Also by requesting
/// the value, the input axis value is retrieved.
/// </summary>
[System.Serializable]
public class InputAxisState
{
    /// <summary> The axis to read from the unity input system </summary>
    public string _axisName;
    /// <summary> The limit value to consider the input pressed </summary>
    public float _offValue;
    /// <summary> Condition to consider the button pressed </summary>
    public ECondition _condition;
    /// <summary> The virtual button which this input is mapped to </summary>
    public EButtons _button;
    

    /// <summary>
    /// This property reads the axis from the unity input system,
    /// considering the given condition and limit value.
    /// </summary>
    public bool value
    {
        get
        {
            var val = Input.GetAxis(_axisName);
            switch (_condition)
            {
                case ECondition.GreaterThan:
                    return val > _offValue;
                case ECondition.LessThan:
                    return val < _offValue;
            }

            return false;
        }
    }
}


/// <summary>
/// Class that reads all the given inputs for a character and
/// passes their values to the given virtual button in the input state.
/// You can have one of this managers for each player and map the inputs to the same virtual inputs.
/// </summary>
public class InputManager : MonoBehaviour
{
    /// <summary> List of all the inputs and their mapped virtual input </summary>
    public InputAxisState[] _inputs;
    /// <summary> Reference to the input state which we will pass all the input results to </summary>
    public InputState inputState;
	
	// Update is called once per frame
	void Update ()
    {
        // We run through every mapped input and set its value in the input state
	    foreach (InputAxisState input in _inputs)
        {
            if (this.inputState != null) inputState.SetButtonValue(input._button, input.value);
        }
	}
}
