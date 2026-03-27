using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    [SerializeField] private Button buttonresette;

    void Start()
    {
        buttonresette.onClick.AddListener(Home);
    }

    private void Home()
    {
        SceneManager.LoadScene("Menu");
    }

}
}
