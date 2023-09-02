namespace SpecificationValidation.Blazor;
public class SpecificationValidator<T> : ComponentBase
{
    [CascadingParameter]
    EditContext EditContext { get; set; }

    [Parameter]
    public IValidator<T> Validator { get; set; }

    ValidationMessageStore ValidationMessageStore;

    public override async Task SetParametersAsync(ParameterView parameters)
    {
        EditContext previousEditContext = EditContext;

        await base.SetParametersAsync(parameters);

        if (EditContext != previousEditContext)
        {
            ValidationMessageStore =
                new ValidationMessageStore(EditContext);
            EditContext.OnValidationRequested += ValidationRequested;
            EditContext.OnFieldChanged += FieldChanged;
        }
    }

    private void ValidationRequested(object sender,
        ValidationRequestedEventArgs e)
    {
        ValidationMessageStore.Clear();
        IValidationResult result = Validator.Validate((T)EditContext.Model);
        HandleErrors(EditContext.Model, result);
    }

    private void FieldChanged(object sender, FieldChangedEventArgs e)
    {
        FieldIdentifier fieldIdentifier = e.FieldIdentifier;
        ValidationMessageStore.Clear(fieldIdentifier);

        IValidationResult result =
            Validator.ValidateProperty((T)fieldIdentifier.Model,
            fieldIdentifier.FieldName);

        HandleErrors(fieldIdentifier.Model, result);
    }
    private void HandleErrors(object model, IValidationResult result)
    {
        if (!result.IsValid)
        {
            foreach (IValidationError error in result.Errors)
            {
                ValidationMessageStore.Add(
                    new FieldIdentifier(model, error.PropertyName),
                    error.Message);
            }
        }
    }
}
