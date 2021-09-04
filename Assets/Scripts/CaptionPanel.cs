using UnityEngine.UI;
using UnityEngine;
using System;
using UniRx;
public class CaptionPanel : MonoBehaviour
{
    [SerializeField] Text caption;
    [SerializeField] Text content;
    [SerializeField] Image token;

    Action<string> use;
    internal void Set(string name, string content, Sprite sprite)
    {
        caption.text = name;
        this.content.text = content;
        token.sprite = sprite;
    }

    public void Intialize(Action<string> use)
    {
        this.use = use;
    }
    public void Use()
    {
        use?.Invoke(caption.text);
    }
    IDisposable longPress;
    public void LongPressDown()
    {
        longPress = Observable.Interval(TimeSpan.FromSeconds(2))
            .Subscribe(_ => Use())
            .AddTo(this);
    }
    public void LongPressUp()
    {
        longPress?.Dispose();
    }
    private void OnDisable()
    {
        LongPressUp();
    }
}
