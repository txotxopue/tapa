using UnityEngine;
using System.Collections;

public class DamageOnCollision : MonoBehaviour
{
    public int damageOnCollision = 1;

    private Health healthScript;

    void Awake()
    {
        this.healthScript = GetComponent<Health>();
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            this.healthScript.TakeDamage(this.damageOnCollision);
        }
    }
}
