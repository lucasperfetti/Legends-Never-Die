using UnityEngine;
using UnityEngine.SceneManagement;

public class AscensionManager : MonoBehaviour
{
    public static AscensionManager Instance;

    public double nextAscensionThreshold = 1000;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public int CalculateAscensionSouls()
    {
        return (int)(GameManager.Instance.totalSoulsEarned / nextAscensionThreshold);
    }

    public bool CanAscend()
    {
        return GameManager.Instance.totalSoulsEarned >= nextAscensionThreshold;
    }

    public void Ascend()
    {
        int soulsGained = CalculateAscensionSouls();

        if (soulsGained > 0)
        {
            GameManager.Instance.completeSouls += soulsGained;

            // Reinicia o progresso
            GameManager.Instance.totalSoulsEarned = 0;
            GameManager.Instance.ResetProgress();

            // Reinicia o valor necessário para a próxima ascensão
            nextAscensionThreshold = 1000;
        }
        SceneManager.LoadScene("UpgradesScene"); 
    }
}
