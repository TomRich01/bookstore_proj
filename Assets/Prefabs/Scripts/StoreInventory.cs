using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class StoreInventory : MonoBehaviour
{

    [SerializeField] private float dailyStoreIncome;
    [SerializeField] public float totalStoreIncome;

    [SerializeField] private int defaultBookStorageCapacity = 100;
    [SerializeField] private int upgradedBookStorageCapacity = 200;
    [SerializeField] private int bookStorageCapacity;

    [SerializeField] private GameObject storageUpgradeObject;
    [SerializeField] private GameObject satisfactionUpgradeObject;

    private IncomeUI incomeUI;

    [SerializeField] private TextMeshProUGUI romanceTextMesh;
    [SerializeField] private TextMeshProUGUI scifiTextMesh;
    [SerializeField] private TextMeshProUGUI classicTextMesh;
    [SerializeField] private TextMeshProUGUI mysteryTextMesh;
    [SerializeField] private TextMeshProUGUI fantasyTextMesh;



    [SerializeField] private StoreAdditions storeAdditions;

    void Start()
    {
        DefineStorageCapacity();
        incomeUI = GetComponent<IncomeUI>();
    }

    #region Books

    public int b_romance;
    public int b_scifi;
    public int b_classic;
    public int b_mystery;
    public int b_fantasy;

    public int BookStorageCapacity { get => bookStorageCapacity; set => bookStorageCapacity = value; }
    #endregion

    private void Update()
    {
        romanceTextMesh.text = b_romance.ToString() + "/" + bookStorageCapacity.ToString();
        scifiTextMesh.text = b_scifi.ToString() + "/" + bookStorageCapacity.ToString();
        classicTextMesh.text = b_classic.ToString() + "/" + bookStorageCapacity.ToString();
        mysteryTextMesh.text = b_mystery.ToString() + "/" + bookStorageCapacity.ToString();
        fantasyTextMesh.text = b_fantasy.ToString() + "/" + bookStorageCapacity.ToString();
    }

    private void RoundIncome()
    {
        totalStoreIncome = Mathf.Round(totalStoreIncome * 100.0f) * 0.01f;
        incomeUI.GetTotalIncome(totalStoreIncome);
        dailyStoreIncome = Mathf.Round(dailyStoreIncome * 100.0f) * 0.01f;
        incomeUI.GetDailyIncome(dailyStoreIncome);
    }

    public void BuyBook(int genre, int num, float income)
    {
        if (num <= 0 || income <= 0)
        {
            Debug.Log("No books purchased.");
            return;
        }

        switch (genre)
        {
            case 0: // Romance
                b_romance -= num;
                break;
            case 1: // Sci-Fi
                b_scifi -= num;
                break;
            case 2: // Classic
                b_classic -= num;
                break;
            case 3: // Mystery
                b_mystery -= num;
                break;
            case 4: // Fantasy
                b_fantasy -= num;
                break;
            default:
                Debug.LogWarning("Invalid genre!");
                return;
        }

        totalStoreIncome += income;
        dailyStoreIncome += income;
        RoundIncome();
    }

    public void ResetDailyIncome()
    {
        dailyStoreIncome = 0.00f;
    }

    public void DefineStorageCapacity()
    {
        if (storeAdditions.StorageUpgrade)
        {
            bookStorageCapacity = upgradedBookStorageCapacity;
            print("Upgraded storage in use " + bookStorageCapacity);
        }
        else
        {
            bookStorageCapacity = defaultBookStorageCapacity;
            print("Default storage in use " + bookStorageCapacity);
        }

        b_romance = Math.Min(b_romance, bookStorageCapacity);
        b_scifi = Math.Min(b_scifi, bookStorageCapacity);
        b_classic = Math.Min(b_classic, bookStorageCapacity);
        b_mystery = Math.Min(b_mystery, bookStorageCapacity);
        b_fantasy = Math.Min(b_fantasy, bookStorageCapacity);
    }

    public void BuyStorageUpgrade()
    {
        if (totalStoreIncome >= 500)
        {
            totalStoreIncome -= 500;
            storageUpgradeObject.SetActive(false);
            storeAdditions.StorageUpgrade = true;
            DefineStorageCapacity();
        }
    }

    public void BuySatisfactionUpgrade()
    {
        if (totalStoreIncome >= 1000)
        {
            totalStoreIncome -= 1000;
            satisfactionUpgradeObject.SetActive(false);
            storeAdditions.CustomerSatisfactionUpgrade = true;
            
        }
    }
}
