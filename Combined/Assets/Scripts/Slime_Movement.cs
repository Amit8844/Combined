using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_Movement : MonoBehaviour
{
    public Animator _animator;
    public Rigidbody2D _rb;
    public float moveSpeed;
    public bool isGrounded;
    public Collider2D groundCheck;

    // Start is called before the first frame update


    // Update is called once per frame
    private void Update()
    {



        float speed = Input.GetAxisRaw("Horizontal");

        _animator.SetFloat("Speed", Mathf.Abs(speed));


        transform.localPosition += Vector3.right * speed * moveSpeed * Time.deltaTime;
        Move(speed);

       
    }
    void Move(float speed)
    {
        if (speed < 0)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
        }
        else if (speed > 0)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z);
        }
    }



    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            if (!groundCheck.IsTouching(other.collider))
            {
                return;
            }

            isGrounded = true;

        }
    }
}
