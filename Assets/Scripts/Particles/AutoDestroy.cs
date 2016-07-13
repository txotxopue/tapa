using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour
{
    public float timeToLive = 0.5f;

	// Use this for initialization
	void Start ()
    {
        Destroy(gameObject, timeToLive);
	}
}
