using UnityEngine.UI;
using UnityEngine;
using System;

public class itemView : MonoBehaviour
{
    [SerializeField] Image token;
    [SerializeField] Text number;

    Action<string> showCaption;
    public void Intialize(Sprite sprite,int number,Action<string> showCaption)
    {
        token.sprite = sprite;
        SetNumber(number);
        this.showCaption = showCaption;
    }
    public void SetNumber(int number)
    {
        this.number.text = number.ToString();
        gameObject.SetActive(number > 0);
    }
    public void Click()
    {
        showCaption?.Invoke(gameObject.name);
    }
}
