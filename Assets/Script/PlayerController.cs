using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float speed = 3f;
    private Vector2 _moveInput = Vector2.zero;
    private float _moveInputMagn = 0f;

    //Componenti
    private Rigidbody2D _rb2D;

    void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();

        //Controlli
        speed = (speed == 0f) ? 1f : speed;
    }

    void Start()
    {
        
    }

    private void Move()
    {
        _moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _moveInputMagn = _moveInput.sqrMagnitude;

        //Normalizzo solo se serve
        if(_moveInputMagn > 1f)
        {
            _moveInput = _moveInput / Mathf.Sqrt(_moveInputMagn);
        }
    }

    void Update()
    {
        Move();
    }

    void FixedUpdate()
    {
        //Se lo spostamento è maggiore di "zero" allora applica lo spostamento
        if (_moveInputMagn > Mathf.Epsilon)
        {
            _rb2D.MovePosition(_rb2D.position + _moveInput * (speed * Time.fixedDeltaTime));
        }
    }
}
