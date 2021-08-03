using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeWorkTime : MonoBehaviour
{
    //If the Aim button is pressed, a senoPrefab
    //will be Instantiated every 0.5 seconds.

    [SerializeField] Transform senoContainer;
    public GameObject senoPrefab;
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;

    [SerializeField] private SoundManager soundManager;

    [Header("SenoPool")]
    [SerializeField] private int senoPoolSize;
    [SerializeField] private List<GameObject> senos;
    private int currentSenoIndex;

    private void Awake()
    {
        senos = new List<GameObject>();
    }
    private void Start()
    {

        for (int i = 0; i < senoPoolSize; i++)
        {

            senos.Add(Instantiate(senoPrefab));
            senos[i].transform.SetParent(senoContainer);
            senos[i].SetActive(false);

        }

    }


    public void PressAim() 
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            senos[currentSenoIndex].transform.position = transform.position;
            senos[currentSenoIndex].SetActive(true);

            currentSenoIndex++;
            if(currentSenoIndex >= senoPoolSize)
            {

                currentSenoIndex = 0;

            }


            // GameObject seno = Instantiate(senoPrefab, transform.position, transform.rotation);
          
        }

        soundManager.PlayShootClip(); 

    }

}   








