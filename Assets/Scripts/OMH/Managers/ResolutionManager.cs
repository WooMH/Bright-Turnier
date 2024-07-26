using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ResolutionManager : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;
    public Button applyButton;

    private Resolution[] resolutions;
    private bool fullscreen;
    private int selectedResolutionIndex;

    void Start()
    {
        // �ػ� ����Ʈ ��������
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        // Dropdown�� �ɼ� �߰��ϱ�
        List<string> options = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
        }
        resolutionDropdown.AddOptions(options);

        // ���� �ػ� ����
        selectedResolutionIndex = FindCurrentResolutionIndex();
        resolutionDropdown.value = selectedResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        // ��� ���� ����
        fullscreenToggle.isOn = Screen.fullScreen;

        // ��ư Ŭ�� �� ����
        applyButton.onClick.AddListener(ApplySettings);
    }

    // ���� �ػ��� �ε����� ã�� �޼���
    private int FindCurrentResolutionIndex()
    {
        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                return i;
            }
        }
        return 0;
    }

    // ���� ���� �޼���
    public void ApplySettings()
    {
        selectedResolutionIndex = resolutionDropdown.value;
        Resolution resolution = resolutions[selectedResolutionIndex];
        fullscreen = fullscreenToggle.isOn;

        // �ػ󵵿� ��üȭ�� ���� ����
        Screen.SetResolution(resolution.width, resolution.height, fullscreen);
    }
}