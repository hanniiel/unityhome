using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class DetailsHomeUI : UIBase
{
    [SerializeField] Gradient2 gradientBackground;
    [SerializeField] TextMeshProUGUI title, description;
    [SerializeField] Image imageCover;
    public Button buttonClose, buttonStart;

    [SerializeField] DOTweenAnimation tweenAnimation;

    void Start()
    {
        buttonClose.onClick.AddListener(tweenAnimation.DOPlayBackwards);
    }

    public void SetColors(Color colorFont, UnityEngine.Gradient gradientColor, Image imageCover = null)
    {
        title.color = colorFont;
        description.color = colorFont;
        gradientBackground.EffectGradient = gradientColor;
    }
    public async void SetData()
    {
        
    }

    public override void Hide()
    {
        Disable();
    }

    public override void Show()
    {
        Enable();
        tweenAnimation.DOPlayForward();
    }
}
