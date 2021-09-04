using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageView : MonoBehaviour
{
    public static PackageView Instance { get; private set; }
    [SerializeField] private itemView itemPrefab;

    [SerializeField] private GameObject grid;
    
    [SerializeField] private PictureResource pictureResource;

    [SerializeField] private CaptionPanel captionPanel;

    [SerializeField] private GameObject GO;

    [SerializeField] private Package packageImplement; 
    private IPackage package;
    private Dictionary<string, (ItemData, itemView)> items=new Dictionary<string, (ItemData, itemView)>();
    private void Awake()
    {
        Instance = this;
        captionPanel.Intialize(Use);
        package = packageImplement;
        ReSetItem();
    }

    private void ReSetItem()
    {
        foreach (var value in items.Values)
        {
            Destroy(value.Item2.gameObject);
        }
        items.Clear();
        itemView itemView;
        Sprite token;
        var datas = package.DeepClone();
        for (int i = 0; i < datas.Count; i++)
        {
            token = pictureResource.GetSprite(datas[i].IconName);
            itemView = Instantiate(itemPrefab, grid.transform);
            itemView.Intialize(token, datas[i].Count, ClickItem);
            itemView.name = datas[i].Name;
            var item = (data: datas[i], view: itemView);
            items.Add(item.data.Name, item);
        }
        GO.SetActive(false);
    }

    internal void ReSet()
    {
        ReSetItem();
    }

    public void Click()
    {
        GO.SetActive(!GO.activeSelf);
        captionPanel.gameObject.SetActive(false);
    }

    public void ClickItem(string name)
    {
        captionPanel.gameObject.SetActive(true);
        if (items.ContainsKey(name))
        {
            var item = items[name].Item1;
            captionPanel.Set(item.Name, item.Content, pictureResource.GetSprite(item.IconName));
        }
    }
    public void Use(string name)
    {
        if (items.ContainsKey(name))
        {
            var itemPair = items[name];
            itemPair.Item1.Count--;
            itemPair.Item2.SetNumber(itemPair.Item1.Count);
            if (itemPair.Item1.Count <= 0)
            {
                captionPanel.gameObject.SetActive(false);
            }
        }
    }
    internal Sprite GetSprite(string name)
    {
        Sprite sprite=null;
        if (items.ContainsKey(name))
        {
            sprite= pictureResource.GetSprite(items[name].Item1.IconName);
        }
        return sprite;
    }


    internal void AddItem(string name)
    {
        if (items.ContainsKey(name))
        {
            items[name].Item1.Count++;
            items[name].Item2.SetNumber(items[name].Item1.Count);
        }
    }

}
