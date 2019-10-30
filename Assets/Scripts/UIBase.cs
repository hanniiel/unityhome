using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class UIBase : MonoBehaviour {

    public abstract void Show();
    public abstract void Hide();

    public void Enable() => gameObject.SetActive(true);
    public void Disable() => gameObject.SetActive(false);

}
