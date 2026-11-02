using UnityEngine;

namespace Utils {
    public class JsonReader {
        public static T returnJsonObject<T>(TextAsset jsonFile) {
            return JsonUtility.FromJson<T>(jsonFile?.text);
        }
    }
}
