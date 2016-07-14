using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    public RecycleGameObject prefab;

    private List<RecycleGameObject> poolInstances = new List<RecycleGameObject>();

    private RecycleGameObject CreateInstance(Vector3 pPos, Vector3 pRotation)
    {
        var clone = GameObject.Instantiate(this.prefab);
        clone.transform.position = pPos;
        var rotation = new Quaternion();
        rotation.eulerAngles = pRotation;
        clone.transform.rotation = rotation;
        clone.transform.parent = this.transform;

        this.poolInstances.Add(clone);
        return clone;
    }

    public RecycleGameObject NextObject(Vector3 pPos, Vector3 pRotation)
    {
        RecycleGameObject instance = null;

        foreach(var go in this.poolInstances)
        {
            if (go.gameObject.activeSelf != true)
            {
                instance = go;
                instance.transform.position = pPos;
                var rotation = new Quaternion();
                rotation.eulerAngles = pRotation;
                instance.transform.rotation = rotation;
            }
        }
        if (instance == null)
        {
            instance = CreateInstance(pPos, pRotation);
        }
        instance.Restart();
        return instance;
    }
}
