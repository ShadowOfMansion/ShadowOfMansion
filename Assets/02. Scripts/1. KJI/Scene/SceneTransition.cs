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
        image.canvasRenderer.SetAlpha(0.0f); // �ʱ� ������ 0���� �����Ͽ� ���̵� �� ȿ�� �غ�
        Invoke("StartFadeOut", delayBeforeFade);
    }

    void StartFadeOut()
    {
        image.CrossFadeAlpha(1.0f, fadeDuration, false); // ���̵� �ƿ� ����
        Invoke("LoadNextScene", fadeDuration); // ���̵� �ƿ��� ������ ���� ������ ��ȯ
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene("ShadowofMansion");
    }
}
