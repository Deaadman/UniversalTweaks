using UniversalTweaks.Utilities;

namespace UniversalTweaks;

[RegisterTypeInIl2Cpp(false)]
internal class DisplayMetrics : MonoBehaviour
{
    public DisplayMetrics(IntPtr intPtr) : base(intPtr) { }

    internal void Initialize()
    {
        GameObject FPSLabelGameObject = UserInterfaceUtilities.SetupGameObject("FPSLabel", transform, new Vector3(0, 0, 0));
        FPSLabelGameObject.AddComponent<UILabel>();
        UILabel FPSLabel = FPSLabelGameObject.GetComponent<UILabel>();

        UserInterfaceUtilities.SetupLabel(FPSLabel, "Testing", FontStyle.Normal, UILabel.Crispness.Always, NGUIText.Alignment.Automatic, UILabel.Overflow.ResizeFreely, false, 20, 20, Color.white, true);
    }

    private void Update()
    {

    }
}