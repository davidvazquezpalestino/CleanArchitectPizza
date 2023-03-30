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
        EditContext PreviousEditContext = EditContext;

        await base.SetParametersAsync(parameters);

        if (EditContext != PreviousEditContext)
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
        var Result = Validator.Validate((T)EditContext.Model);
        HandleErrors(EditContext.Model, Result);
    }

    private void FieldChanged(object sender, FieldChangedEventArgs e)
    {
        FieldIdentifier FieldIdentifier = e.FieldIdentifier;
        ValidationMessageStore.Clear(FieldIdentifier);

        IValidationResult Result =
            Validator.ValidateProperty((T)FieldIdentifier.Model,
            FieldIdentifier.FieldName);

        HandleErrors(FieldIdentifier.Model, Result);
    }
    private void HandleErrors(object model, IValidationResult result)
    {
        if (!result.IsValid)
        {
            foreach (var Error in result.Errors)
            {
                ValidationMessageStore.Add(
                    new FieldIdentifier(model, Error.PropertyName),
                    Error.Message);
            }
        }
    }
}
