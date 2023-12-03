using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class Pathfinding : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rigidbody;
    public NavMeshAgent agent;
    private bool isGrounded;
    public float gravity;
    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {        
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        if (isGrounded)
        {
            agent.SetDestination(target.transform.position);
        }
        rigidbody.AddForce(new Vector3(0f, -gravity * rigidbody.mass, 0f));

        isGrounded = false;
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }
}
