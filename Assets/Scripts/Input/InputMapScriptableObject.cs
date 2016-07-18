using UnityEngine;

[CreateAssetMenu]
public class InputMapScriptableObject : ScriptableObject
{    
    /// <summary> List of all the inputs and their mapped virtual input </summary>
    public InputAxisState[] inputs;    
}
