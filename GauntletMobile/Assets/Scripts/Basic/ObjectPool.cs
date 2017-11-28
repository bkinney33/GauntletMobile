using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

    [System.Serializable]
    public class Pool
    {
        public string name;
        public int maxCount;
        public GameObject original;
        public List<GameObject> objs;
    };

    [SerializeField]
    Pool[] objects;

    // Use this for initialization
    void Start ()
    {
        for(int i = 0; i < objects.Length; ++i)
        {
            for(int j = 0; j < objects[i].maxCount; ++j)
            {
                GameObject g = Instantiate(objects[i].original);
                g.SetActive(false);
                objects[i].objs.Add(g);
            }
        }  
    }

    public GameObject GetPooledObject(string name)
    {
        for(int i = 0; i < objects.Length; ++i)
        {
            if (objects[i].name.Equals(name))
            {
                for(int k = 0; k < objects[i].maxCount; ++k)
                {
                    if (!objects[i].objs[k].activeInHierarchy)
                    {
                        return objects[i].objs[k];
                    }
                }
            }
        }
        return null;
    }
}
