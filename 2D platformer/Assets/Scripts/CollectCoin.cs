using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            Destroy(collision.gameObject);
            _wallet.AddCoin();
        }
    }
}