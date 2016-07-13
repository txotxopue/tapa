using UnityEngine;
using System.Collections;

public class AutoMove : MonoBehaviour
{
    public int speed = 500;

    private Rigidbody2D body2D;

	void Awake ()
    {
        body2D = GetComponent<Rigidbody2D>();
    }
	
    void Start ()
    {
        var movement = speed * transform.up * Time.deltaTime;
        body2D.velocity = movement;
    }

	// Update is called once per frame
	void FixedUpdate ()
    {
        //transform.Translate(movement);
	}
}
