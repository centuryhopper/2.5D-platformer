using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                // create a new game object
                GameObject g = new GameObject();

                // add component to it
                instance = g.AddComponent<T>();

                // give it a name
                g.name = typeof(T).ToString();
            }

            return instance;
        }
    }

}