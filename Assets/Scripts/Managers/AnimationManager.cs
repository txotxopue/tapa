using UnityEngine;
using System.Collections;

/// <summary>
/// Class that handles the different animations of the character
/// by looking at the state of the other components.
/// </summary>
public class AnimationManager : MonoBehaviour
{
    private InputState _inputState;
    private Walk _walkBehaviour;
    private Animator _animator;
    //private CollisionState collisionState;


    void Awake()
    {
        _inputState = GetComponent<InputState>();
        _animator = GetComponent<Animator>();
        //collisionState = GetComponent<CollisionState>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        /*
	    if (collisionState.standing)
        {
            ChangeAnimationState(0);
        }
        */
        if (_inputState._absVelX > 0)
        {
            ChangeAnimationState(1);
        }
        if (_inputState._absVelY > 0)
        {
            ChangeAnimationState(2);
        }
    }

    private void ChangeAnimationState(int value)
    {
        _animator.SetInteger("AnimState", value);
    }
}
