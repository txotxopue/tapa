﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BambooShooter : AbstractBehaviour
{
    public GameObject projectilePrefab;
    public float shootCD = .5f;
    public bool canShoot = true;

    private InputState stateScript;
    private List<GameObject> projectileSpawns;
    

    protected override void Awake ()
    {
        base.Awake();
        this.stateScript = GetComponent<InputState>();
        this.projectileSpawns = new List<GameObject>();
        for (int i = 0; i < this.transform.childCount; i++)
        {
            var go = this.transform.GetChild(i);
            if (go.name.Contains("Projectile"))
            {
                this.projectileSpawns.Add(go.gameObject);
            }
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        var shoot = _inputState.GetButtonValue(_inputButtons[0]);

        if (this.canShoot && shoot)
        {
            var spawnPos = this.projectileSpawns[(int) this.stateScript._direction].transform.position;
            print(spawnPos);
            var projectile = Instantiate(this.projectilePrefab);
            projectile.transform.position = spawnPos;
            this.canShoot = false;
            StartCoroutine(RestoreShoot());
        }
    }

    private IEnumerator RestoreShoot()
    {
        yield return new WaitForSeconds(shootCD);
        this.canShoot = true;
    }
}