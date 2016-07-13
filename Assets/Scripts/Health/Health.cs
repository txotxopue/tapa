using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    public int maxHP = 10;
    public int currentHP;
    public bool isEnemy = false;
    public bool isDead = false;
    public bool isHit = false;
    public float hitCD = 1f;

	// Use this for initialization
	void Start ()
    {
        InitHealth();
	}
	
    private void InitHealth()
    {
        this.currentHP = this.maxHP;
        this.isDead = false;
        this.isHit = false;
    }

    public void TakeDamage(int pAmount)
    {
        if (!this.isDead && !this.isHit)
        {
            print("Hit by " + pAmount);
            this.currentHP -= pAmount;
            if (this.currentHP < 0)
            {
                this.currentHP = 0;
                this.isDead = true;
            }
            this.isHit = true;
            StartCoroutine(RestoreHit());
        }
    }

    public void Heal(int pAmount)
    {
        if (!this.isDead)
        {
            this.currentHP += pAmount;
            if (this.currentHP > this.maxHP)
            {
                this.currentHP = this.maxHP;
            }
        }
    }

    private IEnumerator RestoreHit()
    {
        yield return new WaitForSeconds(hitCD);
        this.isHit = false;
    }
}
