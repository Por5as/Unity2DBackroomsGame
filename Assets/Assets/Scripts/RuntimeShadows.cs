using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.Universal;

namespace Game.Utils
{
    /// <summary>
    /// Generates ShadowCasters dynamically when tiles appear and enables/disables them based on player proximity.
    /// </summary>
    public class RuntimeShadows : MonoBehaviour
    {
        [SerializeField]
        private CompositeCollider2D m_TilemapCollider;

        [SerializeField]
        private Transform m_Player;

        [SerializeField]
        private bool m_SelfShadows = false;

        [SerializeField]
        private float m_UpdateInterval = 3f; // How often to enable/disable shadows

        [SerializeField]
        private float m_TileCheckInterval = 5f; // How often to check for new tiles

        [SerializeField]
        private float m_ActivationDistance = 5f; // Distance to activate shadows

        [SerializeField]
        private float m_DelayBeforeGenerating = 1f; // Delay in seconds before initial shadow generation

        private List<ShadowCaster2D> m_ShadowCasters = new List<ShadowCaster2D>();
        private float m_Timer;
        private bool m_Initialized = false;

        protected virtual void Reset()
        {
            m_TilemapCollider = GetComponent<CompositeCollider2D>();
        }

        protected virtual void Start()
        {
            StartCoroutine(DelayedInitialization());
            StartCoroutine(CheckForNewTiles()); // Start checking for new tiles in the background
        }

        private IEnumerator DelayedInitialization()
        {
            yield return new WaitForSeconds(m_DelayBeforeGenerating);

            if (m_TilemapCollider == null)
                yield break;

            GenerateAndCacheShadows();
            m_Initialized = true;
        }
        
        protected virtual void Update()
        {
            if (!m_Initialized || m_Player == null)
                return;

            m_Timer += Time.deltaTime;
            if (m_Timer >= m_UpdateInterval)
            {
                m_Timer = 0f;
                UpdateShadowCasters();
            }
        }
        
        private void GenerateAndCacheShadows()
        {
            ShadowCaster2DGenerator.GenerateTilemapShadowCasters(m_TilemapCollider, m_SelfShadows);
            m_ShadowCasters.AddRange(GetComponentsInChildren<ShadowCaster2D>(true));
        }

        private IEnumerator CheckForNewTiles()
        {
            while (true)
            {
                yield return new WaitForSeconds(m_TileCheckInterval);

                if (!m_Initialized)
                    continue;

                int previousCount = m_ShadowCasters.Count;

                GenerateAndCacheShadows(); // Adds only the new ones

                int newCount = m_ShadowCasters.Count;
                if (newCount > previousCount)
                {
                    Debug.Log($"New tiles detected! Added {newCount - previousCount} new shadows.");
                }
            }
        }

        private void UpdateShadowCasters()
        {
            foreach (var shadowCaster in m_ShadowCasters)
            {
                if (shadowCaster == null) continue;

                float distance = Vector2.Distance(m_Player.position, shadowCaster.transform.position);
                bool shouldEnable = distance <= m_ActivationDistance;

                if (shadowCaster.gameObject.activeSelf != shouldEnable)
                {
                    shadowCaster.gameObject.SetActive(shouldEnable);
                }
            }
        }
    }
}
