using System.Collections.Generic;

public interface IPackage
{
    List<ItemData> DeepClone();
}