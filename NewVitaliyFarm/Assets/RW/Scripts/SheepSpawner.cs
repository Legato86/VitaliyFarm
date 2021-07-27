using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPoints;


    [SerializeField] private GameObject sheepPrefab; //префаб овци
    [SerializeField] private Vector3 spawnPosition; //позиция спауна
    [SerializeField] private Vector2 xSpawnBound; //граница спауна по координате (будет выбрана рандомная точка)

    [SerializeField] private int sheepCount; // задаем количество овец 
    [SerializeField] private float spawnRate; // частота появления между овцами
    [SerializeField] private float waveRate; //частота между волнами 
    [SerializeField] private int sheepCountWaveIncrease;

    [SerializeField] private int waveCount;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    
    private IEnumerator Spawn()
    {
        while (waveCount > 0)
        {
            for (int i = 0; i < sheepCount; i++)
            {
                CreateSheep(); //Spawn
                //CreateSheepInSpawnPoints();
                yield return new WaitForSeconds(spawnRate);

            }
            sheepCount *= sheepCountWaveIncrease; // sheepCount = sheepCount * sheepCountWaveIncrease; - длинная запись 
            yield return new WaitForSeconds(waveRate);
            waveCount--;
           
        }
        
    }
    private void CreateSheep()
    {
        //22 - -22, 0, 55 
        float xRandomPosition = Random.Range(xSpawnBound.x, xSpawnBound.y); //найти случайную позицию по оси икс   
        Vector3 randomSpawnPosition = new Vector3(xRandomPosition, spawnPosition.y, spawnPosition.z); // сформировать новую рандомную позицию 
        Instantiate(sheepPrefab, randomSpawnPosition, sheepPrefab.transform.rotation);
        
        // GameObject sheep = можно сделать сcылку конкретно на объект
    }

    public void CreateSheepInSpawnPoints()
    {
        int randomPointIndex = Random.Range(0, spawnPoints.Count);
        Instantiate(sheepPrefab, spawnPoints[randomPointIndex].position, sheepPrefab.transform.rotation);

    }


}

