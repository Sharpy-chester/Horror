using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    [SerializeField] Text interactTxt;
    [SerializeField] string textToShow = "Press E to pick up";

    private void Start()
    {
        interactTxt = UIManager.Instance.tooltipText;
    }

    public void ShowText()
    {
        interactTxt.gameObject.SetActive(true);
        interactTxt.text = textToShow;
    }

    public void HideText()
    {
        interactTxt.gameObject.SetActive(false);
    }
}
