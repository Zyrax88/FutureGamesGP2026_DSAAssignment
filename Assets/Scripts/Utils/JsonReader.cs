using UnityEngine;

namespace Utils {
    [CreateAssetMenu(fileName = "JsonReader", menuName = "Scriptable Objects/JsonReader")]
    public class JsonReader : ScriptableObject {
        [SerializeField] public TextAsset jsonFile;

        public T returnJsonObject<T>() {
            return JsonUtility.FromJson<T>(jsonFile?.text);
        }
    }
}
