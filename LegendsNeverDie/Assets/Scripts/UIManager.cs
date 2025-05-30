using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Referências externas")]
    public UpgradeManager upgradeManager;
    public AscensionManager ascensionManager;

    [Header("Textos principais")]
    public TextMeshProUGUI soulsText;
    public TextMeshProUGUI completeSoulsText;

    [Header("Upgrade de clique")]
    public TextMeshProUGUI clickUpgradeCostText;
    public TextMeshProUGUI clickUpgradeLevelText;

    [Header("Upgrade passivo")]
    public TextMeshProUGUI passiveUpgradeCostText;
    public TextMeshProUGUI passiveUpgradeLevelText;

    [Header("Ascensão")]
    public TextMeshProUGUI ascensionRequirementText;

    [Header("Pop-up de Ascensão")]
    public GameObject ascensionPopup;
    public TextMeshProUGUI ascensionPopupText;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        var gm = GameManager.Instance;
        var um = upgradeManager;
        var am = ascensionManager;

        soulsText.text = $"Almas: {gm.currentSouls:F0}";
        completeSoulsText.text = $"Almas Completas: {gm.completeSouls:F0}";

        clickUpgradeCostText.text = $"Custo: {um.clickUpgrade.GetCost():F0}";
        clickUpgradeLevelText.text = $"Nível: {um.clickUpgrade.level}";

        passiveUpgradeCostText.text = $"Custo: {um.passiveUpgrade.GetCost():F0}";
        passiveUpgradeLevelText.text = $"Nível: {um.passiveUpgrade.level}";

        ascensionRequirementText.text = $"Ascensão: {gm.totalSoulsEarned:F0} / {am.nextAscensionThreshold:F0}";
    }

    public void ShowAscensionPopup()
    {
        int soulsToGain = ascensionManager.CalculateAscensionSouls();
        ascensionPopupText.text = $"Deseja ascender e ganhar {soulsToGain} almas completas?";
        ascensionPopup.SetActive(true);
    }

    public void HideAscensionPopup()
    {
        ascensionPopup.SetActive(false);
    }

    public void ConfirmAscension()
    {
        ascensionPopup.SetActive(false);
        ascensionManager.Ascend();
        SceneManager.LoadScene("UpgradesScene"); // Certifique-se de que essa cena existe
    }
}
