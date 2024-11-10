using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreAdditions : MonoBehaviour
{
    private bool _customerSatisfactionUpgrade;
    private bool _storageUpgrade;

    public bool CustomerSatisfactionUpgrade
    {
        get { return _customerSatisfactionUpgrade; }
        set { _customerSatisfactionUpgrade = value; }
    }

    public bool StorageUpgrade
    {
        get { return _storageUpgrade; }
        set { _storageUpgrade = value; }
    }

}
