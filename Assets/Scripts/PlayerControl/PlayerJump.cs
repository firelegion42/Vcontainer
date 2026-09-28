using UnityEngine;
using VContainer;

public class PlayerJump : MonoBehaviour, IJumpable 
{
   
    private int _jumpForce;
     private LayerMask _groundMask;


    [Inject]
    private void Construct(Settings settings)
    {
        _jumpForce = settings.jumpForce;
        _groundMask = settings.groundMask;
    }

    private Rigidbody rb;
    private bool _isGrounded;


    private void Start()
    {
        rb =  GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _isGrounded = Physics.CheckSphere(transform.position, 1.2f, _groundMask);
    }
    public void Jump()
    {
        if (_isGrounded)
        {
            rb.AddForce(new Vector3(0, _jumpForce, 0));
        }
    }
}
