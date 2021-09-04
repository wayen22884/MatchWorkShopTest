using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


[CreateAssetMenu(fileName = "Packge", menuName = "ScriptableObjects/PackgeScriptableObject", order = 1)]
public class Package : ScriptableObject,IPackage
{
    public List<ItemData> items;
    public List<ItemData> DeepClone()
    {
        List<ItemData> copys = new List<ItemData>();
        ItemData data;
        foreach (var item in items)
        {
            using (Stream objectStream = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(objectStream, item);
                objectStream.Seek(0, SeekOrigin.Begin);
                data = formatter.Deserialize(objectStream) as ItemData;
            }
            copys.Add(data);
        }
        return copys;
    }

}


[Serializable]
public class ItemData
{
    public string Name;
    public string IconName;
    public string Content;
    public int Count;
}
