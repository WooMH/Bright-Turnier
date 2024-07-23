using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class GridScrollViewMain : MonoBehaviour
{
    public DataManager dataManager;  // �ν����Ϳ��� �Ҵ�
    public UIGridScrollViewDirector director;
    void Start()
    {
        if (this.dataManager != null)
        {
            this.dataManager.LoadItemData();
            // director���� �ʱ�ȭ ��Ű��
            if (this.director != null)
            {
                this.director.Init();
            }
            else
            {
                Debug.LogError("UIGridScrollViewDirector is not assigned.");
            }
        }
        else
        {
            Debug.LogError("DataManager is not assigned.");
        }
        // �ű� ������ ���� ������ ������ �ʴ� ���� �����ʹ� �ݵ�� �ε� �ʿ�
        // �ű� ����, ���� ���� �Ǻ�
        Debug.Log(Application.persistentDataPath);
        string path = string.Format("{0}/inventory_info.json", Application.persistentDataPath);
        Debug.LogFormat("<color=cyan>{0}</color>", path);

        // inventory_info.json�� �ִ��� �Ǻ�
        Debug.LogFormat("Exists: {0}", File.Exists(path));
        if (File.Exists(path))
        {
            // ������ ���� -> ������ȭ 
            Debug.Log("<color=yellow>��������</color>");
            
            // �ҷ�����
            string json = File.ReadAllText(path);

            // ������ȭ
            var inventoryInfo = JsonConvert.DeserializeObject<InventoryInfo>(json);
            Debug.LogFormat("inventoryInfo: {0}", inventoryInfo);
            Debug.LogFormat("inventoryInfo.ItemInfos.Count: {0}", inventoryInfo.ItemInfos.Count);

            // InfoManager�� ����
        }
        else
        {
            // ������ �ű� -> info ���� ���� inventory_info.json ����
            var inventoryInfo = new InventoryInfo();
            inventoryInfo.Init();

            // ����ȭ�� ���� ��ü�� ���ڿ��� ������ �Ѵ�
            string json = JsonConvert.SerializeObject(inventoryInfo);
            Debug.Log(json);

            // ���� ����
            File.WriteAllText(path, json);
            Debug.Log("save complete");

            //InfoManager�� ����

        }
        // InfoManager.instance.inventoryInfo�� ����
    }
}
