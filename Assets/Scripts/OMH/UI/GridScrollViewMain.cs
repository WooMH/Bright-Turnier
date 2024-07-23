using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class GridScrollViewMain : MonoBehaviour
{
    public DataManager dataManager;  // 인스펙터에서 할당
    public UIGridScrollViewDirector director;
    void Start()
    {
        if (this.dataManager != null)
        {
            this.dataManager.LoadItemData();
            // director에게 초기화 시키기
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
        // 신규 유저든 기존 유저든 변하지 않는 게임 데이터는 반드시 로드 필요
        // 신규 유저, 기존 유저 판별
        Debug.Log(Application.persistentDataPath);
        string path = string.Format("{0}/inventory_info.json", Application.persistentDataPath);
        Debug.LogFormat("<color=cyan>{0}</color>", path);

        // inventory_info.json이 있는지 판별
        Debug.LogFormat("Exists: {0}", File.Exists(path));
        if (File.Exists(path))
        {
            // 있으면 기존 -> 역직렬화 
            Debug.Log("<color=yellow>기존유저</color>");
            
            // 불러오기
            string json = File.ReadAllText(path);

            // 역직렬화
            var inventoryInfo = JsonConvert.DeserializeObject<InventoryInfo>(json);
            Debug.LogFormat("inventoryInfo: {0}", inventoryInfo);
            Debug.LogFormat("inventoryInfo.ItemInfos.Count: {0}", inventoryInfo.ItemInfos.Count);

            // InfoManager에 저장
        }
        else
        {
            // 없으면 신규 -> info 만들어서 파일 inventory_info.json 저장
            var inventoryInfo = new InventoryInfo();
            inventoryInfo.Init();

            // 직렬화를 통해 객체를 문자열로 만들어야 한다
            string json = JsonConvert.SerializeObject(inventoryInfo);
            Debug.Log(json);

            // 파일 저장
            File.WriteAllText(path, json);
            Debug.Log("save complete");

            //InfoManager에 저장

        }
        // InfoManager.instance.inventoryInfo에 저장
    }
}
