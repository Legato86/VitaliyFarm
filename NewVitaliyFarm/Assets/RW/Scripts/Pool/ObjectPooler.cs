using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //ссылки будут редактируемые 
public class ObjectPoolItem
{
    public GameObject pooledObject;
    public  int poolSize;
    public bool willGrow;




}

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler objectPooler; //public static - сделали общий доступ для других скриптов 
    [SerializeField] private List<ObjectPoolItem> itemsToPool; 
    [SerializeField] private List<GameObject> pooledObjects;
    //[SerializeField] private GameObject pooledObject; 
    //[SerializeField] private int poolSize;
    //[SerializeField] private bool willGrow; 


    private void Awake()
    {
        objectPooler = this;
        pooledObjects = new List<GameObject>(); 

    }

    void Start()
    {
        foreach (ObjectPoolItem item in itemsToPool)
        {
            for (int i = 0; i < item.poolSize; i++)
            {
                pooledObjects.Add(Instantiate(item.pooledObject));
                pooledObjects[i].transform.SetParent(transform);
                pooledObjects[i].SetActive(false);
            }
        }
    }

    public GameObject GetPooledObject(string tag)
    {

        for(int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].tag ==tag)
            {
                return pooledObjects[i];
            }
        }

        foreach (ObjectPoolItem item in itemsToPool)
        {
            if(item.pooledObject.tag == tag) 
            {
                if (item.willGrow)
                {
                    GameObject obj = Instantiate(item.pooledObject);
                    obj.SetActive(false);
                    pooledObjects.Add(obj);
                    obj.transform.SetParent(transform);
                    return obj;

                }
            }
        }
        return null; 
    }   
}
