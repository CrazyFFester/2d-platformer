using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody2D;
    private bool _onGround;
    private Animator _animator;
    private bool _objectTurnedToLeft;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _onGround = true;
    }

    private void ChangeSide(bool objectTurnedToLeft)
    {
        if (_objectTurnedToLeft != objectTurnedToLeft)
        {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);

            _objectTurnedToLeft = !_objectTurnedToLeft;
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && _onGround)
        {
            _rigidbody2D.AddForce(Vector2.up * _speed, ForceMode2D.Impulse);
            _onGround = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);

            ChangeSide(true);

            _animator.SetFloat("Speed", 1);
            return;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);

            ChangeSide(false);
            _animator.SetFloat("Speed", 1);
            return;
        }

        _animator.SetFloat("Speed", 0);
    }
}