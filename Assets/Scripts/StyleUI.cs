using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Create UI custom style")]
public class StyleUI : ScriptableObject
{
    public UnityEngine.Gradient cardGradient;
    public Color backgroundColor;
    public Image background;
    public Color primary;
    public Color font;
    public Color fontshadow;
}
