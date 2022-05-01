using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using Sirb.Template.WebApp.Shared.Base;

namespace Sirb.Template.WebApp.Shared.Components
{
    public class PasswordInput : TextInputBase
    {
        [Parameter] public bool ShowPassword { get; set; }

        private const string TextInputType = "text";
        private const string PasswordInputType = "password";

        protected override string GetInputType() => ShowPassword ? TextInputType : PasswordInputType;


    }
}
