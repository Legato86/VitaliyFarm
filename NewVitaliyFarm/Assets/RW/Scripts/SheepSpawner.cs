using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPoints;


    [SerializeField] private GameObject sheepPrefab; //������ ����
    [SerializeField] private Vector3 spawnPosition; //������� ������
    [SerializeField] private Vector2 xSpawnBound; //������� ������ �� ���������� (����� ������� ��������� �����)

    [SerializeField] private int sheepCount; // ������ ���������� ���� 
    [SerializeField] private float spawnRate; // ������� ��������� ����� ������
    [SerializeField] private float waveRate; //������� ����� ������� 
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
            sheepCount *= sheepCountWaveIncrease; // sheepCount = sheepCount * sheepCountWaveIncrease; - ������� ������ 
            yield return new WaitForSeconds(waveRate);
            waveCount--;
           
        }
        
    }
    private void CreateSheep()
    {
        //22 - -22, 0, 55 
        float xRandomPosition = Random.Range(xSpawnBound.x, xSpawnBound.y); //����� ��������� ������� �� ��� ���   
        Vector3 randomSpawnPosition = new Vector3(xRandomPosition, spawnPosition.y, spawnPosition.z); // ������������ ����� ��������� ������� 
        Instantiate(sheepPrefab, randomSpawnPosition, sheepPrefab.transform.rotation);
        
        // GameObject sheep = ����� ������� �c���� ��������� �� ������
    }

    public void CreateSheepInSpawnPoints()
    {
        int randomPointIndex = Random.Range(0, spawnPoints.Count);
        Instantiate(sheepPrefab, spawnPoints[randomPointIndex].position, sheepPrefab.transform.rotation);

    }


}

