﻿using System;
using UnityEngine;

namespace Weapon
{
    public class WeaponHolder : MonoBehaviour
    {
        public SpriteRenderer characterRenderer, weaponRenderer;
        public Vector2 pointer { get; set; }

        private void Update()
        {
            var direction = (pointer - (Vector2) transform.position).normalized;
            transform.right = direction;
            Vector2 scale = transform.localScale;
            if (direction.x < 0)
            {
                scale.y = -1;
            }
            else if (direction.x > 0)
            {
                scale.y = 1;
            }

            transform.localScale = scale;
            if (transform.eulerAngles.z > 0 && transform.eulerAngles.z < 180)
            {
                weaponRenderer.sortingOrder = characterRenderer.sortingOrder - 1;
            }
            else
            {
                weaponRenderer.sortingOrder = characterRenderer.sortingOrder + 1;
            }
        }
    }
}