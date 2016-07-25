using UnityEngine;
using System.Collections;


public abstract class EnemyAI : MonoBehaviour, IRecycle
{
    public float thinkTime = 1f;

    protected Coroutine thinkCoroutine;
    /// <summary> Reference to the input state which we will pass all the input results to </summary>
    protected InputState inputState;

    protected virtual void Awake ()
    {
        this.inputState = GetComponent<InputState>();
    }

	// Use this for initialization
	void Start ()
    {
        Restart();
	}


    public void Restart()
    {
        StartCoroutine(RandomDelayedLoop());
    }


    public void Shutdown()
    {
        if (thinkCoroutine != null) StopCoroutine(thinkCoroutine);
    }
	

    private IEnumerator ThinkLoop()
    {
        while (true)
        {
            Think();
            yield return new WaitForSeconds(this.thinkTime);
        }
    }

    private IEnumerator RandomDelayedLoop()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(0f, this.thinkTime));
        this.thinkCoroutine = StartCoroutine(ThinkLoop());
    }

    protected abstract void Think();
}
