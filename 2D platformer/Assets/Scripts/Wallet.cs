using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _totalMoney;

    public void Start()
    {
        _totalMoney = 0;
    }

    public void AddingCoin()
    {
        _totalMoney++;
        Debug.Log("Total money - " + _totalMoney);
    }
}