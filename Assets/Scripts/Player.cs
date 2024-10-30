using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private Animator animController;
    [SerializeField] private AnimationClip idle;
    [SerializeField] private AnimationClip Walk;

    public Rigidbody rb;
    public Transform cam;

    public float speed = 6f;
    public float jump = 5f;

    public float turnSmoothTime = 0.1f;
        private bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, Vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            gameObject.transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward.normalized;
            rb.velocity = new Vector3(moveDir.x * speed, rb.velocity.y, moveDir.z * speed);
            animController.Play("Walk");
            //rb.AddForce(moveDir * speed, ForceMode.Force);

        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
            animController.Play("Idle");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                rb.AddForce(new Vector3(0, jump), ForceMode.Impulse);
                grounded = false;
                transform.parent = null;
            }
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        grounded = true;

        if (collision.gameObject.CompareTag("Platform"))
            gameObject.transform.parent = collision.transform;
    }
}

