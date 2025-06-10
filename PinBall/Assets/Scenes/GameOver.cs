using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{
    private bool isReloading = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isReloading && collision.gameObject.CompareTag("Player"))
        {
            isReloading = true; // Evita múltiplas recargas
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
} 
