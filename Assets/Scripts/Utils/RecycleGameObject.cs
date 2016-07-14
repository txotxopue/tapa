using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IRecycle
{
    void Restart();
    void Shutdown();
}

public class RecycleGameObject : MonoBehaviour
{
    private List<IRecycle> recycleComponents;

    void Awake()
    {
        var components = GetComponents<MonoBehaviour>();
        this.recycleComponents = new List<IRecycle>();
        foreach (var component in components)
        {
            if (component is IRecycle)
            {
                this.recycleComponents.Add(component as IRecycle);
            }
        }
    }

    public void Restart()
    {
        this.gameObject.SetActive(true);
        foreach(var component in recycleComponents)
        {
            component.Restart();
        }
    }

    public void Shutdown()
    {
        this.gameObject.SetActive(false);
        foreach(var component in recycleComponents)
        {
            component.Shutdown();
        }
    }
}
