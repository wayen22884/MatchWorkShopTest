using UnityEngine.UI;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]private string Name;
    [SerializeField]private SpriteRenderer Icon;

    private void Start()
    {
        Icon.sprite = PackageView.Instance.GetSprite(Name);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PackageView.Instance.AddItem(Name);
        gameObject.SetActive(false);
    }

}
