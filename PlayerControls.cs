using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{


    
    void Start()
    {
        
    }


    void Update()
    {
        Punch();
        Kick();
        Block();
        Move();
        LockRoation();

        if (Health <= 0)
        {
            Anim.Play("Die");
            CanMove = false;
        }
    }
    public GameObject DamageCollider;
    public Transform AttackPos;

    public CharacterController CController;
    public float MovementSpeed;
    public float JumpPower;
    public Animator Anim;
    public bool CanMove;

    public Transform RotationLock;


    public GameObject MainCam;
    public GameObject AttackCam;

    public float Health;


    public void ActivatePunchCam()
    {
        MainCam.SetActive(false);
        AttackCam.SetActive(true);
    }

    public void ActivateMainCam()
    {
        MainCam.SetActive(true);
        AttackCam.SetActive(false);
    }
    public void Block()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Anim.Play("Block");
            CanMove = false;
            gameObject.GetComponent<Rigidbody>().useGravity = false;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Anim.Play("Idle");
            CanMove = true;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }


    public void DoDamage()
    {
        Instantiate(DamageCollider, AttackPos.position, AttackPos.rotation);
    }

    public void Punch()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Anim.Play("Punch R");
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Anim.Play("Punch L");
        }
    }


    public void Kick()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Anim.Play("Kick L");
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Anim.Play("Kick R");
        }
    }

    public void LockRoation()
    {
        gameObject.transform.rotation = RotationLock.rotation;
    }

    public void Move()
    {
        if (CanMove == true)
        {

            float horizontalInput = Input.GetAxis("Horizontal");

            Vector3 direction = new Vector3(-horizontalInput , 0, 0);

            CController.Move(direction * Time.deltaTime * MovementSpeed);



            if (Input.GetKey(KeyCode.D))
            {           
                Anim.Play("Foward");
            }

            if (Input.GetKey(KeyCode.A))
            {
                Anim.Play("Back");
            }


            if (Input.GetKeyUp(KeyCode.A))
            {
                Anim.Play("Idle");
            }

            if (Input.GetKeyUp(KeyCode.D))
            {
                Anim.Play("Idle");
            }
        }


    }
}
