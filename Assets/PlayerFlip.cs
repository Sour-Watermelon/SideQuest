using UnityEngine;

public class PlayerFlip : MonoBehaviour
{

    public float horizontalInput;
    public bool facingRight = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     horizontalInput = Input.GetAxis("Horizontal");
    SetupDirectionByScale();
    }

    private void SetupDirectionByScale()
    {
        if(horizontalInput < 0 && facingRight || horizontalInput > 0 && !facingRight)
        {
            facingRight = !facingRight;
            Vector3 playerScale = transform.localScale;
            playerScale.x *= -1;
            transform.localScale = playerScale;
        }
    }
}
