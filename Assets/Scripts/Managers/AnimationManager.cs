using UnityEngine;
using System.Collections;

/// <summary>
/// Class that handles the different animations of the character
/// by looking at the state of the other components.
/// </summary>
public class AnimationManager : MonoBehaviour
{
    private InputState inputState;
    private Walk walkBehaviour;
    private Animator animator;
    //private CollisionState collisionState;


    void Awake()
    {
        this.inputState = GetComponent<InputState>();
        this.animator = GetComponent<Animator>();
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
        if (this.inputState._absVelX > 0)
        {
            ChangeAnimationState(1);
        }
        if (this.inputState._absVelY > 0)
        {
            ChangeAnimationState(2);
        }
    }

    private void ChangeAnimationState(int value)
    {
        this.animator.SetInteger("AnimState", value);
    }
}
