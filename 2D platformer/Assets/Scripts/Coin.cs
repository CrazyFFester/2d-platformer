using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Coin : MonoBehaviour
{
    private BoxCollider2D _boxCollider2D;

    private void Awake()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _boxCollider2D.isTrigger = true;
    }
}