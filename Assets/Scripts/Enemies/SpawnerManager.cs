using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public struct SpawnerStruct
{
    public string name;
    public Vector2 spawnerPosition;
    public bool canSpawn;
}

public class SpawnerManager : MonoBehaviour, IRecycle
{
    public float spawnTime;
    public int spawnsWaiting = 1;
    public GameObject enemyPrefab;
    public LayerMask collisionLayer;
    public SpawnerStruct[] spawners;
    public float collisionRadius = 7f;
    public Color debugCanSpawnColor = Color.green;
    public Color debugCannotSpawnColor = Color.red;

    private Coroutine spawnerCoroutine;
    private int initialSpawnsWaiting;

    void Start()
    {
        this.initialSpawnsWaiting = this.spawnsWaiting;
        Restart();
    }

    public void Restart()
    {
        this.spawnsWaiting = this.initialSpawnsWaiting;
        this.spawnerCoroutine = StartCoroutine(Spawner());
    }

    public void Shutdown()
    {
        StopCoroutine(this.spawnerCoroutine);
    }

    private bool CanSpawn(SpawnerStruct pSpawner)
    {
        var pos = pSpawner.spawnerPosition;
        pos.x += transform.position.x;
        pos.y += transform.position.y;
        return !Physics2D.OverlapCircle(pos, collisionRadius, collisionLayer);
    }

    void OnDrawGizmos()
    {
        foreach ( var spawner in this.spawners )
        {
            var pos = spawner.spawnerPosition;
            pos.x += transform.position.x;
            pos.y += transform.position.y;
            Gizmos.color = spawner.canSpawn ? this.debugCanSpawnColor : this.debugCannotSpawnColor;
            Gizmos.DrawWireSphere(pos, this.collisionRadius); 
        }
    }

    private IEnumerator Spawner()
    {
        while (true)
        {
            var availableSpawners = new List<SpawnerStruct>();
            for (int i = 0; i < this.spawners.Length; i++)
            {
                this.spawners[i].canSpawn = CanSpawn(this.spawners[i]);
                if (this.spawners[i].canSpawn)
                {
                    availableSpawners.Add(this.spawners[i]);
                }
            }
            
            RandomizeSpawnersList(availableSpawners);
            for (int i = 0; this.spawnsWaiting > 0 && i < availableSpawners.Count; i++)
            {
                this.SpawnEnemy(availableSpawners[i]);
                this.spawnsWaiting--;    
            }
            this.spawnsWaiting++;
            yield return new WaitForSeconds(this.spawnTime);
        }
    }

    public void SpawnEnemy(SpawnerStruct pSpawner)
    {
        //Debug.Log("Enemy spawned at " + name);
        var pos = pSpawner.spawnerPosition;
        pos.x += transform.position.x;
        pos.y += transform.position.y;
        GameObjectUtil.Instantiate(this.enemyPrefab, pos, Vector3.zero);
    }

    public void RandomizeSpawnersList(List<SpawnerStruct> pSpawners)
    {
        for (var i = 0; i < pSpawners.Count; i++)
        {
            var tmp = pSpawners[i];
            var r = Random.Range(i, pSpawners.Count);
            pSpawners[i] = pSpawners[r];
            pSpawners[r] = tmp;
        }
    }
}
