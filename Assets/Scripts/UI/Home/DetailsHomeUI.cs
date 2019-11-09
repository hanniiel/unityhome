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
        tweenAnimation.onComplete.AddListener(() => {
            
        });
        tweenAnimation.onRewind.AddListener(Disable);
    }

    public void SetStyle(StyleUI style)
    {
        title.color = style.font;
        title.outlineColor = style.fontshadow;
        gradientBackground.EffectGradient.SetKeys(style.cardGradient.colorKeys, style.cardGradient.alphaKeys);
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
