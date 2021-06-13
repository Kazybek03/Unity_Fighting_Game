using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControls : MonoBehaviour
{

    void Start()
    {
        StartCoroutine("EnemyAI");
    }


    void Update()
    {
        LockRoation();
        Move();

        if(Health <= 0)
        {
            Anim.Play("Die");
            StopAllCoroutines();
            MovementSpeed = 0;
            Destroy(gameObject);
        }
    }


    public GameObject DamageCollider;
    public Transform AttackPos;



    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            MovementSpeed = 0;
            PunchR();
        }

        if (other.tag == "Wall")
        {
            MovementSpeed = -0.05f;
        }


    }

    public float Health;

    public float MovementSpeed;
    public float JumpPower;
    public Animator Anim;
    public bool CanMove;

    public Transform RotationLock;


    public void LockRoation()
    {
        gameObject.transform.rotation = RotationLock.rotation;
    }

    public void Block()
    {     
            Anim.Play("Block");
    }



    public void DoDamage()
    {
        Instantiate(DamageCollider, AttackPos.position, AttackPos.rotation);
    }

    public void PunchR()
    {
            Anim.Play("Punch R");
    }

    public void PunchL()
    {
        Anim.Play("Punch L");
    }
    public void KickR()
    {
            Anim.Play("Kick R");
    }

    public void KickL()
    {
        Anim.Play("Kick L");
    }

    public void StopMovement()
    {
        MovementSpeed = 0;
    }

    

    public void Move()
    {
        if(MovementSpeed == 0.05f)
        {
            Anim.Play("Foward");
        }

        if (MovementSpeed == -0.05f)
        {
            Anim.Play("Back");
        }
        if (CanMove == true)
        {
                transform.Translate(0, 0, MovementSpeed);     
        }
    }

    IEnumerator EnemyAI()
    {
        yield return new WaitForSeconds(4);
        MovementSpeed = 0.05f;
        StartCoroutine("EnemyAI");
    }
}
