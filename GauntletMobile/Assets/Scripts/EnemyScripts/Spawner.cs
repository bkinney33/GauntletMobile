using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    [System.Serializable]
    public struct SpawnInfo
    {
        public GameObject spawnableMob;
        [Tooltip("First float is the minimum distance from the spawner something can spawn. The second float is the max distance from the spawner something can spawn.")]
        public Vector2 minAndMaxRange;
        public float timeBeforeSpawn;
        [Tooltip("Set to 0 to allow uncapped spawning of this mob type.")]
        public int maxMobCount;
        public ObjectPool projectiles;
    }

    [SerializeField]
    SpawnInfo info;
    float lastTick;
    List<GameObject> entityPool;
    Transform player;
    public bool active = false;

	// Use this for initialization
	void Start () {
        entityPool = new List<GameObject>();
		for(int i = 0; i < info.maxMobCount; ++i)
        {
            GameObject g = Instantiate(info.spawnableMob);
            BasicRangedEnemy bre = g.GetComponentInChildren<BasicRangedEnemy>();
            if (bre != null)
            {
                bre.projectilePool = info.projectiles;
            }
            g.SetActive(false);
            entityPool.Add(g);
        }
        player = GameObject.FindGameObjectWithTag("Player").transform.root;
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.root == player)
        {
            active = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.root == player)
        {
            active = false;
        }
    }
    public GameObject GetPooledObject()
    {
        //1
        for (int i = 0; i < entityPool.Count; i++)
        {
            //2
            if (!entityPool[i].activeInHierarchy)
            {
                return entityPool[i];
            }
        }
        //3   
        return null;
    }
    // Update is called once per frame
    void Update () {
        if (active) {
            if (lastTick + info.timeBeforeSpawn < Time.time)
            {
                lastTick = Time.time;
                GameObject g = GetPooledObject();
                if (g != null)
                {
                    g.transform.position = Random.insideUnitCircle * (Random.Range(info.minAndMaxRange.x, info.minAndMaxRange.y));
                    g.transform.Translate(transform.position);
                    EnemyMovement em = g.GetComponentInChildren<EnemyMovement>();
                    if (em != null) { em.SetTarget(player); }
                    g.SetActive(true);
                }
            }
        }
	}
}
