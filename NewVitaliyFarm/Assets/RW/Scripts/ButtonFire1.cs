using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFire1: MonoBehaviour
{
    [Header("Fire Property")]
    [SerializeField] private GameObject senoPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float fireRate;
    private float nextFire;


    void Start()
    {
        nextFire = fireRate; 
    }

   
    void Update()
        
    {
        nextFire += Time.deltaTime; 
    }

    public void PressFire()

    {
        Debug.Log("Огонь");

        if(nextFire > fireRate) 
        {
            GameObject seno = Instantiate(senoPrefab, spawnPoint.position, Quaternion.identity); // senoPrefab.transform.rotation 
            Destroy(seno, 5f);

            nextFire = 0; 
        }
        
        

    }

}
    
