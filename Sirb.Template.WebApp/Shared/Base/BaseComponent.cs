using Blazored.LocalStorage;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Sirb.Template.Shared.ViewModels;

namespace Sirb.Template.WebApp.Shared.Base
{
    public abstract class BaseComponent : ComponentBase
    {
        [Inject] protected HttpClient HttpClient { get; set; }
        [Inject] protected NavigationManager NavigationManager { get; set; }
        [Inject] protected ILocalStorageService LocalStorage { get; set; }
        [Inject] protected IToastService ToastService { get; set; }
        protected AccountViewModel Account { get; set; }

        public async Task SignIn(AccountViewModel account)
        {
            await SetAccount(account);
            NavigationManager.NavigateTo("/"); // redirect to home
        }

        private async Task SetAccount(AccountViewModel account)
        {
            Account = account;
            //Account.ExpireDate = DateTime.Now.AddHours(12);
            await LocalStorage.SetItemAsync(nameof(AccountViewModel), Account);
        }

        public async Task SignOut()
        {
            await ClearAccount();
            RedirectToLogin();
            StateHasChanged();
        }

        private async Task ClearAccount()
        {
            Account = default;
            await LocalStorage.RemoveItemAsync(nameof(AccountViewModel));
        }

        private void RedirectToLogin() => NavigationManager.NavigateTo("/login");

        protected void ExceptionHandler(Exception ex) => ExceptionHandler(ex, ex?.Message);

        protected void ExceptionHandler(Exception ex, string message)
        {
            NotifyError(message);
            Console.WriteLine(ex);
            StateHasChanged();
        }

        protected void NotifyWarning(string message, string title = "Alerta") => ToastService.ShowWarning(message, title);
        protected void NotifyError(string message, string title = "Erro") => ToastService.ShowError(message, title);
        protected void NotifySuccess(string message, string title = "Sucesso") => ToastService.ShowSuccess(message, title);
        protected void NotifyInfo(string message, string title = "Informação") => ToastService.ShowInfo(message, title);
    }
}