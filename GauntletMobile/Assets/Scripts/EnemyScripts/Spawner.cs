using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    [System.Serializable]
    public struct SpawnInfo
    {
        public Mob spawnableMob;
        [Tooltip("First float is the minimum distance from the spawner something can spawn. The second float is the max distance from the spawner something can spawn.")]
        public Vector2 minAndMaxRange;
        public float timeBeforeSpawn;
        [Tooltip("Set to 0 to allow uncapped spawning of this mob type.")]
        public int maxMobCount;
    }

    [SerializeField]
    SpawnInfo[] info;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
