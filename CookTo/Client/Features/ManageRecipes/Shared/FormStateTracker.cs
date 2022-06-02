using CookTo.Client.State;
using CookTo.Shared.Features.ManageRecipes;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace CookTo.Client.Features.ManageRecipes.Shared;

public class FormStateTracker : ComponentBase
{
    [Inject] public AppState AppState { get; set; } = default!;

    [CascadingParameter] private EditContext CascadedEditContext { get; set; } = default!;

    protected override void OnInitialized()
    {
        if (CascadedEditContext is null)
        {
            throw new InvalidOperationException(
                $"{nameof(FormStateTracker)} requires a cascading parameter of type {nameof(EditContext)}");
        }

        CascadedEditContext.OnFieldChanged += CascadedEditContext_OnFieldChanged;
    }

    private void CascadedEditContext_OnFieldChanged(object? sender, FieldChangedEventArgs e)
    {
        var property = sender.GetType().GetProperty("Model");
        var model = (FullRecipe)property.GetValue(sender, null);

        if (string.IsNullOrWhiteSpace(model.Id))
        {
            AppState.NewRecipeState.SetRecipe(model);
        }
    }
}
