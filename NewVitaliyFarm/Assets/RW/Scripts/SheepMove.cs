using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepMove : MonoBehaviour
{
    [SerializeField] private List<SheepProperty> sheepProperty;

    //[SerializeField] private float startSpeed;   
    [SerializeField] private Vector3 moveDirection;
    [SerializeField] private float force;
    [SerializeField] private GameObject heartParticlePrefab; //�������� ������
    [SerializeField] private Vector3 sheepOffset;
    [SerializeField] private float jumpForce;

    private Rigidbody rb;
    private BoxCollider bc;
    private MeshRenderer mr;
    private float moveSpeed;
    int randomSheepPropertyIndex;

    [SerializeField] private SoundManager soundManager;
    [SerializeField] private GameEvent SheepDroppedEvent;
    [SerializeField] private GameEvent SheepSavedEvent;

    // [SerializeField] private ScoreManager scoreManager;

    private void Awake()  // private - �������� ��������� 
    {
        rb = GetComponent<Rigidbody>();
        bc = GetComponent<BoxCollider>();
        mr = GetComponent<MeshRenderer>();
    }

    private void OnEnable()
    {
        randomSheepPropertyIndex = Random.Range(0, sheepProperty.Count);
        moveSpeed = sheepProperty[randomSheepPropertyIndex].Speed;
        mr.material = sheepProperty[randomSheepPropertyIndex].Material;
        rb.isKinematic = true;
        bc.enabled = true;
        rb.useGravity = true;
    }


    private void Start()
    {
        // Debug.Log(sheepProperty[randomSheepPropertyIndex].Name); // get 
        // sheepProperty[randomSheepPropertyIndex].Name = "Molly"; // set
        // Debug.Log(sheepProperty[randomSheepPropertyIndex].Name); // get

    }
    void Update()
    {
        //��������� ��������� � ���� ������ ���� ���� ����
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

        GameObject particle = Instantiate(heartParticlePrefab, transform.position + sheepOffset, heartParticlePrefab.transform.rotation);  // ������� ������ � ������� ���� + ������ �� �������
        Destroy(particle, 2f);
        // Destroy(gameObject, 0.9f);
        gameObject.SetActive(false); // �� - �������� ��������� ��� ������ 

        soundManager.PlaySheepHitClip();
        SheepSavedEvent.Raise();

        // scoreManager.AddSaveSheep(); 

    }
    
    public void JumpThrowWater()
    {
        //��������� ���������� -��������� �������� - ������ ��� ���� 
        rb.isKinematic = false;
        moveSpeed = 0; //��������� ����
        rb.AddForce(new Vector3(0f, 1f, -1f) * jumpForce);

    }

    public void LandThrowWater()
    {
        //-�������� ���������� - ������������ ��������
        rb.isKinematic = true;
        moveSpeed = sheepProperty[randomSheepPropertyIndex].Speed; //��������� ����

    }

    public void DestroySheep()
    {

        soundManager.PlayDropClip();
        SheepDroppedEvent.Raise();
        // scoreManager.AddDropSheep();
        // Destroy(gameObject); 
        gameObject.SetActive(false);

    }

}

