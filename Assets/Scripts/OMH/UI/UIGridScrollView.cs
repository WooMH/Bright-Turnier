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
        // ������ �ִ� ������ ����ŭ ����
        for(int i = 0; i < myItemCount; i++)
        {
            // itemSlotPrefabd�� �ν��Ͻ� clone
            var go = Instantiate(this.itemslotPrefab, this.content);
            var itemslot = go.GetComponent<UIGridScrollView>();
            // Init�ϸ鼭 ���̵�, ������, ���� �ֱ�
            /*itemslot.Init();*/
        }
    }
}
