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
        var shoot = inputState.GetButtonValue(inputButtons[0]);

        if (this.canShoot && shoot)
        {
            var spawnPos = this.projectileSpawns[(int) this.stateScript.direction].transform.position;
            var rotation = new Vector3(0, 0, GetProjectileRotation(this.stateScript.direction));
            GameObjectUtil.Instantiate(this.projectilePrefab, spawnPos, rotation);
            
            this.canShoot = false;
            StartCoroutine(RestoreShoot());
        }
    }


    private float GetProjectileRotation(EDirections pDirection)
    {
        switch (pDirection)
        {
            case EDirections.Up:
                return 0f;
            case EDirections.Down:
                return 180f;
            case EDirections.Right:
                return 270f;
            case EDirections.Left:
                return 90f;
            case EDirections.UpRight:
                return 315f;
            case EDirections.UpLeft:
                return 45f;
            case EDirections.DownRight:
                return 225f;
            case EDirections.DownLeft:
                return 135f;
            default:
                return 0f;              
        }
    }


    private IEnumerator RestoreShoot()
    {
        yield return new WaitForSeconds(shootCD);
        this.canShoot = true;
    }
}
