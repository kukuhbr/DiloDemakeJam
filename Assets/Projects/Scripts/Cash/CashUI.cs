using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class CashUI : MonoBehaviour
{
    public TextMeshProUGUI textUI;
    public string cashText;
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
        UpdateCash();
    }

    private void UpdateCash()
    {
        textUI.text = cashText + " " + cashManager.GetCash().ToString();
    }
}
