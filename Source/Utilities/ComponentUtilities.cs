namespace UniversalTweaks.Utilities;

internal static class ComponentUtilities
{
    private static readonly Dictionary<string, Dictionary<Type, Component>> storedComponents = [];

    internal static void RemoveComponent<T>(params string[] itemNames) where T : Component
    {
        foreach (var itemName in itemNames)
        {
            GearItem item = GearItem.LoadGearItemPrefab(itemName);
            if (item != null)
            {
                T component = item.gameObject.GetComponent<T>();
                if (component != null)
                {
                    if (!storedComponents.ContainsKey(itemName))
                    {
                        storedComponents[itemName] = [];
                    }

                    storedComponents[itemName][typeof(T)] = component;
                    UnityEngine.Object.Destroy(component);
                }
            }
        }
    }

    internal static void RestoreComponent<T>(params string[] itemNames) where T : Component
    {
        foreach (var itemName in itemNames)
        {
            if (storedComponents.TryGetValue(itemName, out var components) && components.TryGetValue(typeof(T), out var component))
            {
                GearItem item = GearItem.LoadGearItemPrefab(itemName);
                if (item != null && item.gameObject.GetComponent<T>() == null)
                {
                    item.gameObject.AddComponent<T>().CopyFrom(component);
                }
            }
        }
    }

    private static void CopyFrom<T>(this T destination, Component source) where T : Component
    {
        var type = destination.GetType();
        if (source.GetType() != type) return;

        var fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
        foreach (var field in fields)
        {
            field.SetValue(destination, field.GetValue(source));
        }
    }
}