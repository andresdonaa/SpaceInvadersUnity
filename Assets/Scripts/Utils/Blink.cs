using System.Collections;
using UnityEngine;

public static class Blink
{
    public static IEnumerator BlinkWithDisableColliderCoroutine(BoxCollider2D collider, SpriteRenderer spriteRenderer)
    {
        collider.enabled = false;

        for (int i = 0; i < 15; i++)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(0.1f);
        }

        spriteRenderer.enabled = true;
        collider.enabled = true;
    }
}