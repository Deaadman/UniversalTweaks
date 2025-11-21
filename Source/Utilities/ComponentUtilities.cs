namespace UniversalTweaks.Utilities;

internal static class ComponentUtilities
{
    private static readonly Dictionary<string, Dictionary<Type, Component>> StoredComponents = [];

    internal static void RemoveComponent<T>(params string[] itemNames) where T : Component
    {
        foreach (var itemName in itemNames)
        {
            var item = GearItem.LoadGearItemPrefab(itemName);
            if (item == null)
            {
                continue;
            }

            var component = item.gameObject.GetComponent<T>();
            if (component == null)
            {
                continue;
            }

            if (!StoredComponents.ContainsKey(itemName))
            {
                StoredComponents[itemName] = [];
            }

            StoredComponents[itemName][typeof(T)] = component;
            UnityEngine.Object.Destroy(component);
        }
    }

    internal static void RestoreComponent<T>(params string[] itemNames) where T : Component
    {
        foreach (var itemName in itemNames)
        {
            if (!StoredComponents.TryGetValue(itemName, out var components) ||
                !components.TryGetValue(typeof(T), out var component))
            {
                continue;
            }

            var item = GearItem.LoadGearItemPrefab(itemName);
            if (item != null && item.gameObject.GetComponent<T>() == null)
            {
                item.gameObject.AddComponent<T>().CopyFrom(component);
            }
        }
    }

    private static void CopyFrom<T>(this T destination, Component source) where T : Component
    {
        var type = destination.GetType();
        if (source.GetType() != type)
        {
            return;
        }

        var fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
        foreach (var field in fields)
        {
            field.SetValue(destination, field.GetValue(source));
        }
    }
}