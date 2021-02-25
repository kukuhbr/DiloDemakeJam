using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private CashManager cashManager;
    // Start is called before the first frame update
    void Start()
    {
        if (cashManager == null)
        {
            cashManager = CashManager.Instance;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Buy()
    {
        if (cashManager.IsAbleToDecrease(10))
        {
            cashManager.DecreaseTransaction(10);
        }
        
    }
}
