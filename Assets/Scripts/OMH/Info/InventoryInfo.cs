using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���ϴµ�����(���尴ü)
public class InventoryInfo
{
    public List<ItemInfo> ItemInfos; // �÷��� �ݵ�� ��� ���� Instance
    // ó�� �����ɶ�(�츮�� ��ü�� �����)
    public void Init()
    {
        this.ItemInfos = new List<ItemInfo>();
    }
    // ������ȭ�ɶ�(Newton���� ��ü ����)
}
