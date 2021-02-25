using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashManager : Singleton<CashManager>
{
    private float cash = 1000;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddTransaction(float cashAdd)
    {
        cash = cash + cashAdd;
    }

    public bool DecreaseTransaction(float cashDecrease)
    {
        if (IsAbleToDecrease(cashDecrease))
        {
            Decrease(cashDecrease);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsAbleToDecrease(float cashDecrease)
    {
        return (cash >= cashDecrease);
    }

    public float GetCash()
    {
        return cash;
    }

    private void Decrease(float cashDecrease)
    {
        cash = cash - cashDecrease;
    }
}
