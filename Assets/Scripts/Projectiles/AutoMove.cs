using UnityEngine;
using System.Collections;

public class AutoMove : MonoBehaviour, IRecycle
{
    public int speed = 500;

    private Rigidbody2D body2D;

	void Awake ()
    {
        body2D = GetComponent<Rigidbody2D>();
    }
	
    public void Restart ()
    {
        var movement = speed * transform.up * Time.deltaTime;
        body2D.velocity = movement;
    }

    public void Shutdown()
    {

    }

	// Update is called once per frame
	void FixedUpdate ()
    {
        //transform.Translate(movement);
	}
}
