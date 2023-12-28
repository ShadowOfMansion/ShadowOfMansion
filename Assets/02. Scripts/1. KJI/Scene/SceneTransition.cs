using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public GameObject fadeImage;
    public float fadeDuration = 1.5f;
    public float delayBeforeFade = 3.0f;
    private Image image;

    void Start()
    {
        image = fadeImage.GetComponent<Image>();
        image.canvasRenderer.SetAlpha(0.0f); // 초기 투명도를 0으로 설정하여 페이드 인 효과 준비
        Invoke("StartFadeOut", delayBeforeFade);
    }

    void StartFadeOut()
    {
        image.CrossFadeAlpha(1.0f, fadeDuration, false); // 페이드 아웃 시작
        Invoke("LoadNextScene", fadeDuration); // 페이드 아웃이 끝나면 다음 씬으로 전환
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene("ShadowofMansion");
    }
}
