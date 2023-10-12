using UnityEngine;
using UnityEngine.UI;

public class XpBar : MonoBehaviour
{
    [SerializeField]private Image _xpBar;
    
    void Start()
    {
        PlayerCharacter.instance.OnChangeXp += OnChangeXp;
        OnChangeXp(PlayerCharacter.instance.Experience);
    }

    private void OnDestroy()
    {
        PlayerCharacter.instance.OnChangeXp -= OnChangeXp;
    }

    private void OnChangeXp(int value)
    {
        var xpToNextLevel = PlayerCharacter.instance.ExperienceToNextLevel;
        var xp = Mathf.Clamp((float)value, 0, (float)xpToNextLevel);
        _xpBar.fillAmount = xp / xpToNextLevel;
        
    }
}
