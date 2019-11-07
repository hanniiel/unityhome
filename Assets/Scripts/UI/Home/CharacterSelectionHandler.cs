using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectionHandler : MonoBehaviour
{
    /// <summary>
    /// subscribe to category/characters toggle changes
    /// </summary>
    public event Action<CharacterSelectionControl> OnSelectionChanged;
    // Start is called before the first frame update
    void Start()
    {
        bool isFisrt = true;
        for (int i = 0; i < transform.childCount; i++)
        {
           var toggle = transform.GetChild(i)?.GetComponent<Toggle>();
            if (toggle != null)
            {
                var categoryScript = transform.GetChild(i).GetComponent<CharacterSelectionControl>();

                //subscribe from toggle
                toggle.onValueChanged.AddListener((isOn) =>
                {
                    if (isOn)
                    {
                        OnSelectionChanged?.Invoke(categoryScript);
                    }
                });
                //set default category
                toggle.isOn = isFisrt;
                isFisrt = false;
            }
        }
    }

}
