using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public struct ColliderStruct
{
    public EDirections direction;
    public Vector2 position;
    public bool isClear;
}


public class ColliderState : MonoBehaviour
{ 
    public LayerMask collisionLayer;
    public ColliderStruct[] colliders;
    public float collisionRadius = 7f;
    public Color debugCanSpawnColor = Color.green;
    public Color debugCannotSpawnColor = Color.red;


    private bool IsColliderClear(ColliderStruct pCollider)
    {
        var pos = pCollider.position;
        pos.x += this.transform.position.x;
        pos.y += this.transform.position.y;
        return !Physics2D.OverlapCircle(pos, this.collisionRadius, this.collisionLayer);
    }


    public List<ColliderStruct> GetClearColliders()
    {
        var clearColliders = new List<ColliderStruct>();
        for (int i = 0; i < this.colliders.Length; i++)
        {
            this.colliders[i].isClear = IsColliderClear(this.colliders[i]);
            if (this.colliders[i].isClear)
            {
                clearColliders.Add(this.colliders[i]);
            }
        }
        return clearColliders;
    }
    

    void OnDrawGizmos()
    {
        foreach (var collider in this.colliders)
        {
            var pos = collider.position;
            pos.x += transform.position.x;
            pos.y += transform.position.y;
            Gizmos.color = collider.isClear ? this.debugCanSpawnColor : this.debugCannotSpawnColor;
            Gizmos.DrawWireSphere(pos, this.collisionRadius);
        }
    }
}
