using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 변하는데이터(저장객체)
public class InventoryInfo
{
    public List<ItemInfo> ItemInfos; // 컬렉션 반드시 사용 전에 Instance
    // 처음 생성될때(우리가 객체를 만든다)
    public void Init()
    {
        this.ItemInfos = new List<ItemInfo>();
    }
    // 역직렬화될때(Newton에서 객체 생성)
}
