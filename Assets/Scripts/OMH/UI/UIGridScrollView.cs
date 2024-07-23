using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGridScrollView : MonoBehaviour
{
    public Transform content;
    public GameObject itemslotPrefab;

    public void Init()
    {
        int myItemCount = 10;
        // 가지고 있는 아이템 수만큼 생성
        for(int i = 0; i < myItemCount; i++)
        {
            // itemSlotPrefabd의 인스턴스 clone
            var go = Instantiate(this.itemslotPrefab, this.content);
            var itemslot = go.GetComponent<UIGridScrollView>();
            // Init하면서 아이디, 아이콘, 수량 넣기
            /*itemslot.Init();*/
        }
    }
}
