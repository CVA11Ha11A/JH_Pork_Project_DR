using UnityEngine;
using UnityEngine.SceneManagement;

public class JS_SceneLoader : MonoBehaviour
{
    public float delay = default; // �ε� ������
    public string sceneName = default; // �ε��� ���� �̸�

    void Start()
    {
        // delay �Ŀ� LoadScene �Լ��� ȣ���Ͽ� ���� �ε�
        Invoke("LoadSceneAfterDelay", delay);
    }

    void LoadSceneAfterDelay()
    {
        // ������ �̸��� ���� �ε�
        SceneManager.LoadScene(sceneName);
    }
}
