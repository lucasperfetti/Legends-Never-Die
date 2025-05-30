using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PermanentUpgradesManager : MonoBehaviour
{
    public TextMeshProUGUI completeSoulsText;

    public Button productionX2Button;
    public Button passiveX3Button;
    public Button clickX3Button;
    public Button reduceCostButton;
    public Button rebirthButton;

    public int productionX2Cost = 10;
    public int passiveX3Cost = 20;
    public int clickX3Cost = 20;
    public int reduceCostCost = 30;
    public int rebirthCost = 1000;

    private GameManager gm;

    void Start()
    {
        gm = GameManager.Instance;
        UpdateUI();
    }

    void UpdateUI()
    {
        completeSoulsText.text = $"Almas Completas: {gm.completeSouls}";
    }

    public void BuyProductionX2()
    {
        if (gm.completeSouls >= productionX2Cost)
        {
            gm.completeSouls -= productionX2Cost;
            gm.productionMultiplier *= 2;
            UpdateUI();
        }
    }

    public void BuyPassiveX3()
    {
        if (gm.completeSouls >= passiveX3Cost)
        {
            gm.completeSouls -= passiveX3Cost;
            gm.passiveMultiplier *= 3;
            UpdateUI();
        }
    }

    public void BuyClickX3()
    {
        if (gm.completeSouls >= clickX3Cost)
        {
            gm.completeSouls -= clickX3Cost;
            gm.clickMultiplier *= 3;
            UpdateUI();
        }
    }

    public void BuyReduceCost()
    {
        if (gm.completeSouls >= reduceCostCost)
        {
            gm.completeSouls -= reduceCostCost;
            gm.costReductionMultiplier *= 0.75f;
            UpdateUI();
        }
    }

    public void BuyRebirth()
    {
        if (gm.completeSouls >= rebirthCost)
        {
            // Exibe mensagem de vitória
            Debug.Log("Parabéns! Você renasceu e venceu o jogo!");
            // Aqui você pode carregar uma cena final ou mostrar um painel de vitória
        }
    }

    public void BackToGame()
    {
        SceneManager.LoadScene("GameScene"); // nome da cena principal
    }
}
