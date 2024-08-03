using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallScript : MonoBehaviour
{
    CircleCollider2D cr;
    SpriteRenderer sp;
    public Sprite cekýrge;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bomba"))
        {
            collision.gameObject.tag = "Cekirge";
            sp = collision.gameObject.GetComponent<SpriteRenderer>();
            cr=collision.gameObject.GetComponent<CircleCollider2D>();
            sp.sprite = cekýrge;
            sp.color=Color.white;
            collision.gameObject.transform.localScale = new Vector2(0.3f, 0.3f);
            cr.offset = new Vector2(-0.21f, 0.03f);
            cr.radius = 2;

        }
    }
}
