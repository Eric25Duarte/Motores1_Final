using UnityEngine;

public class ShieldPowerUp : PowerUp
{
    [Header("Shield Settings")]
    [SerializeField] private float shieldDuration = 5f;
    [SerializeField] private float shieldAmount = 30f;
    [SerializeField] private GameObject shieldEffectPrefab; // Assign a particle effect in the inspector
    
    private GameObject activeShieldEffect;

    public override void Activate(Player player)
    {
        if (player == null) return;
        
        // Activate shield on the player
        player.ActivateShield(shieldDuration, shieldAmount);
        
        // Create visual effect
        if (shieldEffectPrefab != null)
        {
            activeShieldEffect = Instantiate(shieldEffectPrefab, player.transform);
            
            // Set up to destroy the effect when the shield is deactivated
            player.OnShieldDeactivated += RemoveShieldEffect;
        }
        
        // Play sound if available
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }
        
        // Disable collider and renderer but don't destroy yet (let sound finish playing)
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null) collider.enabled = false;
        
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        if (renderer != null) renderer.enabled = false;
        
        // Destroy after a delay to allow sound to play
        Destroy(gameObject, 2f);
    }
    
    private void RemoveShieldEffect()
    {
        if (activeShieldEffect != null)
        {
            Destroy(activeShieldEffect);
        }
        
        // Unsubscribe from the event
        if (Player.Instance != null)
        {
            Player.Instance.OnShieldDeactivated -= RemoveShieldEffect;
        }
    }
    
    private void OnDestroy()
    {
        // Clean up event subscription if the object is destroyed while the shield is still active
        if (Player.Instance != null)
        {
            Player.Instance.OnShieldDeactivated -= RemoveShieldEffect;
        }
    }
}
