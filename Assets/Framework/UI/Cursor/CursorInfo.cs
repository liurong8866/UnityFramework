
using UnityEngine;
/// <summary>
/// 光标身份
/// </summary>
[System.Serializable]
public class CursorInfo
{
    #region 公共变量

    //光标类型
    private CursorType type = CursorType.Default;

    //光标状态
    private CursorState state = CursorState.Default;

    //光标偏移量
    private Vector2 offset = Vector2.zero;

    //光标模式
    private CursorMode cursorMode = CursorMode.Auto;

    #endregion

    #region 构造函数

    public CursorInfo() { }

    public CursorInfo(CursorType type, CursorState state)
    {
        this.type = type;
        this.state = state;
    }

    #endregion

    #region 方法属性

    //字符串转换
    public override string ToString()
    {
        return type + "_" + state;
    }

    public static CursorInfo Default
    {
        get { return new CursorInfo() { type = CursorType.Default, state = CursorState.Default }; }
    }

    #endregion

}