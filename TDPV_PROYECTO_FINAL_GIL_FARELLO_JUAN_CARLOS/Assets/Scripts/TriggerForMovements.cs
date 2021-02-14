using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForMovements : MonoBehaviour
{
    public bool direction;
    public GameObject[] enemy;
  
    public bool triggers_side;
    void Start()
    {
        
    }

    void Update()
    {
      
            if (direction == true && triggers_side == true)
            {
                for (int i = 0; i < enemy.Length; i++)
                {
                if (enemy[i] != null)
                {
                    enemy[i].gameObject.GetComponent<EnemyController>().Set_direction_for_move(true);
                }
                }
            }
            if (direction == true && triggers_side == false)
            {
                for (int i = 0; i < enemy.Length; i++)
                {
                if (enemy[i] != null)
                {
                    enemy[i].gameObject.GetComponent<EnemyController>().Set_direction_for_move(false);
                }
                }
            }
      
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            direction = true;
        }
    }
   private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            direction = false;
        }
    }
}
