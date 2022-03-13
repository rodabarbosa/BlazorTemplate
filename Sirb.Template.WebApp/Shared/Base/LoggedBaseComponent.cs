using Sirb.Template.Shared.ViewModels;

namespace Sirb.Template.WebApp.Shared.Base
{
    public abstract class LoggedBaseComponent : BaseComponent
    {
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await LoadAccountFromSession();

            if (IsTokenExpired(Account))
            {
                NotifyError("Seu acesso expirou ou não foi possível validar o acesso.", "Acesso inválido");
                await SignOut();
                StateHasChanged();
                return;
            }

            string url = NavigationManager.Uri.Replace(NavigationManager.BaseUri, "");
            if (!HasPageAccess(url))
            {
                NavigationManager.NavigateTo("/accessdenied");
                StateHasChanged();
            }
        }

        private async Task LoadAccountFromSession()
        {
            Account = await LocalStorage.GetItemAsync<AccountViewModel>(nameof(AccountViewModel));
        }

        private static bool IsTokenExpired(AccountViewModel accountViewModel)
        {
            // TODO: quando o retorno de permissão estiver correto esta linha deve ser removida
            return false;
            return accountViewModel is null || accountViewModel.ExpireDate < DateTime.Now;
        }

        private bool HasPageAccess(string pageUri)
        {
            // TODO: quando o retorno de permissão estiver correto esta linha deve ser removida
            return true;

            if (string.IsNullOrEmpty(pageUri))
                return true;

            return Account.Permissions.Where(p => p.Uri == pageUri).Any(p => p.Read);
        }
    }
}