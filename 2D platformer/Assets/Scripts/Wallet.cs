using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _totalMoney; 

    public void AddCoin()
    {
        _totalMoney++;
        Debug.Log("Total money - " + _totalMoney);
    }
}