using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public int damage = 1;
    public bool isEnemy = false;
    public GameObject particlePrefab;

	void OnTriggerEnter2D (Collider2D other)
    {
        //print("projectile collided");
        var healthScript = other.gameObject.GetComponent<Health>() as Health;
        if (healthScript != null && this.isEnemy != healthScript.isEnemy)
        {
            //print("Take damage " + damage);
            healthScript.TakeDamage(damage);
            Impact();
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Walls"))
        {
            Impact();
        }
        
    }

    private void Impact()
    {
        GameObjectUtil.Instantiate(this.particlePrefab, this.transform.GetChild(0).position, Vector3.zero);
        GameObjectUtil.Destroy(this.gameObject);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.GetChild(0).position, 3f);
    }
}
