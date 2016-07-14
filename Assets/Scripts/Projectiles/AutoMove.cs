using UnityEngine;
using System.Collections;

public class AutoMove : MonoBehaviour, IRecycle
{
    public int speed = 500;

    private Rigidbody2D body2D;

	void Awake ()
    {
        this.body2D = GetComponent<Rigidbody2D>();
    }
	
    public void Restart ()
    {
        var movement = this.speed * this.transform.up * Time.deltaTime;
        this.body2D.velocity = movement;
    }

    public void Shutdown()
    {

    }
}
