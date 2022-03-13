using Sirb.Template.Shared.Extensions;
using Sirb.Template.Shared.ViewModels;
using Sirb.Template.WebApp.Shared.Base;

namespace Sirb.Template.WebApp.Pages
{
    public class FormSampleComponent : LoggedBaseComponent
    {
        protected SampleViewModel SampleModel { get; set; } = new SampleViewModel();


        protected void OnClick()
        {
            Console.WriteLine(SampleModel.ToJson());
        }
    }
}