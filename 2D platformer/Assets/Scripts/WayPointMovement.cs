using UnityEngine;

[RequireComponent(typeof(Animator))]

public class WayPointMovement : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private Transform[] _points;
    private int _currentPoint;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        Transform target = _points[_currentPoint];

        transform.position = Vector2.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
        _animator.SetFloat("Speed", 1);

        if ((Vector2)transform.position == (Vector2)target.position)
        {
            _currentPoint++;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
    }
}