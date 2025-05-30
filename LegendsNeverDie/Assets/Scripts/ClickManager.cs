using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public void OnClick()
    {
        double totalClickProduction = GameManager.Instance.soulsPerClick *
                                    GameManager.Instance.clickMultiplier *
                                    GameManager.Instance.productionMultiplier;

        GameManager.Instance.AddSouls(totalClickProduction);
    }
}
