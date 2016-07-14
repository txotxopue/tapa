using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour, IRecycle
{
    public float timeToLive = 0.5f;
    private float elapsedTime = 0f;

	public void Restart()
    {
        this.elapsedTime = 0f;
    }

    public void Shutdown()
    {

    }

	void Update ()
    {
        this.elapsedTime += Time.deltaTime;
        if (this.elapsedTime >= this.timeToLive) GameObjectUtil.Destroy(gameObject);
	}
}
