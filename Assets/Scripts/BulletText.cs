using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BulletText : MonoBehaviour
{
    public TMP_Text bulletText;

    private void Awake()
    {
        bulletText = GetComponent<TMP_Text>();
    }

    public void SetBullet(int bullets)
    {
        bulletText.text = "Bullets: " + bullets;
    }
}
