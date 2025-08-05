using UnityEngine;

public class HealingPowerUp : PowerUp
{
    [Header("Healing Settings")]
    [SerializeField] private float healAmount = 25f;
    [SerializeField] private GameObject healEffectPrefab; 
    [SerializeField] private AudioClip healSound; 
    
    public override void Activate(Player player)
    {
        if (player == null) return;
        
        // Heal the player
        float healthBefore = player.GetHealth();
        player.Heal(healAmount);
        float actualHeal = player.GetHealth() - healthBefore;
        
        if (actualHeal > 0)
        {
            // Create healing effect
            if (healEffectPrefab != null)
            {
                Instantiate(healEffectPrefab, player.transform.position, Quaternion.identity);
            }
            
            // Play healing sound
            if (healSound != null)
            {
                AudioSource.PlayClipAtPoint(healSound, player.transform.position);
            }
            
            // Show healing text (optional)
            ShowHealingText(player.transform.position, $"+{actualHeal} HP");
        }
        
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null) collider.enabled = false;
        
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        if (renderer != null) renderer.enabled = false;
        
        Destroy(gameObject, 1f);
    }
    
    private void ShowHealingText(Vector3 position, string text)
    {
        Debug.Log(text);
        
    }
}
