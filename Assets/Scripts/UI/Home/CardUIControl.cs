using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class CardUIControl : MonoBehaviour
{
    //UI data
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public Gradient2 gradient;
    public Image cover;
    public Slider slider;
    public Button button, buttondownload;
    public GameObject paneldownload, progressObject;

    public bool IsDownloading
    {
        set
        {
            buttondownload.gameObject.SetActive(!value);
            progressObject.SetActive(value);
        }
    }
    //other props
    //cards colors
    public Color colorFontArts, colorFontOthers;
    [SerializeField]
    public UnityEngine.Gradient[] colorCards;
    //

    

    

    public void Downloaded(bool isDownloaded)
    {
        paneldownload.SetActive(!isDownloaded);
    }

   
}
