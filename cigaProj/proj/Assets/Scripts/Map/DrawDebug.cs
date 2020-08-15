//using UnityEngine;

//public static class DrawDebug
//{
//    public static void DrawSphere(Vector3 pos, float scale, Color color, string name = "Sphere")
//    {
//        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
//        sphere.name = name;
//        sphere.transform.localScale = Vector3.one * scale;
//        sphere.transform.localPosition = pos;
//        Renderer renderer = sphere.GetComponent<Renderer>();
//        renderer.material.color = color;
//    }

//    public static void DrawSphereParent(Vector3 pos, float scale, Color color, Transform transform, string name = "Sphere")
//    {
//        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
//        sphere.transform.SetParent(transform);
//        sphere.name = name;
//        sphere.transform.localScale = Vector3.one * scale;
//        sphere.transform.localPosition = pos;
//        Renderer renderer = sphere.GetComponent<Renderer>();
//        renderer.material.color = color;
//    }

//    public static GameObject DrawCube(Vector3 pos, float scale, Color color, string name = "Cube")
//    {
//        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Cube);
//        sphere.name = name;
//        sphere.transform.localScale = Vector3.one * scale;
//        sphere.transform.localPosition = pos;
//        Renderer renderer = sphere.GetComponent<Renderer>();
//        renderer.material.color = color;
//        return sphere;
//    }

//    public static Vector3[] vector3s;

//    public void static DrawLine(Vector3[] vector3s)
//    {
//        this.vector3s = vector3s;
//    }

//#if UNITY_EDITOR
//    private void OnDrawGizmos()
//    {
//        if (vector3s != null)
//        {
//            for (int i = 0; i < vector3s.Length - 1; i++)
//            {
//                Gizmos.DrawLine(vector3s[i], vector3s[i + 1]);
//            }
//        }
//    }
//#endif
//}
