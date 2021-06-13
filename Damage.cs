using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(other.GetComponent<PlayerControls>().CanMove == true)
            {
                other.GetComponent<PlayerControls>().Health -= 10;
                other.GetComponent<Animator>().Play("Hit");
            }
        }


        if (other.tag == "Enemy")
        {

                other.GetComponent<EnemyControls>().Health -= 10;
                other.GetComponent<EnemyControls>().StopMovement();
                other.GetComponent<Animator>().Play("Hit");
            
        }
    }
    private void Start()
    {
        Destroy(gameObject, 0.1f);
    }

}
