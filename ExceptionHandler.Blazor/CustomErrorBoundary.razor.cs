namespace ExceptionHandler.Blazor
{
    public partial class CustomErrorBoundary : ErrorBoundary
    {
        [Parameter]
        public EventCallback<Exception> OnException { get; set; }

        readonly List<Exception> ReceivedExceptions = new();

        protected override Task OnErrorAsync(Exception exception)
        {
            ReceivedExceptions.Add(exception);
            OnException.InvokeAsync(exception);
            return base.OnErrorAsync(exception);
        }

        public new void Recover()
        {
            ReceivedExceptions.Clear();
            base.Recover();
        }
    }
}