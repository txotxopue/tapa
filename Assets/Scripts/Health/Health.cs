﻿using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour, IRecycle
{
    public int maxHP = 10;
    public int currentHP;
    public bool isEnemy = false;
    public bool isDead = false;
    public bool isHit = false;
    public float hitCD = 1f;
    public GameObject deadParticlesPrefab;

    public delegate void OnHit();
    public event OnHit HitCallback;
    public delegate void OnDead();
    public event OnDead DeadCallback;

    // Use this for initialization
    void Start ()
    {
        Restart();
	}
	
    public void Restart()
    {
        this.currentHP = this.maxHP;
        this.isDead = false;
        this.isHit = false;
    }

    public void Shutdown()
    {

    }

    public void TakeDamage(int pAmount)
    {
        if (!this.isDead && !this.isHit)
        {
            //print("Hit by " + pAmount);
            this.currentHP -= pAmount;
            if (this.currentHP <= 0)
            {
                this.currentHP = 0;
                if (!this.isDead) Die();
            }
            else
            {
                this.isHit = true;
                StartCoroutine(RestoreHit());
            }
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

    private void Die()
    {
        this.isDead = true;
        if (this.DeadCallback != null) DeadCallback();
        //whatever
        GameObjectUtil.Instantiate(this.deadParticlesPrefab, this.transform.position, Vector3.zero);
        GameObjectUtil.Destroy(this.gameObject);
        //this.gameObject.SetActive(false);
    }

    private IEnumerator RestoreHit()
    {
        yield return new WaitForSeconds(this.hitCD);
        this.isHit = false;
    }
}
