using UnityEngine.Events;
using UnityEngine;

public class CollisionTraktorWithSheep : MonoBehaviour
{
    // [SerializeField] private UnityEvent SaveSheepEvent; 

    private void OnTriggerEnter(Collider other)
    {
        SheepMove sheep = other.gameObject.GetComponent<SheepMove>();

        if (sheep != null)
        {
            sheep.DestroySheep();

            // SaveSheepEvent.Invoke(); 
            
        }
    }
}
