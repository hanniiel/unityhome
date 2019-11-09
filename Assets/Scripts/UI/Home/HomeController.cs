using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;
using UnityEngine.UI;
using TMPro;
using System.Threading.Tasks;
using DG.Tweening;
public class HomeController : MonoBehaviour
{
    public GameObject prefabCardProart,prefabCardPaint;

    [SerializeField] CharacterSelectionHandler characterSelectionHandler;
    [SerializeField] HorizontalScrollSnap horizontalScrollSnap;
    [SerializeField] HomeProgressUI homeProgressUI;
    [SerializeField] UI_InfiniteScroll infiniteScroll;
    [SerializeField] TextMeshProUGUI txtSelection;
    [SerializeField] StyleUI[] styles;
    [SerializeField] Image bar;

    [Header("Views")]
    [SerializeField]DetailsHomeUI UIDetails;
    [Header("Background")]
    public Image imageBackground;
    [Header("Background colors")]
    public Color[] colorsBackground;
    [Header("Fonts")]
    public TMP_FontAsset[] tmp_Fonts;
    [Header("image grade")]
    public Image imageGrade;
    [Header("Test Mode")]
    public bool IsTest;


    //data
    CharacterSelectionControl.Category currentCategory;
    Dictionary<string, CardUIControl> projectCards = new Dictionary<string, CardUIControl>();

    //current style
    StyleUI currentStyle;
    
    private void Start()
    {
       
        //start button from details
        UIDetails.buttonStart?.onClick.AddListener(() =>
        {
            if(currentCategory== CharacterSelectionControl.Category.PROART)
            {

            }
            else
            {
                //navigate to activity
                //instantiate evidences if project not empty
            }

        });
    }

    void OnEnable()
    {
        characterSelectionHandler.OnSelectionChanged += CharacterSelectionHandler_OnSelectionChanged;
        horizontalScrollSnap.OnSelectionChangeEndEvent.AddListener(OnSelectedPageEnd);
    }

    private void LocalizationManager_Event_LanguageChanged()
    {
        CleanCards();
        SetCards();
    }

    void OnDisable()
    {
        characterSelectionHandler.OnSelectionChanged -= CharacterSelectionHandler_OnSelectionChanged;
        horizontalScrollSnap.OnSelectionChangeEndEvent.RemoveListener(OnSelectedPageEnd);
    }

    /// <summary>
    /// get current selection to set cards for the selected category 
    /// </summary>
    /// <param name="selection"></param>
    private void CharacterSelectionHandler_OnSelectionChanged(CharacterSelectionControl selection)
    {
        Debug.Log(" cay changed");

        currentCategory = selection.category;
        txtSelection.text = selection.category.ToString();
        txtSelection.transform.DOMoveX(selection.transform.position.x, 0.2f);
        CleanCards();
       
    }
    void SetStyle()
    {
        imageBackground.color = currentStyle.backgroundColor;
        txtSelection.outlineColor = currentStyle.fontshadow;
        txtSelection.color = currentStyle.font;
        bar.color = currentStyle.primary;
        currentGradient = currentStyle.cardGradient;
    }

    public UnityEngine.Gradient currentGradient;
    void SetCards()
    {
        homeProgressUI.txtCategory.text = currentCategory.ToString();

        switch (currentCategory)
        {

            case CharacterSelectionControl.Category.PAINTING:
                currentStyle = styles[0];
                SetStyle();
                InstantiatePainting(prefabCardPaint);
                break;
            case CharacterSelectionControl.Category.DESIGN:
                currentStyle = styles[1];
                SetStyle();
                //homeProgressUI.txtCategory.font = tmp_Fonts[0];
                InstantiatePainting(prefabCardPaint);
                break;
            case CharacterSelectionControl.Category.PROART:
                currentStyle = styles[2];
                SetStyle();

                // homeProgressUI.txtCategory.font = tmp_Fonts[1];
                InstantiatePainting(prefabCardProart);
                break;
            default:
                break;
        }
    }
    //removed card objets from UI
    void CleanCards()
    {
        if (horizontalScrollSnap._screensContainer.childCount == 0)
        {
            Debug.Log("clear 1st ");

            SetCards();
            return;
        }

        projectCards.Clear();
        GameObject[] removed;
        horizontalScrollSnap.RemoveAllChildren(out removed);
        infiniteScroll.items.Clear();
        horizontalScrollSnap._currentPage = 0;

        SetCards();
    }
  
    void InstantiatePainting(GameObject prefabCard)
    {
        for (int i = 0; i < 5; i++)
        {
            var card = Instantiate(prefabCard);
            var script = card.GetComponent<CardUIControl>();
            script.button.onClick.AddListener(OnClick_Paint);
            script.gradient.EffectGradient.SetKeys(currentGradient.colorKeys , currentGradient.alphaKeys);
            projectCards[i.ToString()] = script;
            horizontalScrollSnap.AddChild(card);
        }

        infiniteScroll.Init();
        
    }
    /// <summary>
    /// Instantiate cards by project list provided
    /// </summary>
    /// <param name="projects"></param>
    void InstantiateProjects()
    {
        
    }

    void OnClick_Paint()
    {
        Debug.Log("paint clicked");
        UIDetails.SetStyle(currentStyle);
        UIDetails.Show();
    }
    CardUIControl currentCard;
    void OnSelectedPageEnd(int page)
    {
        Debug.Log($"ended event selected page {page}");
        if (currentCard != null)
        {
            currentCard.transform.GetChild(0).DOScale(Vector2.one,0.2f);
        }
        currentCard = projectCards[page.ToString()];
        currentCard.transform.GetChild(0).DOScale(new Vector2(1.2f,1.2f), 0.2f);
    }

}
