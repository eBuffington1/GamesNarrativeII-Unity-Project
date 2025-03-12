using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D _rb;

    [SerializeField] float _speed = 5f;
    private float _horizInput;
    private float _vertInput;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get horizontal and vertical input values
        _horizInput = Input.GetAxisRaw("Horizontal");
        _vertInput = Input.GetAxisRaw("Vertical");



    }

    private void FixedUpdate()
    {
        // Horizontal Movement
        _rb.linearVelocity = new Vector2(_horizInput * _speed, _vertInput * _speed);

    }

}
