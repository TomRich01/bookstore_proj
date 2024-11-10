using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WorldTime : MonoBehaviour
{

    #region World Vars
    [SerializeField] float currentTime;
    float endTime = 0;
   [SerializeField] float startTime;
    bool isToggled;
	[SerializeField] Image buttonImage;
    #endregion


    private void Start()
    {
        currentTime = startTime;
    }

    private void Update()
    {

        if (isToggled)
        {
            StartCoroutine(Timer());
        }
        else
        {
            StopCoroutine(Timer());
        }
    }

    public void StartTime()
    {
        

        isToggled = true;


       
    }

    IEnumerator Timer()
    {

        currentTime -= Time.deltaTime;

        if (currentTime <= endTime)
        {
            currentTime = startTime;
            isToggled = false;
	        buttonImage.gameObject.SetActive(true);
        }
        yield return new WaitForSeconds(.1f);
    }
}
