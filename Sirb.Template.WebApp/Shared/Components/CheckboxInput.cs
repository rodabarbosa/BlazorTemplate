using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;

namespace Sirb.Template.WebApp.Shared.Components
{
    public class CheckboxInput : InputBase<bool>
    {
        [DisallowNull] public ElementReference? Element { get; protected set; }

        [Parameter] public string Label { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);

            builder.OpenElement(0, "div");
            builder.AddAttribute(1, "class", "input-check");

            CreateInput(builder);

            CreateLabel(builder);

            builder.CloseElement();
        }

        private void CreateInput(RenderTreeBuilder builder)
        {
            builder.OpenElement(2, "input");
            builder.AddMultipleAttributes(3, AdditionalAttributes);
            builder.AddAttribute(4, "type", "checkbox");
            builder.AddAttribute(5, "class", CssClass);
            builder.AddAttribute(6, "checked", BindConverter.FormatValue(CurrentValue));
            builder.AddAttribute(7, "onchange", EventCallback.Factory.CreateBinder<bool>(this, __value => CurrentValue = __value, CurrentValue));
            builder.AddElementReferenceCapture(8, __inputReference => Element = __inputReference);
            builder.CloseElement();
        }

        private void CreateLabel(RenderTreeBuilder builder)
        {
            builder.OpenElement(9, "label");
            builder.AddContent(10, Label);
            builder.CloseElement();
        }


        /// <inheritdoc/>
        protected override bool TryParseValueFromString(string? value, out bool result, [NotNullWhen(false)] out string? validationErrorMessage)
            => throw new NotSupportedException($"This component does not parse string inputs. Bind to the '{nameof(CurrentValue)}' property, not '{nameof(CurrentValueAsString)}'.");
    }
}
