using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int PlayerNumber;
    Rigidbody2D rb;

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
                    break;
                }
            case 2:
                {
                    if (Input.GetAxis("P2 Jump") > 0.1f)
                    {
                        Jump();
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
}
