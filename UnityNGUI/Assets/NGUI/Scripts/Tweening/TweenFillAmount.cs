 #region 
 /* ========================================================================
 5 * 作    者：YH
 6 * 文件名称：TweenFillAmount
 7 * 功    能：移动填充量
 8 * 创建时间：2018/01/12
 */
#endregion
 
 using UnityEngine;

[RequireComponent(typeof(UISprite))]
[AddComponentMenu("NGUI/Tween/Tween Fill Amount")]
public class TweenFillAmount : UITweener
{
    public float from = 0;
    public float to = 1;
    private static UISprite mBasic;

    public float value { get { return mBasic.fillAmount; } set { mBasic.fillAmount = value; } }

    protected override void OnUpdate(float factor, bool isFinished)
    {
        value = Mathf.Lerp(from, to, factor);
    }

    /// Start the tweening operation.
    /// </summary>

    static public TweenFillAmount Begin(GameObject widget, UISprite target, float duration, float value)
    {
        mBasic = target;
        TweenFillAmount comp = UITweener.Begin<TweenFillAmount>(widget, duration);
        comp.from = mBasic.fillAmount;
        comp.to = value;

        if (duration <= 0f)
        {
            comp.Sample(1f, true);
            comp.enabled = false;
        }
        return comp;
    }


    public override void SetStartToCurrentValue() { from = value; }

    public override void SetEndToCurrentValue() { to = value; }
}