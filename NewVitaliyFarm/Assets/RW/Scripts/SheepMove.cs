using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepMove : MonoBehaviour
{
    [SerializeField] private float startSpeed;
    private float moveSpeed;

    [SerializeField] private Vector3 moveDirection;

    [SerializeField] private float force;
    private Rigidbody rb;
    private BoxCollider bc;
    [SerializeField] private GameObject HeartParticlePrefab; // ������� ������ 
    [SerializeField] private Vector3 sheepOffset;
    [SerializeField] private float jumpForce;

    private void Awake()  // private - �������� ��������� 
    {

        rb = GetComponent<Rigidbody>();
        bc = GetComponent<BoxCollider>();
    }

    private void Start()
    {
        moveSpeed = startSpeed;



    }
    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime); 
    }

    public void SaveSheep()
    {
        rb.isKinematic = false;
        rb.AddForce(Vector3.up * force);
        ///////////////////////// ��� ������
        moveSpeed = 0; //1. ��������� �������� ���� �� 0 ��� ��� � �������� 
        bc.enabled = false; //2. ��������� ���� ��������� ���� 
        rb.useGravity = false; //3. ��������� ����������
        //4. �������� ������ �� ������� ��� ����� ��� �� �����

        GameObject particle = Instantiate(HeartParticlePrefab, transform.position + sheepOffset, HeartParticlePrefab.transform.rotation);  // ������� ������ � ������� ���� + ������ �� �������
        Destroy(particle, 2f); 
        Destroy(gameObject, 0.9f);
    }
    
    public void JumpThrowWater()
    {
        rb.isKinematic = false;
        moveSpeed = 0;
        rb.AddForce(new Vector3(0f, 1f, -1f) * jumpForce);

    }

    public void LandThrowWater()
    {
        rb.isKinematic = true;
        moveSpeed = startSpeed;

    }
}

