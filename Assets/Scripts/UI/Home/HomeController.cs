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
    }

    private void LocalizationManager_Event_LanguageChanged()
    {
        CleanCards();
        SetCards();
    }

    void OnDisable()
    {
        characterSelectionHandler.OnSelectionChanged -= CharacterSelectionHandler_OnSelectionChanged;

    }

    /// <summary>
    /// get current selection to set cards for the selected category 
    /// </summary>
    /// <param name="selection"></param>
    private void CharacterSelectionHandler_OnSelectionChanged(CharacterSelectionControl selection)
    {
        currentCategory = selection.category;
        
        CleanCards();
        SetCards();
    }

    async Task SetCards()
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

                break;
            default:
                break;
        }
    }
    //removed card objets from UI
    void CleanCards()
    {
        projectCards.Clear();
        GameObject[] removed;
        horizontalScrollSnap.RemoveAllChildren(out removed);
        for (int i = 0; i < removed.Length; i++)
        {
            Destroy(removed[i]);
        }
    }

    void InstantiatePainting()
    {
        for (int i = 0; i < 5; i++)
        {
            var card = Instantiate(prefabCardPaint);
            var script = card.GetComponent<CardUIControl>();
            script.button.onClick.AddListener(OnClick_Paint);

            horizontalScrollSnap.AddChild(card);
        }
        horizontalScrollSnap.ChangePage(0);

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

}
