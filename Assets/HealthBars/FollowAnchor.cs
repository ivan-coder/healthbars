using System.Collections;
using UnityEngine;

namespace HealthBars
{
    /// <summary>
    /// Must be attached to an UI element. Follows an anchor in world space.
    /// Call Setup to start to connect the UI object with the world object transform.
    /// </summary>
    public class FollowAnchor : MonoBehaviour
    {
        private Transform anchor;
        private Canvas canvas;

        public void Setup(Transform anchor)
        {
            this.anchor = anchor;
            canvas = FindObjectOfType<Canvas>();
            StartCoroutine(UpdateCor());
        }

        private IEnumerator UpdateCor()
        {
            while (true)
            {
                yield return null;
                if (anchor == null)
                {
                    Destroy(gameObject);
                    yield break;
                }

                transform.position = WorldPointToCanvasWithScreenSpaceCamera(canvas, anchor.position);
            }
        }

        private static Vector3 WorldPointToCanvasWithScreenSpaceCamera(
            Canvas canvas,
            Vector3 point)
        {
            Vector2 screen = RectTransformUtility.WorldToScreenPoint(canvas.worldCamera, point);
            RectTransformUtility.ScreenPointToWorldPointInRectangle((RectTransform)canvas.transform, screen, canvas.worldCamera,
                out Vector3 world);
            return world;
        }
    }
}
