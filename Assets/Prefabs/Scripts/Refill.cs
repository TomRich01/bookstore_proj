using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Refill : MonoBehaviour
{

  [SerializeField] private StoreInventory storeInventory;

    [SerializeField] private TMP_InputField romanceInputField;
    [SerializeField] private TMP_InputField scifiInputField;
    [SerializeField] private TMP_InputField classicInputField;
    [SerializeField] private TMP_InputField mysteryInputField;
    [SerializeField] private TMP_InputField fantasyInputField;

    [SerializeField] private TextMeshProUGUI totalIncomeText;

    private void Start()
    {
        storeInventory = FindObjectOfType<StoreInventory>();
    }
    private void OnDisable()
    {
        romanceInputField.text = "";
    }

    private void Update()
    {
        totalIncomeText.text = "$" + storeInventory.totalStoreIncome.ToString("n2");
    }

    public void RefillRomanceBooks()
    {
        string inputText = romanceInputField.text;

        if (string.IsNullOrEmpty(inputText))
        {
            // Do not proceed if the input field is empty
            return;
        }

        int amountToFill = int.Parse(romanceInputField.text);
        int maxStorage = storeInventory.BookStorageCapacity; // Replace this with the actual maximum storage capacity variable
         // Check if the storage is already full
        if (storeInventory.b_romance >= maxStorage)
        {
            // Do not update the inventory if the storage is full
            return;
        }
        // Check if adding the amountToFill would exceed the max storage
        if (storeInventory.b_romance + amountToFill > maxStorage)
        {
            // If it does, set the amountToFill to the remaining available storage
            amountToFill = maxStorage - storeInventory.b_romance;
            romanceInputField.text = amountToFill.ToString();
        }

       float amountToFillCost = amountToFill * 2;

        if (storeInventory.totalStoreIncome >= amountToFillCost)
        {
            storeInventory.b_romance += amountToFill;
            storeInventory.totalStoreIncome -= amountToFillCost;
        }
        else
        {
            return;
        }

       
    }

    public void RefillScifiBooks()
    {
        string inputText = scifiInputField.text;

        if (string.IsNullOrEmpty(inputText))
        {
            // Do not proceed if the input field is empty
            return;
        }

        int amountToFill = int.Parse(scifiInputField.text);
        int maxStorage = storeInventory.BookStorageCapacity; // Replace this with the actual maximum storage capacity variable
                                                             // Check if the storage is already full
        if (storeInventory.b_scifi >= maxStorage)
        {
            // Do not update the inventory if the storage is full
            return;
        }
        // Check if adding the amountToFill would exceed the max storage
        if (storeInventory.b_scifi + amountToFill > maxStorage)
        {
            // If it does, set the amountToFill to the remaining available storage
            amountToFill = maxStorage - storeInventory.b_scifi;
            scifiInputField.text = amountToFill.ToString();
        }

        float amountToFillCost = amountToFill * 2;

        if (storeInventory.totalStoreIncome >= amountToFillCost)
        {
            storeInventory.b_scifi += amountToFill;
            storeInventory.totalStoreIncome -= amountToFillCost;
        }
        else
        {
            return;
        }


    }

    public void RefillClassicBooks()
    {
        string inputText = classicInputField.text;

        if (string.IsNullOrEmpty(inputText))
        {
            // Do not proceed if the input field is empty
            return;
        }

        int amountToFill = int.Parse(classicInputField.text);
        int maxStorage = storeInventory.BookStorageCapacity; // Replace this with the actual maximum storage capacity variable
                                                             // Check if the storage is already full
        if (storeInventory.b_classic >= maxStorage)
        {
            // Do not update the inventory if the storage is full
            return;
        }
        // Check if adding the amountToFill would exceed the max storage
        if (storeInventory.b_classic + amountToFill > maxStorage)
        {
            // If it does, set the amountToFill to the remaining available storage
            amountToFill = maxStorage - storeInventory.b_classic;
            classicInputField.text = amountToFill.ToString();
        }

        float amountToFillCost = amountToFill * 2;

        if (storeInventory.totalStoreIncome >= amountToFillCost)
        {
            storeInventory.b_classic += amountToFill;
            storeInventory.totalStoreIncome -= amountToFillCost;
        }
        else
        {
            return;
        }


    }

    public void RefillMysteryBooks()
    {
        string inputText = mysteryInputField.text;

        if (string.IsNullOrEmpty(inputText))
        {
            // Do not proceed if the input field is empty
            return;
        }

        int amountToFill = int.Parse(mysteryInputField.text);
        int maxStorage = storeInventory.BookStorageCapacity; // Replace this with the actual maximum storage capacity variable
                                                             // Check if the storage is already full
        if (storeInventory.b_mystery >= maxStorage)
        {
            // Do not update the inventory if the storage is full
            return;
        }
        // Check if adding the amountToFill would exceed the max storage
        if (storeInventory.b_mystery + amountToFill > maxStorage)
        {
            // If it does, set the amountToFill to the remaining available storage
            amountToFill = maxStorage - storeInventory.b_mystery;
            mysteryInputField.text = amountToFill.ToString();
        }

        float amountToFillCost = amountToFill * 2;

        if (storeInventory.totalStoreIncome >= amountToFillCost)
        {
            storeInventory.b_mystery += amountToFill;
            storeInventory.totalStoreIncome -= amountToFillCost;
        }
        else
        {
            return;
        }


    }

      public void RefillFantasyBooks()
    {
        string inputText = fantasyInputField.text;

        if (string.IsNullOrEmpty(inputText))
        {
            // Do not proceed if the input field is empty
            return;
        }

        int amountToFill = int.Parse(fantasyInputField.text);
        int maxStorage = storeInventory.BookStorageCapacity; // Replace this with the actual maximum storage capacity variable
                                                             // Check if the storage is already full
        if (storeInventory.b_fantasy >= maxStorage)
        {
            // Do not update the inventory if the storage is full
            return;
        }
        // Check if adding the amountToFill would exceed the max storage
        if (storeInventory.b_fantasy + amountToFill > maxStorage)
        {
            // If it does, set the amountToFill to the remaining available storage
            amountToFill = maxStorage - storeInventory.b_fantasy;
            fantasyInputField.text = amountToFill.ToString();
        }

        float amountToFillCost = amountToFill * 2;

        if (storeInventory.totalStoreIncome >= amountToFillCost)
        {
            storeInventory.b_fantasy += amountToFill;
            storeInventory.totalStoreIncome -= amountToFillCost;
        }
        else
        {
            return;
        }


    }



}
