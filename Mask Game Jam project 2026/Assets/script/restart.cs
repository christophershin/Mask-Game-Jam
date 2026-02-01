using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
