using System.Collections;
using UnityEngine;

public class BlinkService
{
    public static IEnumerator BlinkCoroutine(BoxCollider2D colliderToDisable, SpriteRenderer spriteRenderer)
    {
        colliderToDisable.enabled = false;

        for (int i = 0; i < 15; i++)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(0.1f);
        }

        spriteRenderer.enabled = true;
        colliderToDisable.enabled = true;
    }
}