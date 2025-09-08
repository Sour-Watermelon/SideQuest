using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jump;

    public Rigidbody2D body;

    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");//Left and Right
        if (Mathf.Abs(xInput) > 0)
        {
            body.linearVelocity = new Vector2(xInput * speed, body.linearVelocity.y);
        }
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            body.AddForce(new Vector2(body.linearVelocity.x, jump));
        }
    }

    public bool isGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position-transform.up * castDistance, boxSize);
    }
}
