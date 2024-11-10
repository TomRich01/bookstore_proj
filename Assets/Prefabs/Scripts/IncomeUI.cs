using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class IncomeUI : MonoBehaviour
{
    private float maxNum = 999999999.99f;
    private float minNum = 0.00f;
    [SerializeField] private TextMeshProUGUI incomeTextMesh;
    [Space(5)]
    [SerializeField] private TextMeshProUGUI totalTextMesh;
    [SerializeField] private TextMeshProUGUI dailyTextMesh;


    public void GetTotalIncome(float num)
    {
        totalTextMesh.text = "$"+num.ToString("n2");
    }

    public void GetDailyIncome(float num)
    {
        dailyTextMesh.text = "$" + num.ToString("n2");
        incomeTextMesh.text = "$" + num.ToString("n2");
    }

}
