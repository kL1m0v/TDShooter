using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SceneCanvasComponent : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _victoryText;
    [SerializeField]
    private TextMeshProUGUI _enemiesKilledText;
    [SerializeField]
    private TextMeshProUGUI _requiredNumberDeathsText;
    [SerializeField]
    private TextMeshProUGUI _amountMoneyText;

    private void Start()
    {
        _victoryText.enabled = false;
        _enemiesKilledText.enabled = true;
        _requiredNumberDeathsText.enabled = true;
    }

    public void SetTextAndVisible(string text, bool isVisible)
    {
        _victoryText.text = text;
        _victoryText.enabled = isVisible;
    }

    public void RedrawEnemiesKilledText(int value)
    {
        _enemiesKilledText.text = value.ToString();
    }

    public void RedrawRequiredNumberDeathsText(int value) 
    {
        _requiredNumberDeathsText.text = value.ToString() + "/";
    }

    public void RedrawAmountMoney(int value)
    {
        _amountMoneyText.text = value.ToString();
    }


}
