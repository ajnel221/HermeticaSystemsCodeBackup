using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public PlayerHealthbar playerHealthbar;
    public SpawnWeaponOnSlot spawnWeaponOnSlot;
    public Animator animator;
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    Vector3 velocity;
    public bool isGrounded;
    public int noOfClicks;
    public bool canClick;

    // Start is called before the first frame update
    void Start()
    {
        noOfClicks = 0;
        canClick = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(animator == null)
        {
            return;
        }

        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        Move(x,y);


        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if(spawnWeaponOnSlot.isMainHandSpawn == true && spawnWeaponOnSlot.isSword == true && spawnWeaponOnSlot.isOffHandSpawned == true && spawnWeaponOnSlot.isShield == true)
        {
            animator.SetBool("Sword_And_Shield", true);
            animator.SetBool("Idle_Basic", false);
            animator.SetBool("2HandedSword", false);
            animator.SetBool("OneHandedSword", false);
        }

        if(spawnWeaponOnSlot.isMainHandSpawn == true && spawnWeaponOnSlot.isSword == true && spawnWeaponOnSlot.isOffHandSpawned == false && spawnWeaponOnSlot.isShield == false)
        {
            animator.SetBool("Sword_And_Shield", false);
            animator.SetBool("Idle_Basic", false);
            animator.SetBool("2HandedSword", false);
            animator.SetBool("OneHandedSword", true);
        }

        if(spawnWeaponOnSlot.isMainHandSpawn == false && spawnWeaponOnSlot.isSword == false && spawnWeaponOnSlot.isOffHandSpawned == false && spawnWeaponOnSlot.isShield == false)
        {
            animator.SetBool("2HandedSword", false);
            animator.SetBool("Idle_Basic", true);
            animator.SetBool("Sword_And_Shield", false);
            animator.SetBool("OneHandedSword", false);
        }

        if((spawnWeaponOnSlot.isSword2Spawn == true && spawnWeaponOnSlot.isSword2 == true || spawnWeaponOnSlot.isFireSwordSpawn == true && spawnWeaponOnSlot.isFireSword == true || spawnWeaponOnSlot.iselectricSwordSpawn == true && spawnWeaponOnSlot.iselectricSword == true) && spawnWeaponOnSlot.isOffHandSpawned == false && spawnWeaponOnSlot.isShield == false)
        {
            animator.SetBool("2HandedSword", true);
            animator.SetBool("Idle_Basic", false);
            animator.SetBool("Sword_And_Shield", false);
            animator.SetBool("OneHandedSword", false);
        }

        if(Input.GetMouseButtonDown(0))
        {
            ComboStarter();
        }
    }

    private void Move(float x, float y)
    {
        animator.SetFloat("ValX", x);
        animator.SetFloat("ValY", y);
    }

    private void ComboStarter()
    {
        if(canClick == true)
        {
            noOfClicks++;
        }

        if(noOfClicks == 1)
        {
            animator.SetInteger("animation", 31);
            animator.SetInteger("1HandedAnimation", 1);
            animator.SetInteger("1HandedSwordAnimation", 1);
        }
    }

    public void ComboCheck()
    {
        canClick = false;

        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Slash") && noOfClicks == 1)
        {
            animator.SetInteger("animation", 4);
            canClick = true;
            noOfClicks = 0;
        }

        else if(animator.GetCurrentAnimatorStateInfo(0).IsName("Slash") && noOfClicks >= 2)
        {
            animator.SetInteger("animation", 33);
            canClick = true;
        }

        else if(animator.GetCurrentAnimatorStateInfo(0).IsName("LowSlash") && noOfClicks == 2)
        {
            animator.SetInteger("animation", 4);
            canClick = true;
            noOfClicks = 0;
        }

        else if(animator.GetCurrentAnimatorStateInfo(0).IsName("LowSlash") && noOfClicks >= 3)
        {
            animator.SetInteger("animation", 6);
            canClick = true;
        }

        else if(animator.GetCurrentAnimatorStateInfo(0).IsName("SpinSlash"))
        {
            animator.SetInteger("animation", 4);
            canClick = true;
            noOfClicks = 0;
        }

        else if((animator.GetCurrentAnimatorStateInfo(0).IsName("SpinSlash") || animator.GetCurrentAnimatorStateInfo(0).IsName("LowSlash") || animator.GetCurrentAnimatorStateInfo(0).IsName("Slash")) && noOfClicks < 3)
        {
            animator.SetInteger("animation", 4);
            canClick = true;
            noOfClicks = 0;
        }
    }

    public void ComboCheck1()
    {
        canClick = false;

        if(animator.GetCurrentAnimatorStateInfo(0).IsName("OneHanded_Slash") && noOfClicks == 1)
        {
            animator.SetInteger("1HandedAnimation", 2);
            canClick = true;
            noOfClicks = 0;
        }

        else if(animator.GetCurrentAnimatorStateInfo(0).IsName("OneHanded_Slash") && noOfClicks >= 2)
        {
            animator.SetInteger("1HandedAnimation", 3);
            canClick = true;
        }

        else if(animator.GetCurrentAnimatorStateInfo(0).IsName("OneHanded_Slash2") && noOfClicks == 2)
        {
            animator.SetInteger("1HandedAnimation", 2);
            canClick = true;
            noOfClicks = 0;
        }

        else if(animator.GetCurrentAnimatorStateInfo(0).IsName("OneHanded_Slash2") && noOfClicks >= 3)
        {
            animator.SetInteger("1HandedAnimation", 4);
            canClick = true;
        }

        else if(animator.GetCurrentAnimatorStateInfo(0).IsName("OneHanded_Slash3"))
        {
            animator.SetInteger("1HandedAnimation", 2);
            canClick = true;
            noOfClicks = 0;
        }

        else if((animator.GetCurrentAnimatorStateInfo(0).IsName("OneHanded_Slash3") || animator.GetCurrentAnimatorStateInfo(0).IsName("OneHanded_Slash2") || animator.GetCurrentAnimatorStateInfo(0).IsName("OneHanded_Slash")) && noOfClicks < 3)
        {
            animator.SetInteger("1HandedAnimation", 2);
            canClick = true;
            noOfClicks = 0;
        }
    }

    public void ComboCheck2()
    {
        canClick = false;

        if(animator.GetCurrentAnimatorStateInfo(0).IsName("FirstSlash") && noOfClicks == 1)
        {
            animator.SetInteger("1HandedSwordAnimation", 2);
            canClick = true;
            noOfClicks = 0;
        }

        else if(animator.GetCurrentAnimatorStateInfo(0).IsName("FirstSlash") && noOfClicks >= 2)
        {
            animator.SetInteger("1HandedSwordAnimation", 3);
            canClick = true;
        }

        else if(animator.GetCurrentAnimatorStateInfo(0).IsName("SecondSlash") && noOfClicks == 2)
        {
            animator.SetInteger("1HandedSwordAnimation", 2);
            canClick = true;
            noOfClicks = 0;
        }

        else if(animator.GetCurrentAnimatorStateInfo(0).IsName("SecondSlash") && noOfClicks >= 3)
        {
            animator.SetInteger("1HandedSwordAnimation", 4);
            canClick = true;
        }

        else if(animator.GetCurrentAnimatorStateInfo(0).IsName("ThirdSlash"))
        {
            animator.SetInteger("1HandedSwordAnimation", 2);
            canClick = true;
            noOfClicks = 0;
        }

        else if((animator.GetCurrentAnimatorStateInfo(0).IsName("ThirdSlash") || animator.GetCurrentAnimatorStateInfo(0).IsName("SecondSlash") || animator.GetCurrentAnimatorStateInfo(0).IsName("FirstSlash")) && noOfClicks < 3)
        {
            animator.SetInteger("1HandedSwordAnimation", 2);
            canClick = true;
            noOfClicks = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "EnemySword")
        {
            playerHealthbar.healthLength = playerHealthbar.healthLength - 10f;
        }
    }
}
