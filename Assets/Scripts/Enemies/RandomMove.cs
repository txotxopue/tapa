using UnityEngine;
using System.Collections;
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
                ChooseDirection();
                Move();
                break;
            default:
                break;
        }        
    }

    private void ChooseDirection()
    {
        var values = Enum.GetValues(typeof(EDirections));
        var index = UnityEngine.Random.Range(0, values.Length);
        this.currentDirection = (EDirections)values.GetValue(index);
    }

    private void Move()
    {
        if (this.myBody2D != null)
        {
            var velX = 0f;
            var velY = 0f;
            switch (currentDirection)
            {
                case EDirections.Up:
                    velY = 1f;
                    break;
                case EDirections.UpRight:
                    velY = 1f;
                    velX = 1f;
                    break;
                case EDirections.Right:
                    velX = 1f;
                    break;
                case EDirections.DownRight:
                    velY = -1f;
                    velX = 1f;
                    break;
                case EDirections.Down:
                    velY = -1f;
                    break;
                case EDirections.DownLeft:
                    velY = -1f;
                    velX = -1f;
                    break;
                case EDirections.Left:
                    velX = -1f;
                    break;
                case EDirections.UpLeft:
                    velY = 1f;
                    velX = -1f;
                    break;
            }
            var movement = new Vector2(velX, velY).normalized * this.speed;
            this.myBody2D.velocity = movement;
        }
    }

    private void Wait()
    {
        float velX = 0f;
        float velY = 0f;
        var movement = new Vector2(velX, velY).normalized;
        this.myBody2D.velocity = movement;
    }
}
