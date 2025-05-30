using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Valores de progresso")]
    public double currentSouls = 0;
    public double soulsPerClick = 1;
    public double soulsPerSecond = 0;

    public double totalSoulsEarned = 0;
    public double completeSouls = 0;

    [Header("Multiplicadores permanentes")]
    public float productionMultiplier = 1f;
    public float passiveMultiplier = 1f;
    public float clickMultiplier = 1f;
    public float costReductionMultiplier = 1f;


    [Header("Referências")]
    public UpgradeManager upgradeManager;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddSouls(double amount)
    {
        currentSouls += amount;
        totalSoulsEarned += amount;
        UIManager.Instance.UpdateUI();
    }

    public bool SpendSouls(double amount)
    {
        if (currentSouls >= amount)
        {
            currentSouls -= amount;
            UIManager.Instance.UpdateUI();
            return true;
        }
        return false;
    }

    public void ResetProgress()
    {
        currentSouls = 0;
        soulsPerClick = 1;
        soulsPerSecond = 0;

        if (upgradeManager != null)
        {
            upgradeManager.clickUpgrade.level = 0;
            upgradeManager.passiveUpgrade.level = 0;
        }
    }
}
