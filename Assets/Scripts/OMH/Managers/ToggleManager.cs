using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleManager : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject optionPanel;

    private bool activeInventory = false;
    private bool activeOption = false;

    public ResolutionManager resolutionManager;

    void Start()
    {
        inventoryPanel.SetActive(activeInventory);
        optionPanel.SetActive(activeOption);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            activeInventory = !activeInventory;
            inventoryPanel.SetActive(activeInventory);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            activeOption = !activeOption;
            optionPanel.SetActive(activeOption);
            resolutionManager.CancelSettings();
        }
    }

    // aPanel�� ���� ���¿��� bPanel�� Ű�� aPanel ������ bPanel ����
    public void ToggleInventory()
    {
        if (!activeInventory)
        {
            if (activeOption)
            {
                ToggleOption(false);
            }
        }
        activeInventory = !activeInventory;
        inventoryPanel.SetActive(activeInventory);
    }

    public void ToggleOption()
    {
        if (!activeOption)
        {
            if (activeInventory)
            {
                ToggleInventory(false);
            }
        }
        activeOption = !activeOption;
        optionPanel.SetActive(activeOption);
    }
    // Panel�� true�� Ȱ��ȭ, false�� ��Ȱ��ȭ
    public void ToggleInventory(bool state)
    {
        activeInventory = state;
        inventoryPanel.SetActive(activeInventory);
    }
    public void ToggleOption(bool state)
    {
        activeOption = state;
        optionPanel.SetActive(activeOption);
    }
}
