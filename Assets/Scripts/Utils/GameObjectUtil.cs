using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameObjectUtil
{
    private static Dictionary<RecycleGameObject, ObjectPool> pools = new Dictionary<RecycleGameObject, ObjectPool>();

    public static GameObject Instantiate(GameObject pPrefab, Vector3 pPos, Vector3 pRotation)
    {
        GameObject instance = null;
        var recycledScript = pPrefab.GetComponent<RecycleGameObject>();
        if (recycledScript != null)
        {
            var pool = GetObjectPool(recycledScript);
            instance = pool.NextObject(pPos, pRotation).gameObject;
        }
        else
        {
            instance = GameObject.Instantiate(pPrefab);
            instance.transform.position = pPos;
            var rotation = new Quaternion();
            rotation.eulerAngles = pRotation;
            instance.transform.rotation = rotation;
        }


        return instance;
    }

    public static void Destroy(GameObject pGameObject)
    {
        var recycleGameObject = pGameObject.GetComponent<RecycleGameObject>();

        if (recycleGameObject != null)
        {
            recycleGameObject.Shutdown();
        }
        else
        {
            GameObject.Destroy(pGameObject);
        }
    }


    private static ObjectPool GetObjectPool(RecycleGameObject pReference)
    {
        ObjectPool pool = null;
        if (GameObjectUtil.pools.ContainsKey(pReference))
        {
            pool = GameObjectUtil.pools[pReference];
        }
        else
        {
            var poolContainer = new GameObject(pReference.gameObject.name + "ObjectPool");
            pool = poolContainer.AddComponent<ObjectPool>();
            pool.prefab = pReference;
            GameObjectUtil.pools.Add(pReference, pool);
        }

        return pool;
    }
}
