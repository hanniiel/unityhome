using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;
using UnityEngine.UI;
using TMPro;
using System.Threading.Tasks;

public class HomeController : MonoBehaviour
{
    public GameObject prefabCardProart,prefabCardPaint;

    [SerializeField] CharacterSelectionHandler characterSelectionHandler;
    [SerializeField] HorizontalScrollSnap horizontalScrollSnap;
    [SerializeField] HomeProgressUI homeProgressUI;
    [SerializeField] UI_InfiniteScroll infiniteScroll;

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
    private void Start()
    {
       
        //start button from details
        UIDetails.buttonStart.onClick.AddListener(() =>
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
        currentCategory = selection.category;
        
        CleanCards();
       
    }

    void SetCards()
    {
        homeProgressUI.txtCategory.text = currentCategory.ToString();

        switch (currentCategory)
        {

            case CharacterSelectionControl.Category.PAINTING:
                imageBackground.color = colorsBackground[1];
                homeProgressUI.txtCategory.font = tmp_Fonts[0];
                InstantiatePainting();
                break;
            case CharacterSelectionControl.Category.DESIGN:
                
                break;
            case CharacterSelectionControl.Category.PROART:
                imageBackground.color = colorsBackground[1];
                homeProgressUI.txtCategory.font = tmp_Fonts[1];
                InstantiatePainting();
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
            SetCards();
            return;
        }

        projectCards.Clear();
        GameObject removed;
      //  horizontalScrollSnap.RemoveAllChildren(out removed);
        for (int i = 0; i < horizontalScrollSnap._screensContainer.childCount; i++)
        {
            horizontalScrollSnap.RemoveChild(i,out removed);
        }

        SetCards();
    }

    void InstantiatePainting()
    {
        for (int i = 0; i < 5; i++)
        {
            var card = Instantiate(prefabCardPaint);
            var script = card.GetComponent<CardUIControl>();
            script.button.onClick.AddListener(OnClick_Paint);
            //projectCards.Add(i.ToString(),script);
            horizontalScrollSnap.AddChild(card);
        }
        horizontalScrollSnap.UpdateLayout();
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
    }
    void OnSelectedPageEnd(int page)
    {
        Debug.Log($"ended event selected page {page}");
    }

}
