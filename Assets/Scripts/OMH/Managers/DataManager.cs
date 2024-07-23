using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Linq;

public class DataManager : MonoBehaviour
{
    private Dictionary<int, ItemData> dicItemData;
    public void LoadItemData()
    {
        TextAsset asset = Resources.Load<TextAsset>("Data/item_data");
        if (asset == null)
        {
            Debug.LogError("item_data resource not found.");
            return;
        }
        string json = asset.text;
        Debug.Log(json);
        ItemData[] arr = JsonConvert.DeserializeObject<ItemData[]>(json);
        if (arr != null)
        {
            this.dicItemData = new Dictionary<int, ItemData>();

            foreach (ItemData item in arr)
            {
                if (!this.dicItemData.ContainsKey(item.id))
                {
                    this.dicItemData.Add(item.id, item);
                }
                else
                {
                    Debug.LogWarning($"Duplicate key found: {item.id}. Skipping this entry.");
                }
            }
            Debug.Log("Item data loaded");
            Debug.LogFormat("Item data count: <color=yellow>{0}</color>", this.dicItemData.Count);
        }
        else
        {
            Debug.LogError("Failed to deserialize item data.");
        }
    }
    public ItemData GetItemData(int id)
    {
        if (this.dicItemData != null && this.dicItemData.ContainsKey(id))
        {
            return this.dicItemData[id];
        }
        Debug.LogFormat("Key ({0}) not found.", id);
        return null;
    }
}