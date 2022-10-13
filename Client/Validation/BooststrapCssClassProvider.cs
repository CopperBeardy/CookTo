using Microsoft.AspNetCore.Components.Forms;

namespace CookTo.Client.Validation;
//Code used here layout used here is the same as in the book - Blazor in Action by Chris Sainty

public sealed class BootstrapCssClassProvider : FieldCssClassProvider
{
    public override string GetFieldCssClass(EditContext editContext, in FieldIdentifier fieldIdentifier)
    {
        var isValid = !editContext.GetValidationMessages(fieldIdentifier).Any();

        if(editContext.IsModified(fieldIdentifier))
        {
            return isValid ? "is-valid" : "is-invalid";
        }

        return isValid ? string.Empty : "is-invalid";
    }
}