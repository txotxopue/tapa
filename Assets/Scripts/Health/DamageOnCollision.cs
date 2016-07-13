using UnityEngine;
using System.Collections;

public class DamageOnCollision : MonoBehaviour
{
    public int _damageOnCollision = 1;

    private Health _healthScript;

    void Awake()
    {
        _healthScript = GetComponent<Health>();
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            _healthScript.TakeDamage(_damageOnCollision);
        }
    }
}
