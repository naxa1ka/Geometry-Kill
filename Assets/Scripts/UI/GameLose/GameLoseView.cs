using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class GameLoseView : MonoBehaviour
{
    [SerializeField] private Button _continueButton;
    [SerializeField] private TextMeshProUGUI _bestScoreText;
    [SerializeField] private TextMeshProUGUI _currentScoreText;

    private CanvasGroup _canvasGroup;
    
    public event Action OnContinue;

    private void OnEnable()
    {
        _continueButton.onClick.AddListener(OnContinueClick);
    }

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Set(int currentScore, int bestScore)
    {
        _currentScoreText.text = currentScore.ToString();
        _bestScoreText.text = bestScore.ToString();
    }
    
    public void Open()
    {
       _canvasGroup.Open();
    }

    public void Close()
    {
        _canvasGroup.Close();
    }
    
    private void OnContinueClick()
    {
        OnContinue?.Invoke();
    }

    private void OnDisable()
    {
        _continueButton.onClick.RemoveListener(OnContinueClick);
    }
}