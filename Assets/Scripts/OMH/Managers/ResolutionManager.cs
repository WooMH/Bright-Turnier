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
    public Button cancelButton; // �߰�: ��� ��ư

    private Resolution[] resolutions;
    private List<Resolution> filteredResolutions;
    private bool fullscreen;
    private int selectedResolutionIndex;

    // ���� ������ �����ϱ� ���� ����
    private int previousResolutionIndex;
    private bool previousFullscreen;

    void Start()
    {
        // �ػ� ����Ʈ ��������
        resolutions = Screen.resolutions;
        filteredResolutions = new List<Resolution>();

        // ��� ������ �ִ� �ػ� ã��
        Resolution maxResolution = resolutions[0];
        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].width * resolutions[i].height > maxResolution.width * maxResolution.height)
            {
                maxResolution = resolutions[i];
            }
        }

        // �ִ� �ػ��� ���� ���
        float maxAspectRatio = (float)maxResolution.width / maxResolution.height;

        // �ػ󵵸� ���͸� (16:9, 4:3 ������ �ִ� ����) �� �ߺ� ����
        HashSet<string> addedResolutions = new HashSet<string>(); // �ߺ� ���Ÿ� ���� HashSet ���
        for (int i = 0; i < resolutions.Length; i++)
        {
            float aspectRatio = (float)resolutions[i].width / resolutions[i].height;
            if ((Mathf.Abs(aspectRatio - 16f / 9f) < 0.01f ||
                Mathf.Abs(aspectRatio - 4f / 3f) < 0.01f ||
                Mathf.Abs(aspectRatio - maxAspectRatio) < 0.01f) &&
                !addedResolutions.Contains(resolutions[i].width + "x" + resolutions[i].height)) // �ߺ� üũ
            {
                filteredResolutions.Add(resolutions[i]);
                addedResolutions.Add(resolutions[i].width + "x" + resolutions[i].height); // �߰��� �ػ� ���
            }
        }

        // �ػ󵵸� ū �ͺ��� ���� �� ������ ����
        filteredResolutions.Sort((res1, res2) => (res2.width * res2.height).CompareTo(res1.width * res1.height));

        resolutionDropdown.ClearOptions();

        // Dropdown�� �ɼ� �߰��ϱ�
        List<string> options = new List<string>();
        for (int i = 0; i < filteredResolutions.Count; i++)
        {
            string option = filteredResolutions[i].width + " x " + filteredResolutions[i].height;
            options.Add(option);
        }
        resolutionDropdown.AddOptions(options);

        // ���� �ػ� ����
        selectedResolutionIndex = FindCurrentResolutionIndex();
        resolutionDropdown.value = selectedResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        // ��� ���� ����
        fullscreenToggle.isOn = Screen.fullScreen;

        // �ʱ� ������ ����
        previousResolutionIndex = selectedResolutionIndex;
        previousFullscreen = Screen.fullScreen;

        // ��ư Ŭ�� �� ����
        applyButton.onClick.AddListener(ApplySettings);

        // ��� ��ư Ŭ�� �� ���� �������� ����
        cancelButton.onClick.AddListener(CancelSettings);

        // Dropdown ���� ����� �� �̸� �ػ� ����
        resolutionDropdown.onValueChanged.AddListener(delegate { PreviewResolutionChange(); });
    }

    // ���� �ػ��� �ε����� ã�� �޼���
    private int FindCurrentResolutionIndex()
    {
        for (int i = 0; i < filteredResolutions.Count; i++)
        {
            if (filteredResolutions[i].width == Screen.currentResolution.width &&
                filteredResolutions[i].height == Screen.currentResolution.height)
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
        Resolution resolution = filteredResolutions[selectedResolutionIndex];
        fullscreen = fullscreenToggle.isOn;

        // �ػ󵵿� ��üȭ�� ���� ����
        Screen.SetResolution(resolution.width, resolution.height, fullscreen);

        // ���ο� �������� ���� �������� ����
        previousResolutionIndex = selectedResolutionIndex;
        previousFullscreen = fullscreen;
    }

    // ���� ��� �޼���
    public void CancelSettings()
    {
        // ���� ���������� ����
        resolutionDropdown.value = previousResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        fullscreenToggle.isOn = previousFullscreen;

        // �ػ󵵿� ��üȭ�� ���� ����
        Resolution resolution = filteredResolutions[previousResolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, previousFullscreen);
    }

    // Dropdown ���� ����� �� �̸� �ػ� ����
    private void PreviewResolutionChange()
    {
        int tempResolutionIndex = resolutionDropdown.value;
        Resolution resolution = filteredResolutions[tempResolutionIndex];
        bool tempFullscreen = fullscreenToggle.isOn;

        // �ػ󵵿� ��üȭ�� ���� �̸� ����
        Screen.SetResolution(resolution.width, resolution.height, tempFullscreen);
    }
}