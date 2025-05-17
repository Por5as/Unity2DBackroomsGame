using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Rendering.Universal;

public static class ShadowCaster2DExtensions
{
    public static void SetPath(this ShadowCaster2D shadowCaster, Vector3[] path)
    {
        FieldInfo shapeField = typeof(ShadowCaster2D).GetField("m_ShapePath",
            BindingFlags.NonPublic | BindingFlags.Instance);
        shapeField.SetValue(shadowCaster, path);
    }

    public static void SetPathHash(this ShadowCaster2D shadowCaster, int hash)
    {
        FieldInfo hashField = typeof(ShadowCaster2D).GetField("m_ShapePathHash",
            BindingFlags.NonPublic | BindingFlags.Instance);
        hashField.SetValue(shadowCaster, hash);
    }
}

public class ShadowCaster2DGenerator
{
#if UNITY_EDITOR
    [UnityEditor.MenuItem("Generate Shadow Casters", menuItem = "Tools/Generate Shadow Casters")]
    public static void GenerateShadowCasters()
    {
        CompositeCollider2D[] colliders = GameObject.FindObjectsOfType<CompositeCollider2D>();
        foreach (var collider in colliders)
            GenerateTilemapShadowCastersInEditor(collider, false);
    }

    [UnityEditor.MenuItem("Generate Shadow Casters (Self Shadows)", menuItem = "Tools/Generate Shadow Casters (Self Shadows)")]
    public static void GenerateShadowCastersSelfShadows()
    {
        CompositeCollider2D[] colliders = GameObject.FindObjectsOfType<CompositeCollider2D>();
        foreach (var collider in colliders)
            GenerateTilemapShadowCastersInEditor(collider, true);
    }

    public static void GenerateTilemapShadowCastersInEditor(CompositeCollider2D collider, bool selfShadows)
    {
        GenerateTilemapShadowCasters(collider, selfShadows);
        UnityEditor.SceneManagement.EditorSceneManager.MarkAllScenesDirty();
    }
#endif

    public static void GenerateTilemapShadowCasters(CompositeCollider2D collider, bool defaultSelfShadows)
    {
        // Clean up existing casters
        foreach (var sc in collider.GetComponentsInChildren<ShadowCaster2D>())
        {
            if (sc.transform.parent == collider.transform)
                GameObject.DestroyImmediate(sc.gameObject);
        }

        int pathCount = collider.pathCount;
        List<Vector2> path2D = new List<Vector2>();
        List<Vector3> path3D = new List<Vector3>();

        for (int i = 0; i < pathCount; ++i)
        {
            collider.GetPath(i, path2D);

            if (path2D.Count < 3 || IsDegenerate(path2D))
                continue;

            bool isClockwise = IsClockwise(path2D);
            bool useSelfShadows = !isClockwise || defaultSelfShadows;

            foreach (var p in path2D)
                path3D.Add(p);

            GameObject shadowGO = new GameObject("ShadowCaster2D");
            shadowGO.isStatic = true;
            shadowGO.transform.SetParent(collider.transform, false);

            var caster = shadowGO.AddComponent<ShadowCaster2D>();
            caster.SetPath(path3D.ToArray());
            caster.SetPathHash(Random.Range(int.MinValue, int.MaxValue));
            caster.selfShadows = useSelfShadows;
            caster.Update();

            path2D.Clear();
            path3D.Clear();
        }
    }

    private static bool IsDegenerate(List<Vector2> points)
    {
        for (int i = 1; i < points.Count; i++)
        {
            if (points[i] != points[0])
                return false;
        }
        return true;
    }

    private static bool IsClockwise(List<Vector2> points)
    {
        float sum = 0f;
        for (int i = 0; i < points.Count; i++)
        {
            Vector2 v1 = points[i];
            Vector2 v2 = points[(i + 1) % points.Count];
            sum += (v2.x - v1.x) * (v2.y + v1.y);
        }
        return sum < 0f;
    }
}
