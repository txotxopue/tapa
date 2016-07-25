using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public enum EThinkRandomMoveActions
{
    Wait,
    Move
}

public class RandomMove : EnemyAI
{
    public float speed = 50;

    public EThinkRandomMoveActions currentAction = EThinkRandomMoveActions.Wait;
    public EDirections currentDirection = EDirections.Up;

    private ColliderState colliderState;
    

    protected override void Awake ()
    {
        base.Awake();
        this.colliderState = GetComponent<ColliderState>();

    }


    protected override void Think()
    {
        //Debug.Log("thinking");
        var values = Enum.GetValues(typeof(EThinkRandomMoveActions));
        var index = UnityEngine.Random.Range(0, values.Length);
        this.currentAction = (EThinkRandomMoveActions)values.GetValue(index);

        switch(this.currentAction)
        {
            case EThinkRandomMoveActions.Wait:
                Wait();
                break;
            case EThinkRandomMoveActions.Move:
                if (ChooseDirection())
                {
                    Move();
                }
                else
                {
                    Wait();
                }
                break;
            default:
                break;
        }        
    }

    private bool ChooseDirection()
    {
        if (colliderState != null)
        {
            var colliders = colliderState.GetClearColliders();
            if (colliders.Count > 0)
            {
                var index = UnityEngine.Random.Range(0, colliders.Count);
                this.currentDirection = colliders[index].direction;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    private void Move()
    {
        switch (this.currentDirection)
        {
            case EDirections.Up:
                this.inputState.SetButtonValue(EButtons.Up, true);
                this.inputState.SetButtonValue(EButtons.Right, false);
                this.inputState.SetButtonValue(EButtons.Down, false);
                this.inputState.SetButtonValue(EButtons.Left, false);
                break;
            case EDirections.UpRight:
                this.inputState.SetButtonValue(EButtons.Up, true);
                this.inputState.SetButtonValue(EButtons.Right, true);
                this.inputState.SetButtonValue(EButtons.Down, false);
                this.inputState.SetButtonValue(EButtons.Left, false);
                break;
            case EDirections.Right:
                this.inputState.SetButtonValue(EButtons.Up, false);
                this.inputState.SetButtonValue(EButtons.Right, true);
                this.inputState.SetButtonValue(EButtons.Down, false);
                this.inputState.SetButtonValue(EButtons.Left, false);
                break;
            case EDirections.DownRight:
                this.inputState.SetButtonValue(EButtons.Up, false);
                this.inputState.SetButtonValue(EButtons.Right, true);
                this.inputState.SetButtonValue(EButtons.Down, true);
                this.inputState.SetButtonValue(EButtons.Left, false);
                break;
            case EDirections.Down:
                this.inputState.SetButtonValue(EButtons.Up, false);
                this.inputState.SetButtonValue(EButtons.Right, false);
                this.inputState.SetButtonValue(EButtons.Down, true);
                this.inputState.SetButtonValue(EButtons.Left, false);
                break;
            case EDirections.DownLeft:
                this.inputState.SetButtonValue(EButtons.Up, false);
                this.inputState.SetButtonValue(EButtons.Right, false);
                this.inputState.SetButtonValue(EButtons.Down, true);
                this.inputState.SetButtonValue(EButtons.Left, true);
                break;
            case EDirections.Left:
                this.inputState.SetButtonValue(EButtons.Up, false);
                this.inputState.SetButtonValue(EButtons.Right, false);
                this.inputState.SetButtonValue(EButtons.Down, false);
                this.inputState.SetButtonValue(EButtons.Left, true);
                break;
            case EDirections.UpLeft:
                this.inputState.SetButtonValue(EButtons.Up, true);
                this.inputState.SetButtonValue(EButtons.Right, false);
                this.inputState.SetButtonValue(EButtons.Down, false);
                this.inputState.SetButtonValue(EButtons.Left, true);
                break;
        }
    }

    private void Wait()
    {
        this.inputState.SetButtonValue(EButtons.Up, false);
        this.inputState.SetButtonValue(EButtons.Right, false);
        this.inputState.SetButtonValue(EButtons.Down, false);
        this.inputState.SetButtonValue(EButtons.Left, false);
    }
}
