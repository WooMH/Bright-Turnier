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
    public Button cancelButton; // 추가: 취소 버튼

    private Resolution[] resolutions;
    private List<Resolution> filteredResolutions;
    private bool fullscreen;
    private int selectedResolutionIndex;

    // 이전 설정을 저장하기 위한 변수
    private int previousResolutionIndex;
    private bool previousFullscreen;

    void Start()
    {
        // 해상도 리스트 가져오기
        resolutions = Screen.resolutions;
        filteredResolutions = new List<Resolution>();

        // 사용 가능한 최대 해상도 찾기
        Resolution maxResolution = resolutions[0];
        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].width * resolutions[i].height > maxResolution.width * maxResolution.height)
            {
                maxResolution = resolutions[i];
            }
        }

        // 최대 해상도의 비율 계산
        float maxAspectRatio = (float)maxResolution.width / maxResolution.height;

        // 해상도를 필터링 (16:9, 4:3 비율과 최대 비율) 및 중복 제거
        HashSet<string> addedResolutions = new HashSet<string>(); // 중복 제거를 위한 HashSet 사용
        for (int i = 0; i < resolutions.Length; i++)
        {
            float aspectRatio = (float)resolutions[i].width / resolutions[i].height;
            if ((Mathf.Abs(aspectRatio - 16f / 9f) < 0.01f ||
                Mathf.Abs(aspectRatio - 4f / 3f) < 0.01f ||
                Mathf.Abs(aspectRatio - maxAspectRatio) < 0.01f) &&
                !addedResolutions.Contains(resolutions[i].width + "x" + resolutions[i].height)) // 중복 체크
            {
                filteredResolutions.Add(resolutions[i]);
                addedResolutions.Add(resolutions[i].width + "x" + resolutions[i].height); // 추가된 해상도 기록
            }
        }

        // 해상도를 큰 것부터 작은 것 순서로 정렬
        filteredResolutions.Sort((res1, res2) => (res2.width * res2.height).CompareTo(res1.width * res1.height));

        resolutionDropdown.ClearOptions();

        // Dropdown에 옵션 추가하기
        List<string> options = new List<string>();
        for (int i = 0; i < filteredResolutions.Count; i++)
        {
            string option = filteredResolutions[i].width + " x " + filteredResolutions[i].height;
            options.Add(option);
        }
        resolutionDropdown.AddOptions(options);

        // 현재 해상도 선택
        selectedResolutionIndex = FindCurrentResolutionIndex();
        resolutionDropdown.value = selectedResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        // 토글 상태 설정
        fullscreenToggle.isOn = Screen.fullScreen;

        // 초기 설정값 저장
        previousResolutionIndex = selectedResolutionIndex;
        previousFullscreen = Screen.fullScreen;

        // 버튼 클릭 시 적용
        applyButton.onClick.AddListener(ApplySettings);

        // 취소 버튼 클릭 시 이전 설정으로 복원
        cancelButton.onClick.AddListener(CancelSettings);

        // Dropdown 값이 변경될 때 미리 해상도 적용
        resolutionDropdown.onValueChanged.AddListener(delegate { PreviewResolutionChange(); });
    }

    // 현재 해상도의 인덱스를 찾는 메서드
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

    // 설정 적용 메서드
    public void ApplySettings()
    {
        selectedResolutionIndex = resolutionDropdown.value;
        Resolution resolution = filteredResolutions[selectedResolutionIndex];
        fullscreen = fullscreenToggle.isOn;

        // 해상도와 전체화면 설정 적용
        Screen.SetResolution(resolution.width, resolution.height, fullscreen);

        // 새로운 설정값을 이전 설정으로 저장
        previousResolutionIndex = selectedResolutionIndex;
        previousFullscreen = fullscreen;
    }

    // 설정 취소 메서드
    public void CancelSettings()
    {
        // 이전 설정값으로 복원
        resolutionDropdown.value = previousResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        fullscreenToggle.isOn = previousFullscreen;

        // 해상도와 전체화면 설정 복원
        Resolution resolution = filteredResolutions[previousResolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, previousFullscreen);
    }

    // Dropdown 값이 변경될 때 미리 해상도 적용
    private void PreviewResolutionChange()
    {
        int tempResolutionIndex = resolutionDropdown.value;
        Resolution resolution = filteredResolutions[tempResolutionIndex];
        bool tempFullscreen = fullscreenToggle.isOn;

        // 해상도와 전체화면 설정 미리 적용
        Screen.SetResolution(resolution.width, resolution.height, tempFullscreen);
    }
}