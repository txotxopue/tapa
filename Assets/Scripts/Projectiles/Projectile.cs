using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public int damage = 1;
    public bool isEnemy = false;
    public GameObject particlePrefab;

	void OnTriggerEnter2D (Collider2D other)
    {
        print("projectile collided");
        var healthScript = other.gameObject.GetComponent<Health>() as Health;
        if (healthScript != null && this.isEnemy != healthScript.isEnemy)
        {
            print("Take damage " + damage);
            healthScript.TakeDamage(damage);
            Die();
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Walls"))
        {
            Die();
        }
        
    }

    private void Die()
    {
        var go = Instantiate(this.particlePrefab);
        go.transform.position = this.transform.GetChild(0).position;
        Destroy(this.gameObject);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.GetChild(0).position, 3f);
    }
}
