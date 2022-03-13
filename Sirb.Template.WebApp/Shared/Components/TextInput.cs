using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;

namespace Sirb.Template.WebApp.Shared.Components;

public class TextInput : InputBase<string>
{
    [Parameter] public string Label { get; set; }
    [Parameter] public string Placeholder { get; set; }

    /// <inheritdoc/>
    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        base.BuildRenderTree(builder);

        builder.OpenElement(0, "div");
        builder.AddAttribute(1, "class", "input-block");

        CreateLabel(builder);

        CreateInput(builder);

        builder.CloseElement();
    }

    private void CreateLabel(RenderTreeBuilder builder)
    {
        builder.OpenElement(2, "label");
        builder.AddContent(3, Label);
        builder.CloseElement();
    }

    private void CreateInput(RenderTreeBuilder builder)
    {
        builder.OpenElement(4, "input");
        builder.AddMultipleAttributes(5, AdditionalAttributes);
        builder.AddAttribute(6, "class", CssClass);
        builder.AddAttribute(7, "value", BindConverter.FormatValue(CurrentValue));
        builder.AddAttribute(8, "onchange", EventCallback.Factory.CreateBinder<string>(this, __value => CurrentValueAsString = __value, CurrentValueAsString));
        builder.AddAttribute(9, "type", "text");

        if (!string.IsNullOrEmpty(Placeholder))
        {
            builder.AddAttribute(10, "placeholder", Placeholder);
        }

        builder.CloseElement();
    }

    /// <inheritdoc/>
    protected override bool TryParseValueFromString(string value, out string result, out string validationErrorMessage)
    {
        result = value;
        validationErrorMessage = null;
        return true;
    }
}
