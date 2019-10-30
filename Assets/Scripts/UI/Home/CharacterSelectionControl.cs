using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectionControl : MonoBehaviour
{
    public Category category;

    public enum Category{
        PROART,
        PAINTING,//3dpaint
        DESIGN,//cad3d
        ARTS//2dpaint
    }
}
