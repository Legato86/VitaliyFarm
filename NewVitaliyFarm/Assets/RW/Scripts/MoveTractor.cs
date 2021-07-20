using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTractor : MonoBehaviour
{
   enum TractorCondition { Move, Stop }

    TractorCondition tractorCondition = TractorCondition.Stop;


    [Header("Traktor Property")] 
    [SerializeField] private float speed;
    [SerializeField] private float bounds;
    private float direction;
    

    void Start()
    {
        
    }

    
    void Update()
    {
         if (tractorCondition == TractorCondition.Move) 
         {
            if (((transform.position.x > -bounds) && (direction == 1f)) || (transform.position.x < bounds) && (direction == -1f))
            {
                transform.Translate(Vector3.left * speed * direction * Time.deltaTime);
            }

         }
        
        

    }


    public void PressRight()
    {
        direction = -1f;
        tractorCondition = TractorCondition.Move;
    }
    public void PressLeft()
    {
        direction = 1f;
        tractorCondition = TractorCondition.Move;
    }
    public void StopPress() 
    {
        tractorCondition = TractorCondition.Stop; 
    }

    



}
