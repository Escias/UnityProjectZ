using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    private Rigidbody MyRigidbody;
    private Vector3 moveInput;
    private Vector3 moveVelocity;
    private Vector3 lookAt;
    private bool isGrounded;
    PlayerAnimations playerAnimations;
    PlayerHealth playerHealth;

    [SerializeField]
    private Camera m_Camera;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        MyRigidbody = GetComponent<Rigidbody>();
        playerAnimations = FindObjectOfType<PlayerAnimations>();
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded && playerHealth.GetStatus())
        {
            moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            if (!playerAnimations.GetSpellAnimationStatus())
            {
                moveVelocity = moveInput * movementSpeed;
            }
            else
            {
                moveVelocity = new Vector3(0f, 0f, 0f);
            }

            if(Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
            {
                playerAnimations.RunForward();
            }
            else 
            {
                playerAnimations.RunForwardCancel();
            }

            Ray cameraRay = m_Camera.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayLength;

            if (groundPlane.Raycast(cameraRay, out rayLength))
            {
                Vector3 pointToLook = cameraRay.GetPoint(rayLength);
                Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);
                lookAt = new Vector3(pointToLook.x, pointToLook.y, pointToLook.z);
                transform.LookAt(new Vector3(lookAt.x, transform.position.y, lookAt.z));
            }
        }
        isGrounded = false;
    }

    private void FixedUpdate()
    {
        MyRigidbody.velocity = moveVelocity;
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }
}
