using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;

namespace Sirb.Template.WebApp.Shared.Components;

public class SwitcherInput : InputBase<bool>
{
    [DisallowNull] public ElementReference? Element { get; protected set; }

    [Parameter] public string Label { get; set; }

    private int _index = 0;

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        base.BuildRenderTree(builder);

        builder.OpenElement(_index++, "div");
        builder.AddAttribute(_index++, "class", "input-switcher");

        CreateLabel(builder);

        CreateInput(builder);

        builder.CloseElement();
    }

    private void CreateInput(RenderTreeBuilder builder)
    {
        builder.OpenElement(_index++, "label");
        builder.AddAttribute(_index++, "class", "switch");

        #region input

        builder.OpenElement(_index++, "input");
        builder.AddAttribute(_index++, "type", "checkbox");
        builder.AddAttribute(_index++, "checked", BindConverter.FormatValue(CurrentValue));
        builder.AddAttribute(_index++, "onchange", EventCallback.Factory.CreateBinder<bool>(this, __value => CurrentValue = __value, CurrentValue));
        builder.CloseElement();

        #endregion

        #region span

        builder.OpenElement(_index++, "span");
        builder.AddAttribute(_index++, "class", "slider");
        builder.CloseElement();

        #endregion

        // label
        builder.CloseElement();
    }

    private void CreateLabel(RenderTreeBuilder builder)
    {
        builder.OpenElement(_index++, "label");
        builder.AddContent(_index++, Label);
        builder.CloseElement();
    }


    /// <inheritdoc/>
    protected override bool TryParseValueFromString(string? value, out bool result, [NotNullWhen(false)] out string? validationErrorMessage)
        => throw new NotSupportedException($"This component does not parse string inputs. Bind to the '{nameof(CurrentValue)}' property, not '{nameof(CurrentValueAsString)}'.");
}
