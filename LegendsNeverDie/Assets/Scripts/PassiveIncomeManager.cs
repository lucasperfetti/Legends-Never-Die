using UnityEngine;

public class PassiveIncomeManager : MonoBehaviour
{
    private float timer = 0f;
    public float interval = 1f; // tempo entre ganhos (1 segundo)

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            timer = 0f;
            double totalPassiveProduction = GameManager.Instance.soulsPerSecond *
                                            GameManager.Instance.passiveMultiplier *
                                            GameManager.Instance.productionMultiplier;

            GameManager.Instance.AddSouls(totalPassiveProduction);
        }
    }
}
