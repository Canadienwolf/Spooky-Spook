using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Animator anim;
    
    private Rigidbody2D body;

    private float horizontal;
    private float vertical;

    public float runSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
            anim.SetBool("Moving",true);
        }
        else
        {
            anim.SetBool("Moving",false);
        }
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}
