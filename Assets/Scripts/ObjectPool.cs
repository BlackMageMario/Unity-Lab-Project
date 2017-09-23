using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Based on SimpleObjectPool script from https://unity3d.com/learn/tutorials/topics/user-interface-ui/intro-and-setup?playlist=17111
/// Just an object pool - much better than creating and destroying a ton of asteroids which can cause various issues
/// </summary>
public class ObjectPool : MonoBehaviour {
    public GameObject objectToPool;
    private Stack<GameObject> inactiveObjects = new Stack<GameObject>();
    // Use this for initialization
    public GameObject spawnObject()
    {
        GameObject spawnedObject;
        if (inactiveObjects.Count > 0)
        {
            //take something off the top of the stack
            spawnedObject = inactiveObjects.Pop();
        }
        else
        {
            //we need a new instance
            spawnedObject = (GameObject)GameObject.Instantiate(objectToPool);
            PooledObject pooledObject = spawnedObject.AddComponent<PooledObject>();
            pooledObject.pool = this;
        }

        spawnedObject.transform.SetParent(GameObject.Find("PoolManager").transform);
        spawnedObject.SetActive(true);
        return spawnedObject;
    }

    public void ReturnObject(GameObject toReturn)
    {
        PooledObject pooledObject = toReturn.GetComponent<PooledObject>();
        if (pooledObject != null && pooledObject.pool == this)
        {
            toReturn.SetActive(false);
            inactiveObjects.Push(toReturn);
        }
        else
        {
            //sent to wrong pool
            Debug.LogWarning(toReturn.name + " was returned to a pool it wasn't spawned from.");
            Destroy(toReturn);
        }


    }

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

public class PooledObject : MonoBehaviour
{
    public ObjectPool pool;
}

