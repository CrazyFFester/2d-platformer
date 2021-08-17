using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Coin : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    private BoxCollider2D _boxCollider2D;

    private void Awake()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _boxCollider2D.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Knight>(out Knight knight))
        {
            Destroy(gameObject);
            _wallet.AddingCoin();
        }
    }
}