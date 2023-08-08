using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{

    private CommunicationManager communicationManager;

    [SerializeField] private TextMeshProUGUI recipesDeliveredText;
    [SerializeField] private TextMeshProUGUI healthyCommunicationText;
    [SerializeField] private TextMeshProUGUI totalScoreText;

    private void Awake()
    {
        communicationManager = FindObjectOfType<CommunicationManager>();
    }

    private void Start() {
        KitchenGameManager.Instance.OnStateChanged += KitchenGameManager_OnStateChanged;

        Hide();
    }

    private void KitchenGameManager_OnStateChanged(object sender, System.EventArgs e) {
        if (KitchenGameManager.Instance.IsGameOver()) {
            Show();

            recipesDeliveredText.text = DeliveryManager.Instance.GetSuccessfulRecipesAmount().ToString();
            healthyCommunicationText.text = "%" + communicationManager.GetHealthCommunication();
            totalScoreText.text = (DeliveryManager.Instance.GetSuccessfulRecipesAmount() * communicationManager.GetHealthCommunication()).ToString();
            
        } else {
            Hide();
        }
    }

    private void Show() {
        gameObject.SetActive(true);
    }

    private void Hide() {
        gameObject.SetActive(false);
    }


}