using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // 인스펙터에서 각각의 카메라를 드래그해서 넣어주세요
    public GameObject firstPersonCam;
    public GameObject thirdPersonCam;

    // 현재 1인칭인지 확인하는 변수 (기본은 3인칭이므로 false)
    private bool isFirstPerson = false;

    void Start()
    {
        // 게임 시작 시 초기 상태 설정
        ApplyCameraState();
    }

    void Update()
    {
        // 스페이스바를 누르면 상태를 반전시키고 적용
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isFirstPerson = !isFirstPerson;
            ApplyCameraState();
        }
    }

    void ApplyCameraState()
    {
        if (isFirstPerson)
        {
            // 1인칭 
            firstPersonCam.SetActive(true);
            thirdPersonCam.SetActive(false);
            Debug.Log("현재 시점: 1인칭");
        }
        else
        {
            // 3인칭 
            firstPersonCam.SetActive(false);
            thirdPersonCam.SetActive(true);
            Debug.Log("현재 시점: 3인칭");
        }
    }
}
