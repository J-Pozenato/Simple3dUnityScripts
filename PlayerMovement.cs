using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float turnSmoothTime = 0.1f;

    public float speed = 5.0f;

    float turnSmoothVelocity;

    Rigidbody rigid;

    SphereCollider col;

    public float thrustUp = 5f;

    public LayerMask groundLayers;



    // Start is called before the first frame update
    void Start()
    {
        //player spawn point
        //this is where our player will start

        //player position to x, y, z

        // transform.position = new Vector3(5, 0, 4);

        rigid = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        //move player to L-R-U-D
        //player (gameobject) to move when i press arrow keys

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical);

        rigid.AddForce(direction * speed);

        //Code Used to turn the character in the direction its moving
        /*
        if (direction.magnitude >= 0.1f)
        {

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

        }
        */

        if (isGrounded() && Input.GetButton("Jump"))
        {
            //apply force up
            rigid.AddForce(transform.up * thrustUp, ForceMode.Impulse);
        }

    }

    private bool isGrounded()
    {

        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundLayers);

    }


}
