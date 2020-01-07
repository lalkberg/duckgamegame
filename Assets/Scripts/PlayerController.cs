using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int PlayerNumber;
    public float movementSpeed;
    Rigidbody2D rb;
    private Vector3 vZero = Vector3.zero;
    public EquippedWeapon EquippedWeapon;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (PlayerNumber)
        {
            case 1:
                {
                    if (Input.GetAxis("P1 Jump") > 0.1f)
                    {
                        Jump();
                    }

                    if (Input.GetAxis("P1 Shoot") > 0.1f)
                    {
                        if (EquippedWeapon.weapon != null)
                        {
                            Shoot();
                        }
                    }

                    if (Input.GetAxis("P1 X") != 0)
                    {
                        Run(Input.GetAxis("P1 X"));
                    }
                    break;
                }
            case 2:
                {
                    if (Input.GetAxis("P2 Jump") > 0.1f)
                    {
                        Jump();
                    }

                    if (Input.GetAxis("P2 X") != 0)
                    {
                        Run(Input.GetAxis("P2 X"));
                    }
                    break;
                }
            case 3:
                {
                    if (Input.GetAxis("P3 Jump") > 0.1f)
                    {
                        Jump();
                    }
                    break;
                }
            case 4:
                {
                    if (Input.GetAxis("P4 Jump") > 0.1f)
                    {
                        Jump();
                    }
                    break;
                }
        }
    }

    void Jump()
    {
        rb.AddForce(new Vector2(0, 10));
    }

    void Run(float axis)
    {
        // Move the character by finding the target velocity
        Vector3 targetVelocity = new Vector2((axis * movementSpeed) * Time.deltaTime, rb.velocity.y);
        // And then smoothing it out and applying it to the character
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref vZero, 0.05f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon")) //pick up weapon
        {
            Weapon weapon = collision.GetComponent<Weapon>();
            switch (weapon.WeaponType)
            {
                case WeaponType.Hammer:
                    {
                        PickUpWeapon((Weapon)weapon); //change this to correct weapon
                        break;
                    }
            }
        }
    }

    void PickUpWeapon(Weapon weapon)
    {
        EquippedWeapon.weapon = weapon;
    }
    void PickUpUpgrage()
    {
        EquippedWeapon.level = Mathf.Clamp(EquippedWeapon.level++, 0, 3);
    }

    void Shoot()
    {
        WeaponType bulletType = 0;
        int bulletLevel = 0;

        switch (EquippedWeapon.weapon.WeaponType)
        {
            case WeaponType.Hammer:
                bulletType = WeaponType.Hammer;
                break;
        }

        switch (EquippedWeapon.level)
        {
            case 0:
                bulletLevel = 0;
                break;
        }

        switch (bulletType)
        {
            case WeaponType.Hammer:
                switch (bulletLevel)
                {
                    case 0:
                        {
                            EquippedWeapon.Null();
                            //Spawn bullet 0 of type 0
                        }
                        break;
                }
                break;
            case WeaponType.Hookshot:
                switch (bulletLevel)
                {
                    case 0:
                        {
                            EquippedWeapon.Null();
                            //Spawn bullet 0 of type 0
                        }
                        break;
                }
                break;
            case WeaponType.AirCannon:
                switch (bulletLevel)
                {
                    case 0:
                        {
                            EquippedWeapon.Null();
                            //Spawn bullet 0 of type 0
                        }
                        break;
                }
                break;
        }
    }
}

public struct EquippedWeapon
{
    public Weapon weapon;
    public int level;

    public void Null()
    {
        weapon = null;
        level = 0;
    }
}

public enum AirMode
{
    Grounded, Jumping, Falling
}
