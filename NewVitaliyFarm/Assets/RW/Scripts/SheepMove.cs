using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector3 moveDirection;

    [SerializeField] private float force;
    private Rigidbody rb;
    [SerializeField] private GameObject HeartParticlePrefab;

    private void Awake()  // private - скрывает компонент 
    {

        rb = GetComponent<Rigidbody>();

    }


    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void SaveSheep()
    {
        rb.isKinematic = false;
        rb.AddForce(Vector3.up * force);

        GameObject particle = Instantiate(HeartParticlePrefab, transform.position, HeartParticlePrefab.transform.rotation);  // спауним патикл в позиции овци 
        Destroy(particle, 2f);
        Destroy(gameObject, 0.9f);
    }
}
