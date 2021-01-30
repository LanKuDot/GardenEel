using UnityEngine;

namespace Investigate
{
    public class GardenEelComponent : MonoBehaviour
    {
        public static GardenEelComponent Instance { get; private set; }
        public int[] componentIDs { get; private set; }

        private void Awake()
        {
            // Destroy old one
            if (Instance != null && Instance != this) {
                Destroy(Instance.gameObject);
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);

            componentIDs = new int[(int) GardenEel.BodyType.NUM_OF_TYPE];
            for (var i = 0; i < componentIDs.Length; ++i)
                componentIDs[i] = -1;
        }

        public void SetComponent(GardenEel.BodyType type, int componentID)
        {
            componentIDs[(int) type] = componentID;
        }
    }
}
