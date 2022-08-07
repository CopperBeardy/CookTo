using CookTo.Client.State;
using CookTo.Shared.Modules.ManageRecipes;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace CookTo.Client.Modules.ManageRecipes.Shared;

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
        if (sender is not null)
        {
            var property = sender.GetType().GetProperty("Model");

            if (property != null)
            {
                if (property.GetValue(sender, null) is Recipe model)
                    if (string.IsNullOrWhiteSpace(model.Id))
                    {
                        AppState.NewRecipeState.SetRecipe(model);
                    }
            }
        }
    }
}
