using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class StarsDisplay : MonoBehaviour
{
    [SerializeField] int startStars = 100;
    [SerializeField] int timeForStars = 5;
    [SerializeField] int starsPlus = 10;
    Text starText;

    private void Start()
    {
        starText = GetComponent<Text>();
        UpdateDisplay();
        StartCoroutine(AddStarsCoroutine());
    }

    IEnumerator AddStarsCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeForStars);
            AddStars(starsPlus);
        }
    }

    private void UpdateDisplay()
    {
        starText.text = startStars.ToString();
    }

    public bool HaveEnoughStars(int amount)
    {
        return startStars >= amount;
    }

    public void AddStars(int amount)
    {
        startStars += amount;
        UpdateDisplay();
    }

    public void SpendStars(int amount)
    {
        if (startStars >= amount)
        {
            startStars -= amount;
            UpdateDisplay();
        }
    }
}
