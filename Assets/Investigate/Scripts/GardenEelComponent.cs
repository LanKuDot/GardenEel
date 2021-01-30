using UnityEngine;

namespace Investigate
{
    public class GardenEelComponent : MonoBehaviour
    {
        public static GardenEelComponent Instance { get; private set; }
        public int[] componentIDs { get; private set; }

        private int numOfComponents;

        private void Awake()
        {
            // Destroy old one
            if (Instance != null && Instance != this) {
                Destroy(Instance.gameObject);
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);

            numOfComponents = (int) GardenEel.BodyType.NUM_OF_TYPE;
            componentIDs = new int[numOfComponents];
            for (var i = 0; i < componentIDs.Length; ++i)
                componentIDs[i] = -1;
        }

        public int SetComponent(int newID, out bool toAppend)
        {
            // Fill the empty one first
            for (var i = 0; i < numOfComponents; ++i) {
                if (componentIDs[i] != -1)
                    continue;

                toAppend = false;
                componentIDs[i] = newID;
                return i;
            }

            // If all elements are filled, push the first one and append at the end
            for (var i = 1; i < numOfComponents; ++i)
                componentIDs[i - 1] = componentIDs[i];

            toAppend = true;
            componentIDs[numOfComponents - 1] = newID;
            return numOfComponents - 1;
        }
    }
}
