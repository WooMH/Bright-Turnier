using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryTabMenu : MonoBehaviour
{
    // �������� ���� �κ��丮 ĭ
    public GameObject[] ScrollViews;
    // �� ��ư�� Image ������Ʈ���� ���� �迭
    public Image[] TabButtons;
    // ���õ��� ���� �� ���� ���õ� �� ����� ���� ��������Ʈ
    public Sprite DeselectedTabBG, SelectedTabBG;
    private void Start()
    {
        // ������ �� Element0(���â)�� Ȱ��ȭ�մϴ�
        SwitchToTab(0);
    }
    // �־��� TabID�� ���� Ư�� ������ ��ȯ�ϴ� �޼���
    public void SwitchToTab(int TabID)
    {
        // ��� ���� ��Ȱ��ȭ�մϴ�
        for (int i = 0; i < ScrollViews.Length; i++)
        {
            ScrollViews[i].SetActive(false);
        }

        // �־��� TabID�� �ش��ϴ� ���� Ȱ��ȭ�մϴ�
        ScrollViews[TabID].SetActive(true);

        // ��� �� ��ư�� �ݺ��ϸ鼭 �ش����� �ʴ� �� ��ư�� DeselectedTabBG�� ����
        for (int i = 0; i < TabButtons.Length; i++)
        {
            TabButtons[i].sprite = DeselectedTabBG;
        }
        // �־��� TabID�� �ش��ϴ� �� ��ư�� SelectedTabBG�� ����
        TabButtons[TabID].sprite = SelectedTabBG;
    }
}
