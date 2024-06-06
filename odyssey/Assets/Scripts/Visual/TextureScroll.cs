using UnityEngine;

namespace Assets.Scripts.Visual
{
    public class TextureScroll : MonoBehaviour
    {
        [SerializeField] private float scrollSpeed;
        [SerializeField] private MeshRenderer targetMesh;

        void Update()
        {
            var material = targetMesh.material;
            material.mainTextureOffset += (Vector2.up * scrollSpeed * Time.deltaTime);
        }
    }
}
